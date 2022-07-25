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

		public LocationService(IPrincipal iPrincipal, IShiftLocationStore shiftLocationStore, IShiftLogStore shiftLogStore) : base(iPrincipal, shiftLogStore) {
			_shiftLocationStore = shiftLocationStore;

		}

		private BaseResult CheckAccess() {
			if (CurrentUserPortalId != 1) {
				return new BaseResult() { Message = "شما به این قسمت دسترسی ندارید", Success = false };
			}

			return new BaseResult();
		}

		public async Task<StoreViewModel<LocationViewModel>> GetAll(LocationSearchModel model) {

			var checkAccess = CheckAccess();
			if (!checkAccess.Success) {
				return new StoreViewModel<LocationViewModel>() { Result = new List<LocationViewModel>(), TotalCount = 0};
			}

			var getAllExpressions = new List<Expression<Func<ShiftLocation, bool>>>();

			if (!string.IsNullOrWhiteSpace(model.Title)) {
				getAllExpressions.Add(x => x.Title.Contains(model.Title));
			}

			if (model.Id > 0) {
				getAllExpressions.Add(x => x.Id == model.Id);
			}

			if (model.IsDeleted != null) {
				getAllExpressions.Add(x => x.IsDeleted == model.IsDeleted);
			}

			var res = await _shiftLocationStore.GetAllWithPagingAsync(getAllExpressions, x => new LocationViewModel { Id = x.Id, Title = x.Title , IsDeleted = x.IsDeleted }, model.OrderKey, model.Desc, model.PageSize, model.PageNo);

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

				var found = await _shiftLocationStore.AnyAsync(x => x.Title.ToLower() == model.Title.ToLower());

				if (found) {
					BaseResult.Success = false;
					BaseResult.Message = "این آیتم قبلا ثبت شده است";
					return BaseResult;
				} else {

					var shiftLocation = new ShiftLocation { Title = model.Title };
					await _shiftLocationStore.InsertAsync(shiftLocation);
				}
			} catch (Exception ex) {
				BaseResult = await LogError(ex);
			}

			return BaseResult;

		}

		public async Task<BaseResult> Update(LocationInputModel model) {
			try {

				var checkAccess = CheckAccess();
				if (!checkAccess.Success) {
					return checkAccess;
				}

				var found = await _shiftLocationStore.FindByIdAsync(model.Id);

				if (found == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه مورد نظر یافت نشد";
					return BaseResult;
				} else {
					found.Title = model.Title;
					await _shiftLocationStore.UpdateAsync(found);
				}
			} catch (Exception ex) {

				BaseResult = await LogError(ex);
			}

			return BaseResult;
		}

		public async Task<BaseResult> Delete(LocationInputModel model) {
			try {
				var checkAccess = CheckAccess();
				if (!checkAccess.Success) {
					return checkAccess;
				}

				var found = await _shiftLocationStore.FindByIdAsync(model.Id);

				if (found == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه مورد نظر یافت نشد";
					return BaseResult;
				} else {
					found.IsDeleted = true;
					var res = await _shiftLocationStore.UpdateAsync(found);
				}
			} catch (Exception ex) {

				BaseResult = await LogError(ex);
			}

			return BaseResult;
		}
	}
}
