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

		private readonly IShiftPortalLocationStore _shiftPortalLocationStore;
		private readonly IPortalStore _portalStore;

		public PortalLocationService(IPrincipal iPrincipal, IShiftPortalLocationStore shiftPortalLocationStore, IShiftLogStore shiftLogStore, IPortalStore portalStore) : base(iPrincipal, shiftLogStore) {
			_shiftPortalLocationStore = shiftPortalLocationStore;
			_portalStore = portalStore;
		}


		public async Task<StoreViewModel<PortalLocationViewModel>> GetAll(PortalLocationSearchModel model) {

			var getAllExpressions = new List<Expression<Func<ShiftPortalLocation, bool>>>();

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

			if (model.LocationId > 0) {
				getAllExpressions.Add(x => x.LocationId == model.LocationId);
			}

			var res = await _shiftPortalLocationStore.GetAllWithPagingAsync(getAllExpressions, x => new PortalLocationViewModel { Id = x.Id, PortalId = x.PortalId, LocationId = x.LocationId, PortalTitle = x.Portal.Title, LocationTitle = x.ShiftLocation.Title }, model.OrderKey, model.Desc, model.PageSize, model.PageNo);

			return res;

		}

		//public List<ShiftLocation> GetShiftLocationByPortalId(int portalId) {

		//	List<ShiftLocation>? res = _shiftLocationStore.GetAll().Where(pp => pp.PortalId == portalId).ToList();
		//	return res;

		//}

		public async Task<BaseResult> Register(PortalLocationInputModel model) {
			try {

				if (CurrentUserPortalId > 1 && CurrentUserPortalId != model.PortalId) {
					BaseResult.Success = false;
					BaseResult.Message = "شما به این قسمت دسترسی ندارید";
					return BaseResult;
				}

				var found = await _shiftPortalLocationStore.AnyAsync(x => x.PortalId == model.PortalId && x.LocationId == model.LocationId);

				if (found) {
					BaseResult.Success = false;
					BaseResult.Message = "این آیتم قبلا ثبت شده است";
					return BaseResult;
				} else {

					var shiftPortalLocation = new ShiftPortalLocation { PortalId = model.PortalId, LocationId = model.LocationId };
					await _shiftPortalLocationStore.InsertAsync(shiftPortalLocation);
				}
			} catch (Exception ex) {

				BaseResult = await LogError(ex);
			}

			return BaseResult;

		}

		public async Task<BaseResult> Update(PortalLocationInputModel model) {
			try {

				if (CurrentUserPortalId > 1 && CurrentUserPortalId != model.PortalId) {
					BaseResult.Success = false;
					BaseResult.Message = "شما به این قسمت دسترسی ندارید";
					return BaseResult;
				}

				var found = await _shiftPortalLocationStore.FindByIdAsync(model.Id);
				if (found == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه مورد نظر یافت نشد";
					return BaseResult;
				} else {

					if (CurrentUserPortalId > 1 && CurrentUserPortalId != found.PortalId) {
						BaseResult.Success = false;
						BaseResult.Message = "شما به این قسمت دسترسی ندارید";
						return BaseResult;
					}

					found.PortalId = model.PortalId;
					found.LocationId = model.LocationId;
					await _shiftPortalLocationStore.UpdateAsync(found);
				}
			} catch (Exception ex) {

				BaseResult = await LogError(ex);
			}

			return BaseResult;
		}

		public async Task<BaseResult> Delete(PortalLocationInputModel model) {
			try {

				var found = await _shiftPortalLocationStore.FindByIdAsync(model.Id);

				if (found == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه مورد نظر یافت نشد";
					return BaseResult;
				} else {

					if (CurrentUserPortalId > 1 && CurrentUserPortalId != found.PortalId) {
						BaseResult.Success = false;
						BaseResult.Message = "شما به این قسمت دسترسی ندارید";
						return BaseResult;
					}

					found.IsDeleted = true;
					await _shiftPortalLocationStore.UpdateAsync(found);
				}
			} catch (Exception ex) {

				BaseResult = await LogError(ex);
			}

			return BaseResult;
		}
	}
}
