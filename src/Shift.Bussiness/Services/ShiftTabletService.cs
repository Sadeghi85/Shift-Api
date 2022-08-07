using Shift.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shift.Bussiness {
	public class ShiftTabletService : ServiceBase, IShiftTabletService {

		private readonly IShiftShiftTabletStore _shiftShiftTabletStore;
		private readonly IShiftShiftStore _shiftShiftStore;
		private readonly IShiftLocationStore _shiftLocationStore;

		public ShiftTabletService(IPrincipal iPrincipal, IShiftShiftTabletStore shiftShiftTabletStore, IShiftShiftStore shiftShiftStore, IShiftLocationStore shiftLocationStore, IShiftLogStore shiftLogStore) : base(iPrincipal, shiftLogStore) {
			_shiftShiftTabletStore = shiftShiftTabletStore;
			_shiftShiftStore = shiftShiftStore;
			_shiftLocationStore = shiftLocationStore;
		}

		//public List<ShiftShiftTablet> GetTabletShiftByPortalId(int portalId) {

		//	List<ShiftShiftTablet>? res = _shiftShiftTabletStore.GetAll().Where(pp => pp.ShiftShift.PortalId == portalId && pp.IsDeleted == false).ToList();

		//	return res;
		//}

		public async Task<StoreViewModel<ShiftTabletViewModel>> GetAll(ShiftTabletSearchModel model) {

			var getAllExpressions = new List<Expression<Func<ShiftShiftTablet, bool>>>();

			getAllExpressions.Add(x => x.ShiftShift.IsDeleted == false);

			if (CurrentUserPortalId == 1) {
				//if (model.PortalId > 0) {
				//	getAllShiftShiftJobTemplateExpressions.Add(x => x.PortalId == model.PortalId);
				//}
			} else {
				getAllExpressions.Add(x => x.ShiftShift.PortalId == CurrentUserPortalId);
			}
			if (model.Id > 0) {
				getAllExpressions.Add(x => x.Id == model.Id);
			}
			if (model.ShiftId > 0) {
				getAllExpressions.Add(x => x.ShiftId == model.ShiftId);
			}
			if (model.LocationId > 0) {
				getAllExpressions.Add(x => x.LocationId == model.LocationId);
			}
			if (model.FromDate != null) {
				getAllExpressions.Add(x => x.ShiftDate >= model.FromDate);
			}
			if (model.ToDate != null) {
				getAllExpressions.Add(x => x.ShiftDate <= model.ToDate);
			}
			if (model.IsDeleted != null) {
				getAllExpressions.Add(x => x.IsDeleted == model.IsDeleted);
			}
			if (model.HasLivePrograms != null) {
				getAllExpressions.Add(x => x.HasLivePrograms == model.HasLivePrograms);
			}

			var res = await _shiftShiftTabletStore.GetAllWithPagingAsync(getAllExpressions, x => new ShiftTabletViewModel {
				Id = x.Id,
				ShiftDate = x.ShiftDate,
				ShiftTitle = x.ShiftShift.Title,
				ShiftId = x.ShiftId,
				ShiftWorthPercent = x.ShiftWorthPercent,
				PortalId = x.ShiftShift.PortalId,
				PortalTitle = x.ShiftShift.Portal.Title,
				LocationId = x.ShiftLocation.Id,
				LocationTitle = x.ShiftLocation.Title,
				ShiftStartTime = x.ShiftShift.StartTime,
				ShiftEndTime = x.ShiftShift.EndTime,
				HasLivePrograms = x.HasLivePrograms,
				ShiftDuration = x.ShiftDuration

			}, model.OrderKey, model.Desc, model.PageSize, model.PageNo);

			return res;
		}

		public async Task<BaseResult> Register(ShiftTabletInputModel model) {

			try {
				var foundLocation = await _shiftLocationStore.FindByIdAsync(x => x.Id == model.LocationId && x.IsDeleted == false);
				if (null == foundLocation) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه لوکیشن یافت نشد";

					return BaseResult;
				}

				var foundShift = await _shiftShiftStore.FindByIdAsync(x => x.Id == model.ShiftId && x.IsDeleted == false);
				if (null == foundShift) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه شیفت یافت نشد";

					return BaseResult;
				}

				if (CurrentUserPortalId > 1 && CurrentUserPortalId != foundShift.PortalId) {
					BaseResult.Success = false;
					BaseResult.Message = "شما به این قسمت دسترسی ندارید";
					return BaseResult;
				}

				var isFound = await _shiftShiftTabletStore.AnyAsync(x => x.IsDeleted == false && x.ShiftDate.Date == model.ShiftDate.Date && x.ShiftId == model.ShiftId);

				if (isFound) {
					BaseResult.Success = false;
					BaseResult.Message = "این آیتم قبلا ثبت شده است";
					return BaseResult;
				}

				TimeSpan diff;
				switch (TimeSpan.Compare(foundShift.EndTime, foundShift.StartTime)) {
					case -1:
						diff = (foundShift.EndTime.Add(TimeSpan.FromDays(1))) - foundShift.StartTime;
						break;
					case 0:
						diff = TimeSpan.Zero;
						break;
					case 1:
						diff = foundShift.EndTime - foundShift.StartTime;
						break;
					default:
						diff = TimeSpan.Zero;
						break;
				}

				var shiftTablet = new ShiftShiftTablet {
					ShiftId = model.ShiftId,
					LocationId = model.LocationId,
					ShiftDate = model.ShiftDate,
					ShiftWorthPercent = model.ShiftWorthPercent ?? 0,
					IsDeleted = false,
					HasLivePrograms = model.HasLivePrograms,

					ShiftDuration = diff,
					PortalId = foundShift.PortalId,

				};

				var res = await _shiftShiftTabletStore.InsertAsync(shiftTablet);

				if (res < 0) {
					BaseResult = await LogError(new Exception("Failed to insert ShiftTablet\r\n\r\n" + JsonSerializer.Serialize(shiftTablet, new JsonSerializerOptions() {
						ReferenceHandler = ReferenceHandler.IgnoreCycles,
						WriteIndented = true
					})));
					return BaseResult;
				}

			} catch (Exception ex) {

				BaseResult = await LogError(ex);
			}

			return BaseResult;
		}

		public async Task<BaseResult> Update(ShiftTabletInputModel model) {
			try {

				var found = await _shiftShiftTabletStore.FindByIdAsync(x => x.Id == model.Id && x.IsDeleted == false);
				if (found == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه مورد نظر یافت نشد";
					return BaseResult;
				}
				if (CurrentUserPortalId > 1 && CurrentUserPortalId != found.ShiftShift.PortalId) {
					BaseResult.Success = false;
					BaseResult.Message = "شما به این قسمت دسترسی ندارید";
					return BaseResult;
				}

				var foundShift = await _shiftShiftStore.FindByIdAsync(x => x.Id == model.ShiftId && x.IsDeleted == false);
				if (null == foundShift) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه شیفت یافت نشد";

					return BaseResult;
				}
				if (CurrentUserPortalId > 1 && CurrentUserPortalId != foundShift.PortalId) {
					BaseResult.Success = false;
					BaseResult.Message = "شما به این قسمت دسترسی ندارید";
					return BaseResult;
				}

				var isFound = await _shiftShiftTabletStore.AnyAsync(x => x.Id != model.Id && x.IsDeleted == false && x.ShiftDate.Date == model.ShiftDate.Date && x.ShiftId == model.ShiftId);

				if (isFound) {
					BaseResult.Success = false;
					BaseResult.Message = "این آیتم قبلا ثبت شده است";
					return BaseResult;
				}

				TimeSpan diff;
				switch (TimeSpan.Compare(foundShift.EndTime, foundShift.StartTime)) {
					case -1:
						diff = (foundShift.EndTime.Add(TimeSpan.FromDays(1))) - foundShift.StartTime;
						break;
					case 0:
						diff = TimeSpan.Zero;
						break;
					case 1:
						diff = foundShift.EndTime - foundShift.StartTime;
						break;
					default:
						diff = TimeSpan.Zero;
						break;
				}

				found.ShiftId = model.ShiftId;
				found.LocationId = model.LocationId;
				found.ShiftDate = model.ShiftDate;
				found.ShiftWorthPercent = model.ShiftWorthPercent ?? found.ShiftWorthPercent;
				found.HasLivePrograms = model.HasLivePrograms;

				found.ShiftDuration = diff;
				found.PortalId = foundShift.PortalId;

				var res = await _shiftShiftTabletStore.UpdateAsync(found);

				if (res < 0) {
					BaseResult = await LogError(new Exception("Failed to update ShiftTablet\r\n\r\n" + JsonSerializer.Serialize(found, new JsonSerializerOptions() {
						ReferenceHandler = ReferenceHandler.IgnoreCycles,
						WriteIndented = true
					})));
					return BaseResult;
				}

			} catch (Exception ex) {

				BaseResult = await LogError(ex);
			}

			return BaseResult;

		}

		public async Task<BaseResult> Delete(int id) {
			try {

				var found = await _shiftShiftTabletStore.FindByIdAsync(id);

				if (found == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه مورد نظر یافت نشد";
					return BaseResult;
				}

				if (CurrentUserPortalId > 1 && CurrentUserPortalId != found.ShiftShift.PortalId) {
					BaseResult.Success = false;
					BaseResult.Message = "شما به این قسمت دسترسی ندارید";
					return BaseResult;
				}

				found.IsDeleted = true;

				var res = await _shiftShiftTabletStore.UpdateAsync(found);

				if (res < 0) {
					BaseResult = await LogError(new Exception("Failed to delete ShiftTablet\r\n\r\n" + JsonSerializer.Serialize(found, new JsonSerializerOptions() {
						ReferenceHandler = ReferenceHandler.IgnoreCycles,
						WriteIndented = true
					})));
					return BaseResult;
				}

			} catch (Exception ex) {

				BaseResult = await LogError(ex);
			}

			return BaseResult;
		}
	}
}
