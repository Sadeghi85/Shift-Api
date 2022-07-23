using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness {
	public class PortalLocationService : ServiceBase, IPortalLocationService {

		readonly private IShiftPortalLocationStore _shiftPortalLocationStore;
		readonly private IPortalStore _portalStore;
		readonly private IShiftLogStore _shiftLogStore;
		private List<Expression<Func<ShiftPortalLocation, bool>>> GetAllExpressions { get; set; } = new List<Expression<Func<ShiftPortalLocation, bool>>>();

		public PortalLocationService(IPrincipal iPrincipal, IShiftPortalLocationStore shiftPortalLocationStore, IShiftLogStore shiftLogStore, IPortalStore portalStore) : base(iPrincipal) {
			_shiftPortalLocationStore = shiftPortalLocationStore;
			_portalStore = portalStore;
			_shiftLogStore = shiftLogStore;
		}

		private BaseResult CheckAccess() {
			//if (CurrentUserPortalId != 1) {
			//	return new BaseResult() { Message= "شما به این قسمت دسترسی ندارید.", Success = false };
			//}

			return new BaseResult();
		}


		public Task<List<PortalLocationViewModel>> GetAll(PortalLocationSearchModel model, out Task<int> totalCount) {
			//var checkAccess = CheckAccess();
			//if (!checkAccess.Success) {
			//	return Task.FromResult(new List<LocationViewModel>());
			//}

			if (model.Id != 0) {
				GetAllExpressions.Add(pp => pp.Id == model.Id);
			}
			if (CurrentUserPortalId == 1 && model.PortalId != 0) {
				GetAllExpressions.Add(pp => pp.PortalId == model.PortalId);
			} else {
				GetAllExpressions.Add(pp => pp.PortalId == CurrentUserPortalId);
			}
			if (model.LocationId != 0) {
				GetAllExpressions.Add(pp => pp.LocationId == model.LocationId);
			}

			//if (GetAllExpressions.Count == 0) {
			//	GetAllExpressions.Add(pp => true);
			//}

			var type = typeof(ShiftPortalLocation);
			var property = type.GetProperty(model.orderKey ?? "id");
			var parameter = Expression.Parameter(type, "p");
			var propertyAccess = Expression.MakeMemberAccess(parameter, property);
			var orderByExp = Expression.Lambda(propertyAccess, parameter);

			var res = _shiftPortalLocationStore.GetAllWithPagingAsync(GetAllExpressions, x => new PortalLocationViewModel { Id = x.Id, PortalId = x.PortalId, LocationId = x.LocationId, PortalTitle = x.Portal.Title, LocationTitle = x.ShiftLocation.Title }, x => Expression.Quote(orderByExp), model.PageSize, model.PageNo, model.desc ? "desc" : "asc", out totalCount);

			return res;

		}

		//public int GetAllTotal() {
		//	var res = _shiftPortalLocationStore.TotalCount(GetAllExpressions);
		//	return res;
		//}

		//public List<ShiftLocation> GetShiftLocationByPortalId(int portalId) {

		//	List<ShiftLocation>? res = _shiftLocationStore.GetAll().Where(pp => pp.PortalId == portalId).ToList();
		//	return res;

		//}

		public async Task<BaseResult> Register(PortalLocationInputModel model) {
			try {
				//var checkAccess = CheckAccess();
				//if (!checkAccess.Success) {
				//	return checkAccess;
				//}

				if (CurrentUserPortalId != 1 && CurrentUserPortalId != model.PortalId) {
					BaseResult.Success = false;
					BaseResult.Message = "شما به این قسمت دسترسی ندارید";
					return BaseResult;
				}

				var found = _shiftPortalLocationStore.GetAll().Any(x => x.PortalId == model.PortalId && x.LocationId == model.LocationId);

				if (found) {
					BaseResult.Success = false;
					BaseResult.Message = "این آیتم قبلا ثبت شده است.";
				} else {

					ShiftPortalLocation shiftPortalLocation = new ShiftPortalLocation { PortalId = model.PortalId, LocationId = model.LocationId };
					var res = await _shiftPortalLocationStore.InsertAsync(shiftPortalLocation);
				}
			} catch (Exception ex) {

				ShiftLog shiftLog = new ShiftLog { Message = ex.Message + " " + ex.InnerException?.Message ?? ex.Message };

				//_shiftLogStore.ResetContext();

				var ss = await _shiftLogStore.InsertAsync(shiftLog);
				BaseResult.Success = false;
				base.BaseResult.Message = $"خطای سیستمی شماره {shiftLog.Id} لطفا به مدیر سیستم اطلاع دهید.";
			}
			return BaseResult;

		}

		public async Task<BaseResult> Update(PortalLocationInputModel model) {
			try {
				//var checkAccess = CheckAccess();
				//if (!checkAccess.Success) {
				//	return checkAccess;
				//}

				if (CurrentUserPortalId != 1 && CurrentUserPortalId != model.PortalId) {
					BaseResult.Success = false;
					BaseResult.Message = "شما به این قسمت دسترسی ندارید";
					return BaseResult;
				}

				var found = _shiftPortalLocationStore.FindById(model.Id);
				if (found == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه مورد نظر یافت نشد";

				} else {
					found.PortalId = model.PortalId;
					found.LocationId = model.LocationId;
					var res = await _shiftPortalLocationStore.Update(found);
				}
			} catch (Exception ex) {

				ShiftLog shiftLog = new ShiftLog { Message = ex.Message + " " + ex.InnerException?.Message ?? ex.Message };

				//_shiftLogStore.ResetContext();

				var ss = await _shiftLogStore.InsertAsync(shiftLog);
				BaseResult.Success = false;
				base.BaseResult.Message = $"خطای سیستمی شماره {shiftLog.Id} لطفا به مدیر سیستم اطلاع دهید.";
			}
			return BaseResult;
		}

		public async Task<BaseResult> Delete(PortalLocationInputModel model) {
			try {
				//var checkAccess = CheckAccess();
				//if (!checkAccess.Success) {
				//	return checkAccess;
				//}

				var found = _shiftPortalLocationStore.FindById(model.Id);
				if (found == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه مورد نظر یافت نشد";

				} else {

					if (CurrentUserPortalId != 1 && CurrentUserPortalId != found.PortalId) {
						BaseResult.Success = false;
						BaseResult.Message = "شما به این قسمت دسترسی ندارید";
						return BaseResult;
					}

					found.IsDeleted = true;
					var res = await _shiftPortalLocationStore.Update(found);
				}
			} catch (Exception ex) {

				ShiftLog shiftLog = new ShiftLog { Message = ex.Message + " " + ex.InnerException?.Message ?? ex.Message };

				//_shiftLogStore.ResetContext();

				var ss = await _shiftLogStore.InsertAsync(shiftLog);
				BaseResult.Success = false;
				base.BaseResult.Message = $"خطای سیستمی شماره {shiftLog.Id} لطفا به مدیر سیستم اطلاع دهید.";
			}
			return BaseResult;
		}
	}
}
