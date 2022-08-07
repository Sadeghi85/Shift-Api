using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
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
			//var checkAccess = CheckAccess();
			//if (!checkAccess.Success) {
			//	return new StoreViewModel<LocationViewModel>() { Result = new List<LocationViewModel>(), TotalCount = 0 };
			//}

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

			var res = await _shiftLocationStore.GetAllWithPagingAsync(getAllExpressions, x => new LocationViewModel { Id = x.Id, Title = x.Title, IsDeleted = x.IsDeleted }, model.OrderKey, model.Desc, model.PageSize, model.PageNo);

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

				var isFound = await _shiftLocationStore.AnyAsync(x => x.IsDeleted == false && x.Title.ToLower() == model.Title.ToLower());

				if (isFound) {
					BaseResult.Success = false;
					BaseResult.Message = "این آیتم قبلا ثبت شده است";
					return BaseResult;
				}

				var shiftLocation = new ShiftLocation { Title = model.Title, IsDeleted = false };

				var res = await _shiftLocationStore.InsertAsync(shiftLocation);

				if (res < 0) {
					BaseResult = await LogError(new Exception("Failed to insert shiftLocation\r\n\r\n" + JsonSerializer.Serialize(shiftLocation, new JsonSerializerOptions() {
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

		public async Task<BaseResult> Update(LocationInputModel model) {
			try {

				var checkAccess = CheckAccess();
				if (!checkAccess.Success) {
					return checkAccess;
				}

				var found = await _shiftLocationStore.FindByIdAsync(x => x.Id == model.Id && x.IsDeleted == false);

				if (found == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه مورد نظر یافت نشد";
					return BaseResult;
				}

				var isFound = await _shiftLocationStore.AnyAsync(x => x.Id != model.Id && x.IsDeleted == false && x.Title.ToLower() == model.Title.ToLower());

				if (isFound) {
					BaseResult.Success = false;
					BaseResult.Message = "این آیتم قبلا ثبت شده است";
					return BaseResult;
				}

				found.Title = model.Title;

				var res = await _shiftLocationStore.UpdateAsync(found);

				if (res < 0) {
					BaseResult = await LogError(new Exception("Failed to update shiftLocation\r\n\r\n" + JsonSerializer.Serialize(found, new JsonSerializerOptions() {
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
				var checkAccess = CheckAccess();
				if (!checkAccess.Success) {
					return checkAccess;
				}

				var found = await _shiftLocationStore.FindByIdAsync(id);

				if (found == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه مورد نظر یافت نشد";
					return BaseResult;
				}

				found.IsDeleted = true;

				var res = await _shiftLocationStore.UpdateAsync(found);

				if (res < 0) {
					BaseResult = await LogError(new Exception("Failed to delete shiftLocation\r\n\r\n" + JsonSerializer.Serialize(found, new JsonSerializerOptions() {
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
