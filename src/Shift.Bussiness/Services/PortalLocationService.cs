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
	public class PortalLocationService : ServiceBase, IPortalLocationService {

		private readonly IShiftPortalLocationStore _shiftPortalLocationStore;
		private readonly IPortalStore _portalStore;
		private readonly IShiftLocationStore _shiftLocationStore;

		public PortalLocationService(IPrincipal iPrincipal, IShiftPortalLocationStore shiftPortalLocationStore, IShiftLogStore shiftLogStore, IPortalStore portalStore, IShiftLocationStore shiftLocationStore) : base(iPrincipal, shiftLogStore) {
			_shiftPortalLocationStore = shiftPortalLocationStore;
			_portalStore = portalStore;
			_shiftLocationStore = shiftLocationStore;
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
			if (model.IsDeleted != null) {
				getAllExpressions.Add(x => x.IsDeleted == model.IsDeleted);
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
					BaseResult.Message = "?????? ???? ?????? ???????? ???????????? ????????????";
					return BaseResult;
				}

				var foundPortal = await _portalStore.FindByIdAsync(model.PortalId);
				if (null == foundPortal) {
					BaseResult.Success = false;
					BaseResult.Message = "?????????? ???????????? ???????? ??????";

					return BaseResult;
				}

				var foundLocation = await _shiftLocationStore.FindByIdAsync(x => x.Id == model.LocationId && x.IsDeleted == false);
				if (null == foundLocation) {
					BaseResult.Success = false;
					BaseResult.Message = "?????????? ???????????? ???????? ??????";

					return BaseResult;
				}

				var isFound = await _shiftPortalLocationStore.AnyAsync(x => x.IsDeleted == false && x.PortalId == model.PortalId && x.LocationId == model.LocationId);

				if (isFound) {
					BaseResult.Success = false;
					BaseResult.Message = "?????? ???????? ???????? ?????? ?????? ??????";
					return BaseResult;
				}


				var shiftPortalLocation = new ShiftPortalLocation { PortalId = model.PortalId, LocationId = model.LocationId };

				_shiftPortalLocationStore.Insert(shiftPortalLocation);

				var res = await _shiftPortalLocationStore.SaveChangesAsync();

				if (res < 0) {
					BaseResult = await LogError(new Exception("Failed to insert shiftPortalLocation\r\n\r\n" + JsonSerializer.Serialize(shiftPortalLocation, new JsonSerializerOptions() {
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

		public async Task<BaseResult> Update(PortalLocationInputModel model) {
			try {

				if (CurrentUserPortalId > 1 && CurrentUserPortalId != model.PortalId) {
					BaseResult.Success = false;
					BaseResult.Message = "?????? ???? ?????? ???????? ???????????? ????????????";
					return BaseResult;
				}

				var found = await _shiftPortalLocationStore.FindByIdAsync(x => x.Id == model.Id && x.IsDeleted == false);
				if (found == null) {
					BaseResult.Success = false;
					BaseResult.Message = "?????????? ???????? ?????? ???????? ??????";
					return BaseResult;
				}
				if (CurrentUserPortalId > 1 && CurrentUserPortalId != found.PortalId) {
					BaseResult.Success = false;
					BaseResult.Message = "?????? ???? ?????? ???????? ???????????? ????????????";
					return BaseResult;
				}

				var foundPortal = await _portalStore.FindByIdAsync(model.PortalId);
				if (null == foundPortal) {
					BaseResult.Success = false;
					BaseResult.Message = "?????????? ???????????? ???????? ??????";

					return BaseResult;
				}

				var foundLocation = await _shiftLocationStore.FindByIdAsync(x => x.Id == model.LocationId && x.IsDeleted == false);
				if (null == foundLocation) {
					BaseResult.Success = false;
					BaseResult.Message = "?????????? ???????????? ???????? ??????";

					return BaseResult;
				}

				var isFound = await _shiftPortalLocationStore.AnyAsync(x => x.Id != model.Id && x.IsDeleted == false && x.PortalId == model.PortalId && x.LocationId == model.LocationId);

				if (isFound) {
					BaseResult.Success = false;
					BaseResult.Message = "?????? ???????? ???????? ?????? ?????? ??????";
					return BaseResult;
				}

				found.PortalId = model.PortalId;
				found.LocationId = model.LocationId;

				_shiftPortalLocationStore.Update(found);

				var res = await _shiftPortalLocationStore.SaveChangesAsync();

				if (res < 0) {
					BaseResult = await LogError(new Exception("Failed to update shiftPortalLocation\r\n\r\n" + JsonSerializer.Serialize(found, new JsonSerializerOptions() {
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

				var found = await _shiftPortalLocationStore.FindByIdAsync(id);

				if (found == null) {
					BaseResult.Success = false;
					BaseResult.Message = "?????????? ???????? ?????? ???????? ??????";
					return BaseResult;
				}

				if (CurrentUserPortalId > 1 && CurrentUserPortalId != found.PortalId) {
					BaseResult.Success = false;
					BaseResult.Message = "?????? ???? ?????? ???????? ???????????? ????????????";
					return BaseResult;
				}

				found.IsDeleted = true;

				_shiftPortalLocationStore.Update(found);

				var res = await _shiftPortalLocationStore.SaveChangesAsync();

				if (res < 0) {
					BaseResult = await LogError(new Exception("Failed to dalete shiftPortalLocation\r\n\r\n" + JsonSerializer.Serialize(found, new JsonSerializerOptions() {
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
