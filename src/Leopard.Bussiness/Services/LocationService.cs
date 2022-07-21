using Leopard.Bussiness.Model;
using Leopard.Bussiness.Model.ReturnModel;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness {
	public class LocationService : ServiceBase, ILocationService {

		readonly private IShiftLocationStore _shiftLocationStore;
		readonly private IShiftLogStore _shiftLogStore;
		private List<Expression<Func<ShiftLocation, bool>>> GetAllExpressions { get; set; } = new List<Expression<Func<ShiftLocation, bool>>>();

		public LocationService(IPrincipal iPrincipal, IShiftLocationStore shiftLocationStore, IShiftLogStore shiftLogStore) : base(iPrincipal) {
			_shiftLocationStore = shiftLocationStore;
			_shiftLogStore = shiftLogStore;

		}

		private BaseResult CheckAccess() {
			if (CurrentUserPortalId != 1) {
				return new BaseResult() { Message= "شما به این قسمت دسترسی ندارید.", Success = false };
			}

			return new BaseResult();
		}


		public Task<List<LocationViewModel>> GetAll(LocationSearchModel model) {
			var checkAccess = CheckAccess();
			if (!checkAccess.Success) {
				return Task.FromResult(new List<LocationViewModel>());
			}

			if (!string.IsNullOrWhiteSpace(model.Title)) {
				GetAllExpressions.Add(pp => pp.Title.Contains(model.Title));
			}
			if (model.Id != 0) {
				GetAllExpressions.Add(pp => pp.Id == model.Id);
			}
			if (model.IsDeleted != null) {
				GetAllExpressions.Add(pp => pp.IsDeleted == model.IsDeleted);
			}

			//if (GetAllExpressions.Count == 0) {
			//	GetAllExpressions.Add(pp => true);
			//}

			var res = _shiftLocationStore.GetAllWithPagingAsync(GetAllExpressions, pp => new LocationViewModel { Id = pp.Id, Title = pp.Title }, pp => pp.Id, model.PageSize, model.PageNo, "desc");

			return res;

		}

		public int GetAllTotal() {
			var res = _shiftLocationStore.TotalCount(GetAllExpressions);
			return res;
		}

		//public List<ShiftLocation> GetShiftLocationByPortalId(int portalId) {

		//	List<ShiftLocation>? res = _shiftLocationStore.GetAll().Where(pp => pp.PortalId == portalId).ToList();
		//	return res;

		//}

		public async Task<BaseResult> Register(LocationInputModel model) {
			try {
				var checkAccess = CheckAccess();
				if (!checkAccess.Success) {
					return checkAccess;
				}

				var found = _shiftLocationStore.GetAll().Any(pp => pp.Title == model.Title);
				//var foundPortal = _portalStore.FindById(model.PortalId);
				//if (foundPortal == null) {
				//	BaseResult.Success = false;
				//	BaseResult.Message = "شناسه پورتال یافت نشد.";
				//} else 
				
				if (found) {
					BaseResult.Success = false;
					BaseResult.Message = "این آیتم قبلا ثبت شده است.";
				} else {

					ShiftLocation shiftLocation = new ShiftLocation { Title = model.Title };
					var res = await _shiftLocationStore.InsertAsync(shiftLocation);
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

		public async Task<BaseResult> Update(LocationInputModel model) {
			try {
				var checkAccess = CheckAccess();
				if (!checkAccess.Success) {
					return checkAccess;
				}

				var found = _shiftLocationStore.FindById(model.Id);
				if (found == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه مورد نظر یافت نشد";

				} else {
					found.Title = model.Title;
					var res = await _shiftLocationStore.Update(found);
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

		public async Task<BaseResult> Delete(LocationInputModel model) {
			try {
				var checkAccess = CheckAccess();
				if (!checkAccess.Success) {
					return checkAccess;
				}

				var found = _shiftLocationStore.FindById(model.Id);
				if (found == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه مورد نظر یافت نشد";

				} else {
					found.IsDeleted = true;
					var res = await _shiftLocationStore.Update(found);
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
