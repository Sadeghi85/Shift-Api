using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness {
	public class ShiftTabletService : ServiceBase, IShiftTabletService {

		private readonly IShiftShiftTabletStore _shiftShiftTabletStore;
		private readonly IShiftShiftStore _shiftShiftStore;
		private readonly IShiftLogStore _shiftLogStore;

		public ShiftTabletService(IPrincipal iPrincipal, IShiftShiftTabletStore shiftShiftTabletStore, IShiftShiftStore shiftShiftStore, IShiftLogStore shiftLogStore) : base(iPrincipal, shiftLogStore) {
			_shiftShiftTabletStore = shiftShiftTabletStore;
			_shiftShiftStore = shiftShiftStore;
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
				ShiftStartTime = x.ShiftShift.StartTime,
				ShiftEndTime = x.ShiftShift.EndTime,
				PortalTitle = x.ShiftShift.Portal.Title
			}, model.OrderKey, model.Desc, model.PageSize, model.PageNo);

			return res;
		}

		public async Task<BaseResult> Register(ShiftTabletInputModel model) {

			try {

				var foundShift = await _shiftShiftStore.FindByIdAsync(model.ShiftId);
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

				var shiftTablet = new ShiftShiftTablet {
					ShiftId = model.ShiftId,
					ShiftDate = model.ShiftDate,
					ShiftWorthPercent = model.ShiftWorthPercent ?? 0,
					IsDeleted = false,
					HasLivePrograms = model.HasLivePrograms,

					ShiftDuration = foundShift.EndTime - foundShift.StartTime
				};

				await _shiftShiftTabletStore.InsertAsync(shiftTablet);

			} catch (Exception ex) {

				BaseResult = await LogError(ex);
			}

			return BaseResult;
		}

		public async Task<BaseResult> Update(ShiftTabletInputModel model) {
			try {

				var found = await _shiftShiftTabletStore.FindByIdAsync(model.Id);
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

				var foundShift = await _shiftShiftStore.FindByIdAsync(model.ShiftId);
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

				var isFound = await _shiftShiftTabletStore.AnyAsync(x => x.Id != model.Id &&  x.IsDeleted == false && x.ShiftDate.Date == model.ShiftDate.Date && x.ShiftId == model.ShiftId);

				if (isFound) {
					BaseResult.Success = false;
					BaseResult.Message = "این آیتم قبلا ثبت شده است";
					return BaseResult;
				}

				found.ShiftId = model.ShiftId;
				found.ShiftDate = model.ShiftDate;
				found.ShiftWorthPercent = model.ShiftWorthPercent ?? found.ShiftWorthPercent;
				found.HasLivePrograms = model.HasLivePrograms;

				var res = await _shiftShiftTabletStore.UpdateAsync(found);
				
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
				await _shiftShiftTabletStore.UpdateAsync(found);

			} catch (Exception ex) {

				BaseResult = await LogError(ex);
			}

			return BaseResult;
		}
	}
}
