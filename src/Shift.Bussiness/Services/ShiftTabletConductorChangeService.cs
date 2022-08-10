using Shift.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text.Json;
using System.Text.Json.Serialization;
using OfficeOpenXml;
using PdfRpt.Core.Contracts;

namespace Shift.Bussiness {
	public class ShiftTabletConductorChangeService : ServiceBase, IShiftTabletConductorChangeService {

		private readonly IShiftShiftTabletStore _shiftShiftTabletStore;
		private readonly IShiftShiftTabletConductorChanxStore _shiftShiftTabletConductorChanxStore;

		public ShiftTabletConductorChangeService(IPrincipal iPrincipal, IShiftShiftTabletStore shiftShiftTabletStore, IShiftLogStore shiftLogStore, IShiftShiftTabletConductorChanxStore shiftShiftTabletConductorChanxStore) : base(iPrincipal, shiftLogStore) {

			_shiftShiftTabletStore = shiftShiftTabletStore;
			_shiftShiftTabletConductorChanxStore = shiftShiftTabletConductorChanxStore;
		}


		public async Task<StoreViewModel<ShiftTabletConductorChangeViewModel>> GetAll(ShiftTabletConductorChangeSearchModel model) {

			var getAllExpressions = new List<Expression<Func<ShiftShiftTabletConductorChanx, bool>>>();

			getAllExpressions.Add(pp => pp.ShiftShiftTablet.IsDeleted == false);

			if (CurrentUserPortalId == 1) {
				//if (model.PortalId > 0) {
				//	getAllShiftShiftJobTemplateExpressions.Add(x => x.PortalId == model.PortalId);
				//}
			} else {
				getAllExpressions.Add(x => x.ShiftShiftTablet.ShiftShift.PortalId == CurrentUserPortalId);
			}

			if (model.Id > 0) {
				getAllExpressions.Add(x => x.Id == model.Id);
			}
			if (model.ShiftTabletId > 0) {
				getAllExpressions.Add(x => x.ShiftTabletId == model.ShiftTabletId);
			}
			if (model.RoleTypeId > 0) {
				getAllExpressions.Add(x => x.RoleTypeId == model.RoleTypeId);
			}
			if (model.IsDeleted != null) {
				getAllExpressions.Add(x => x.IsDeleted == model.IsDeleted);
			}

			var res = await _shiftShiftTabletConductorChanxStore.GetAllWithPagingAsync(getAllExpressions,
				x => new ShiftTabletConductorChangeViewModel {
					Id = x.Id,
					ShiftTabletId = x.ShiftTabletId,
					RoleTypeId = x.RoleTypeId,
					Description = x.Description,
					NewProgramTitle = x.NewProgramTitle,
					OldProgramTitle = x.OldProgramTitle,
					
				},
				model.OrderKey, model.Desc, model.PageSize, model.PageNo);

			return res;
		}
		public async Task<BaseResult> Create(ShiftTabletConductorChangeInputModel model) {

			try {

				var foundShiftTablet = await _shiftShiftTabletStore.FindByIdAsync(x => x.Id == model.ShiftTabletId && x.IsDeleted == false);
				if (null == foundShiftTablet) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه لوح شیفت یافت نشد";

					return BaseResult;
				}

				if (CurrentUserPortalId > 1 && CurrentUserPortalId != foundShiftTablet.ShiftShift.PortalId) {
					BaseResult.Success = false;
					BaseResult.Message = "شما به این قسمت دسترسی ندارید";
					return BaseResult;
				}

				var shiftShiftTabletConductorChange = new ShiftShiftTabletConductorChanx {
					RoleTypeId = model.RoleTypeId,
					ShiftTabletId = model.ShiftTabletId,
					Description = model.Description,
					OldProgramTitle = model.OldProgramTitle,
					NewProgramTitle = model.NewProgramTitle,
					IsDeleted = false
				};

				var res = await _shiftShiftTabletConductorChanxStore.InsertAsync(shiftShiftTabletConductorChange);

				if (res < 0) {
					BaseResult = await LogError(new Exception("Failed to insert shiftShiftTabletConductorChange\r\n\r\n" + JsonSerializer.Serialize(shiftShiftTabletConductorChange, new JsonSerializerOptions() {
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

		public async Task<BaseResult> Update(ShiftTabletConductorChangeInputModel model) {

			try {

				var foundShiftTablet = await _shiftShiftTabletStore.FindByIdAsync(x => x.Id == model.ShiftTabletId && x.IsDeleted == false);
				if (null == foundShiftTablet) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه لوح شیفت یافت نشد";

					return BaseResult;
				}

				if (CurrentUserPortalId > 1 && CurrentUserPortalId != foundShiftTablet.ShiftShift.PortalId) {
					BaseResult.Success = false;
					BaseResult.Message = "شما به این قسمت دسترسی ندارید";
					return BaseResult;
				}

				var foundShiftTabletConductorChange = await _shiftShiftTabletConductorChanxStore.FindByIdAsync(x => x.Id == model.Id && x.IsDeleted == false && x.ShiftTabletId == model.ShiftTabletId && x.RoleTypeId == model.RoleTypeId);

				if (null == foundShiftTabletConductorChange) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه تغییر کنداکتور لوح شیفت یافت نشد";

					return BaseResult;
				}

				foundShiftTabletConductorChange.Description = model.Description;
				foundShiftTabletConductorChange.OldProgramTitle = model.OldProgramTitle;
				foundShiftTabletConductorChange.NewProgramTitle = model.NewProgramTitle;

				var res = await _shiftShiftTabletConductorChanxStore.UpdateAsync(foundShiftTabletConductorChange);

				if (res < 0) {
					BaseResult = await LogError(new Exception("Failed to update shiftShiftTabletConductorChange\r\n\r\n" + JsonSerializer.Serialize(foundShiftTabletConductorChange, new JsonSerializerOptions() {
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

				var found = await _shiftShiftTabletConductorChanxStore.FindByIdAsync(id);

				if (found == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه مورد نظر یافت نشد";
					return BaseResult;
				}

				if (CurrentUserPortalId > 1 && CurrentUserPortalId != found.ShiftShiftTablet.ShiftShift.PortalId) {
					BaseResult.Success = false;
					BaseResult.Message = "شما به این قسمت دسترسی ندارید";
					return BaseResult;
				}

				found.IsDeleted = true;

				var res = await _shiftShiftTabletConductorChanxStore.UpdateAsync(found);

				if (res < 0) {
					BaseResult = await LogError(new Exception("Failed to delete shiftShiftTabletConductorChange\r\n\r\n" + JsonSerializer.Serialize(found, new JsonSerializerOptions() {
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

		public async Task<BaseResult> Delete(string ids) {
			try {

				var _ids = JsonSerializer.Deserialize<List<int>>(ids);

				var foundConductorChanges = await _shiftShiftTabletConductorChanxStore.GetAllAsync(x => _ids.Contains(x.Id), x => x, x => x.Id);

				if (foundConductorChanges.TotalCount == 0) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه مورد نظر یافت نشد";
					return BaseResult;
				}

				foreach (var found in foundConductorChanges.Result) {
					if (CurrentUserPortalId > 1 && CurrentUserPortalId != found.ShiftShiftTablet.ShiftShift.PortalId) {
						BaseResult.Success = false;
						BaseResult.Message = "شما به این قسمت دسترسی ندارید";
						return BaseResult;
					}

					found.IsDeleted = true;

					var res = await _shiftShiftTabletConductorChanxStore.UpdateAsync(found);

					if (res < 0) {
						BaseResult = await LogError(new Exception("Failed to delete shiftShiftTabletConductorChange\r\n\r\n" + JsonSerializer.Serialize(found, new JsonSerializerOptions() {
							ReferenceHandler = ReferenceHandler.IgnoreCycles,
							WriteIndented = true
						})));
						return BaseResult;
					}
				}

			} catch (Exception ex) {

				BaseResult = await LogError(ex);
			}

			return BaseResult;

		}
	}
}
