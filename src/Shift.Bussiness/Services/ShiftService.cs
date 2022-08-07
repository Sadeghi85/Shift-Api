using Shift.Bussiness;
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
	public class ShiftService : ServiceBase, IShiftService {

		private readonly IShiftShiftStore _shiftShiftStore;
		private readonly IPortalStore _portalStore;
		private readonly IShiftShiftTemplateStore _shiftShiftTemplateStore;
		private readonly ISamtResourceTypeStore _samtResourceTypeStore;

		public ShiftService(IPrincipal iPrincipal, IShiftShiftStore shiftShiftStore, IPortalStore portalStore, IShiftLogStore shiftLogStore, IShiftShiftTemplateStore shiftShiftTemplateStore, ISamtResourceTypeStore samtResourceTypeStore) : base(iPrincipal, shiftLogStore) {
			_shiftShiftStore = shiftShiftStore;
			_portalStore = portalStore;
			_shiftShiftTemplateStore = shiftShiftTemplateStore;
			_samtResourceTypeStore = samtResourceTypeStore;
		}

		public async Task<StoreViewModel<ShiftViewModel>> GetAll(ShiftSearchModel model) {

			var getAllExpressions = new List<Expression<Func<ShiftShift, bool>>>();

			if (model.Id > 0) {
				getAllExpressions.Add(x => x.Id == model.Id);
			}
			if (CurrentUserPortalId == 1) {
				if (model.PortalId > 0) {
					getAllExpressions.Add(x => x.PortalId == model.PortalId);
				}
			} else {
				getAllExpressions.Add(x => x.PortalId == CurrentUserPortalId);
			}
			if (!string.IsNullOrWhiteSpace(model.Title)) {
				getAllExpressions.Add(x => x.Title.Contains(model.Title));
			}
			if (model.ShiftTypeId > 0) {
				getAllExpressions.Add(x => x.ShiftTypeId == model.ShiftTypeId);
			}
			if (model.IsDeleted != null) {
				getAllExpressions.Add(x => x.IsDeleted == model.IsDeleted);
			}
			if (model.StartTime != null) {
				getAllExpressions.Add(x => x.StartTime == model.StartTime);
			}
			if (model.EndTime != null) {
				getAllExpressions.Add(x => x.EndTime == model.EndTime);
			}

			var res = await _shiftShiftStore.GetAllWithPagingAsync(getAllExpressions, x => new ShiftViewModel { Id = x.Id, Title = x.Title, PortalTitle = x.Portal.Title, PortalId = x.PortalId, EndTime = x.EndTime, StartTime = x.StartTime, ShiftTypeId = x.ShiftTypeId, ShiftTypeTitle = _getShiftTypeTitleByShiftTypeId(x.ShiftTypeId), DisplayLabel = _getShiftDropdownDiplayLabel(CurrentUserPortalId, x.Title, x.Portal.Title) }, model.OrderKey, model.Desc, model.PageSize, model.PageNo);

			return res;
		}

		public async Task<BaseResult> Register(ShiftInputModel model) {
			try {

				if (CurrentUserPortalId > 1 && CurrentUserPortalId != model.PortalId) {
					BaseResult.Success = false;
					BaseResult.Message = "شما به این قسمت دسترسی ندارید";
					return BaseResult;
				}

				TimeSpan diff;
				switch (TimeSpan.Compare(model.EndTime, model.StartTime)) {
					case -1:
						diff = (model.EndTime.Add(TimeSpan.FromDays(1))) - model.StartTime;
						break;
					case 0:
						diff = TimeSpan.Zero;
						break;
					case 1:
						diff = model.EndTime - model.StartTime;
						break;
					default:
						diff = TimeSpan.Zero;
						break;
				}
				if (diff == TimeSpan.Zero) {
					BaseResult.Success = false;
					BaseResult.Message = "ساعت شروع و پایان را بدرستی وارد نمایید";
					return BaseResult;
				}

				var foundPortal = await _portalStore.FindByIdAsync(model.PortalId);
				if (null == foundPortal) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه پورتال یافت نشد";

					return BaseResult;
				}

				var isFound = await _shiftShiftStore.AnyAsync(x => x.IsDeleted == false && x.PortalId == model.PortalId && x.ShiftTypeId == model.ShiftTypeId && x.Title.ToLower() == model.Title.ToLower());
				if (isFound) {
					BaseResult.Success = false;
					BaseResult.Message = "شیفت با این نام قبلا ثبت شده است";

					return BaseResult;
				}

				isFound = _shiftShiftStore.CheckTimeOverlap(0, model.PortalId, model.ShiftTypeId, model.StartTime, model.EndTime);
				if (isFound) {
					BaseResult.Success = false;
					BaseResult.Message = "بازه زمانی انتخاب شده با موارد ثبت شده تداخل دارد";

					return BaseResult;
				}

				var shiftShift = new ShiftShift { Title = model.Title, PortalId = model.PortalId, ShiftTypeId = model.ShiftTypeId, StartTime = model.StartTime, EndTime = model.EndTime, IsDeleted = false };

				var res = await _shiftShiftStore.InsertAsync(shiftShift);

				if (res < 0) {
					BaseResult = await LogError(new Exception("Failed to insert shiftShift\r\n\r\n" + JsonSerializer.Serialize(shiftShift, new JsonSerializerOptions() {
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

		public async Task<BaseResult> Update(ShiftInputModel model) {
			try {

				if (CurrentUserPortalId > 1 && CurrentUserPortalId != model.PortalId) {
					BaseResult.Success = false;
					BaseResult.Message = "شما به این قسمت دسترسی ندارید";
					return BaseResult;
				}

				TimeSpan diff;
				switch (TimeSpan.Compare(model.EndTime, model.StartTime)) {
					case -1:
						diff = (model.EndTime.Add(TimeSpan.FromDays(1))) - model.StartTime;
						break;
					case 0:
						diff = TimeSpan.Zero;
						break;
					case 1:
						diff = model.EndTime - model.StartTime;
						break;
					default:
						diff = TimeSpan.Zero;
						break;
				}
				if (diff == TimeSpan.Zero) {
					BaseResult.Success = false;
					BaseResult.Message = "ساعت شروع و پایان را بدرستی وارد نمایید";
					return BaseResult;
				}

				var found = await _shiftShiftStore.FindByIdAsync(x => x.Id == model.Id && x.IsDeleted == false);

				if (null == found) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه مورد نظر یافت نشد";

					return BaseResult;
				}
				if (CurrentUserPortalId > 1 && CurrentUserPortalId != found.PortalId) {
					BaseResult.Success = false;
					BaseResult.Message = "شما به این قسمت دسترسی ندارید";
					return BaseResult;
				}

				var foundPortal = await _portalStore.FindByIdAsync(model.PortalId);
				if (null == foundPortal) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه پورتال یافت نشد";

					return BaseResult;
				}

				var isFound = await _shiftShiftStore.AnyAsync(x => x.Id != model.Id && x.IsDeleted == false && x.PortalId == model.PortalId && x.ShiftTypeId == model.ShiftTypeId && x.Title.ToLower() == model.Title.ToLower());
				if (isFound) {
					BaseResult.Success = false;
					BaseResult.Message = "شیفت با این نام قبلا ثبت شده است";

					return BaseResult;
				}

				isFound = _shiftShiftStore.CheckTimeOverlap(model.Id, model.PortalId, model.ShiftTypeId, model.StartTime, model.EndTime);
				if (isFound) {
					BaseResult.Success = false;
					BaseResult.Message = "بازه زمانی انتخاب شده با موارد ثبت شده تداخل دارد";

					return BaseResult;
				}

				found.Title = model.Title;
				found.StartTime = model.StartTime;
				found.EndTime = model.EndTime;
				found.ShiftTypeId = model.ShiftTypeId;
				found.PortalId = model.PortalId;

				var res = await _shiftShiftStore.UpdateAsync(found);

				if (res < 0) {
					BaseResult = await LogError(new Exception("Failed to update shiftShift\r\n\r\n" + JsonSerializer.Serialize(found, new JsonSerializerOptions() {
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

				var found = await _shiftShiftStore.FindByIdAsync(id);

				if (found == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه مورد نظر یافت نشد";
					return BaseResult;
				}

				if (CurrentUserPortalId > 1 && CurrentUserPortalId != found.PortalId) {
					BaseResult.Success = false;
					BaseResult.Message = "شما به این قسمت دسترسی ندارید";
					return BaseResult;
				}

				found.IsDeleted = true;

				var res = await _shiftShiftStore.UpdateAsync(found);

				if (res < 0) {
					BaseResult = await LogError(new Exception("Failed to delete shiftShift\r\n\r\n" + JsonSerializer.Serialize(found, new JsonSerializerOptions() {
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

		//public async Task<StoreViewModel<ShiftShift>> FindByPortalId(int portalId) {

		//	var res = await _shiftShiftStore.GetAllAsync(pp => pp.PortalId == portalId, x => x, x => x.Id);

		//	return res;

		//}

		private static string _getShiftDropdownDiplayLabel(int? CurrentUserPortalId, string shiftTitle, string portalTitle) {
			if (CurrentUserPortalId == 1) {
				return $"{shiftTitle} ({portalTitle})";
			} else {
				return shiftTitle;
			}

		}
		private static string _getShiftTypeTitleByShiftTypeId(int? ShiftTypeId) {

			string? res;

			switch (ShiftTypeId) {
				case 1:
					res = "رژی";
					break;
				case 2:
					res = "هماهنگی";
					break;
				default:
					res = "نامشخص";
					break;
			}

			return res;
		}

		//public async IQueryable<ShiftShift> GetByPortalId(int portalId) {
		//	//throw new NotImplementedException();
		//	IQueryable<ShiftShift>? res = _shiftShiftStore.GetAll().Where(pp => pp.PortalId == portalId);
		//	return res;

		//}

		//private bool IsInShiftType(int shiftType) {
		//	List<int> shiftTypes = new List<int>() { 1, 2 };
		//	var res = shiftTypes.Contains(shiftType);
		//	return res;
		//}

		public async Task<StoreViewModel<ShiftTemplateViewModel>> GetAllShiftTemplates(ShiftTemplateSearchModel model) {

			var getAllShiftTemplateExpressions = new List<Expression<Func<ShiftShiftTemplate, bool>>>();

			if (CurrentUserPortalId == 1) {
				//if (model.PortalId > 0) {
				//	getAllShiftShiftJobTemplateExpressions.Add(x => x.PortalId == model.PortalId);
				//}
			} else {
				getAllShiftTemplateExpressions.Add(x => x.ShiftShift.PortalId == CurrentUserPortalId);
			}

			if (model.Id > 0) {
				getAllShiftTemplateExpressions.Add(x => x.ShiftId == model.ShiftId);
			}
			if (model.ShiftId > 0) {
				getAllShiftTemplateExpressions.Add(x => x.ShiftId == model.ShiftId);
			}
			if (model.JobId > 0) {
				getAllShiftTemplateExpressions.Add(x => x.JobId == model.JobId);
			}
			if (model.IsDeleted != null) {
				getAllShiftTemplateExpressions.Add(x => x.IsDeleted == model.IsDeleted);
			}

			var res = await _shiftShiftTemplateStore.GetAllWithPagingAsync(getAllShiftTemplateExpressions, x =>
			new ShiftTemplateViewModel {
				Id = x.Id,
				JobId = x.JobId,
				JobTitle = x.SamtResourceType.Title,
				ShiftId = x.ShiftId,
				ShiftTitle = x.ShiftShift.Title
			}, model.OrderKey, model.Desc, model.PageSize, model.PageNo);

			return res;
		}

		public async Task<BaseResult> RegisterShiftTemplate(ShiftTemplateInputModel model) {
			try {

				var foundJob = await _samtResourceTypeStore.FindByIdAsync(x => x.Id == model.JobId && x.IsDeleted == false);
				if (null == foundJob) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه عنوان شغلی یافت نشد";

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

				var isFound = await _shiftShiftTemplateStore.AnyAsync(x => x.IsDeleted == false && x.ShiftId == model.ShiftId && x.JobId == model.JobId);

				if (isFound) {
					BaseResult.Success = false;
					BaseResult.Message = "این آیتم قبلا ثبت شده است";
					return BaseResult;
				}

				var shiftShiftTemplate = new ShiftShiftTemplate {
					JobId = model.JobId,
					ShiftId = model.ShiftId,
					IsDeleted = false,
				};

				var res = await _shiftShiftTemplateStore.InsertAsync(shiftShiftTemplate);

				if (res < 0) {
					BaseResult = await LogError(new Exception("Failed to insert shiftShiftTemplate\r\n\r\n" + JsonSerializer.Serialize(shiftShiftTemplate, new JsonSerializerOptions() {
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

		public async Task<BaseResult> UpdateShiftTemplate(ShiftTemplateInputModel model) {
			try {

				var found = await _shiftShiftTemplateStore.FindByIdAsync(x => x.Id == model.Id && x.IsDeleted == false);
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

				var foundJob = await _samtResourceTypeStore.FindByIdAsync(x => x.Id == model.JobId && x.IsDeleted == false);
				if (null == foundJob) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه عنوان شغلی یافت نشد";

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

				var isFound = await _shiftShiftTemplateStore.AnyAsync(x => x.Id != model.Id && x.IsDeleted == false && x.ShiftId == model.ShiftId && x.JobId == model.JobId);

				if (isFound) {
					BaseResult.Success = false;
					BaseResult.Message = "این آیتم قبلا ثبت شده است";
					return BaseResult;
				}

				found.ShiftId = model.ShiftId;
				found.JobId = model.JobId;

				var res = await _shiftShiftTemplateStore.UpdateAsync(found);

				if (res < 0) {
					BaseResult = await LogError(new Exception("Failed to update shiftShiftTemplate\r\n\r\n" + JsonSerializer.Serialize(found, new JsonSerializerOptions() {
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

		public async Task<BaseResult> DeleteShiftTemplate(int id) {
			try {

				var found = await _shiftShiftTemplateStore.FindByIdAsync(id);

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

				var res = await _shiftShiftTemplateStore.UpdateAsync(found);

				if (res < 0) {
					BaseResult = await LogError(new Exception("Failed to delete shiftShiftTemplate\r\n\r\n" + JsonSerializer.Serialize(found, new JsonSerializerOptions() {
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
