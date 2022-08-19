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
	public class MonetarySettingService : ServiceBase, IMonetarySettingService {

		private readonly IPortalStore _portalStore;
		private readonly ISamtHrCooperationTypeStore _samtHrCooperationTypeStore;
		private readonly ISamtResourceTypeStore _samtResourceTypeStore;
		private readonly IShiftMonetarySettingStore _shiftMonetarySettingStore;
		public MonetarySettingService(IPrincipal iPrincipal, IShiftLogStore shiftLogStore, IPortalStore portalStore, ISamtHrCooperationTypeStore samtHrCooperationTypeStore, ISamtResourceTypeStore samtResourceTypeStore, IShiftMonetarySettingStore shiftMonetarySettingStore) : base(iPrincipal, shiftLogStore) {
			_portalStore = portalStore;
			_samtHrCooperationTypeStore = samtHrCooperationTypeStore;
			_samtResourceTypeStore = samtResourceTypeStore;
			_shiftMonetarySettingStore = shiftMonetarySettingStore;
		}

		public async Task<StoreViewModel<MonetarySettingViewModel>> GetAll(MonetarySettingSearchModel model) {

			var getAllExpressions = new List<Expression<Func<ShiftMonetarySetting, bool>>>();

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
			if (model.CooperationTypeId > 0) {
				getAllExpressions.Add(x => x.CooperationTypeId == model.CooperationTypeId);
			}
			if (model.JobId > 0) {
				getAllExpressions.Add(x => x.CooperationTypeId == model.JobId);
			}
			if (model.IsDeleted != null) {
				getAllExpressions.Add(x => x.IsDeleted == model.IsDeleted);
			}

			switch (model.MandatoryField) {
				case "NonMandatoryShiftWage":
					getAllExpressions.Add(x => x.NonMandatoryShiftWage != null);
					break;
				case "MandatoryShiftCount":
					getAllExpressions.Add(x => x.MandatoryShiftCount != null);
					break;
				default:
					break;
			}

			//if (model.MandatoryField != null) {
			//	getAllExpressions.Add(x => {
			//		var prop = x.GetType().GetProperty(model.MandatoryField);
			//		if (prop == null) {
			//			return true;
			//		}

			//		return prop.GetValue(x) != null;
			//	}
			//	);
			//}

			var res = await _shiftMonetarySettingStore.GetAllWithPagingAsync(getAllExpressions, x => new MonetarySettingViewModel { Id = x.Id, PortalId = x.PortalId, CooperationTypeId = x.CooperationTypeId, JobId = x.JobId, MandatoryShiftCount = x.MandatoryShiftCount, NonMandatoryShiftWage = x.NonMandatoryShiftWage, PortalTitle = x.Portal.Title, CooperationTypeTitle = x.SamtHrCooperationType.HrCooperationTypeTitle, JobTitle = x.SamtResourceType.Title }, model.OrderKey, model.Desc, model.PageSize, model.PageNo);

			return res;

		}

		public async Task<BaseResult> CreateOrUpdate(MonetarySettingInputModel model) {
			try {

				if (CurrentUserPortalId > 1 && CurrentUserPortalId != model.PortalId) {
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

				if (null != model.CooperationTypeId) {
					var foundCooperationType = await _samtHrCooperationTypeStore.FindByIdAsync(model.CooperationTypeId);
					if (null == foundCooperationType) {
						BaseResult.Success = false;
						BaseResult.Message = "شناسه نحوه همکاری یافت نشد";

						return BaseResult;
					}
				}

				if (null != model.JobId) {
					var foundJob = await _samtResourceTypeStore.FindByIdAsync(model.JobId);
					if (null == foundJob) {
						BaseResult.Success = false;
						BaseResult.Message = "شناسه عنوان شغلی یافت نشد";

						return BaseResult;
					}
				}


				ShiftMonetarySetting? shiftMonetarySetting;
				if (model.Id == 0) {
					shiftMonetarySetting = await _shiftMonetarySettingStore.FindByIdAsync(x => x.IsDeleted == false && x.PortalId == model.PortalId && x.JobId == model.JobId && x.CooperationTypeId == model.CooperationTypeId);
				} else {
					shiftMonetarySetting = await _shiftMonetarySettingStore.FindByIdAsync(x => x.Id == model.Id && x.IsDeleted == false);
				}

				if (null != shiftMonetarySetting) {
					if (CurrentUserPortalId > 1 && CurrentUserPortalId != shiftMonetarySetting.PortalId) {
						BaseResult.Success = false;
						BaseResult.Message = "شما به این قسمت دسترسی ندارید";
						return BaseResult;
					}
				}
				


				var res = -1;

				if (null != shiftMonetarySetting) {

					shiftMonetarySetting.PortalId = model.PortalId;
					shiftMonetarySetting.CooperationTypeId = model.CooperationTypeId;
					shiftMonetarySetting.JobId = model.JobId;

					shiftMonetarySetting.MandatoryShiftCount = model.MandatoryShiftCount;
					shiftMonetarySetting.NonMandatoryShiftWage = model.NonMandatoryShiftWage;

					res = await _shiftMonetarySettingStore.UpdateAsync(shiftMonetarySetting);
				} else {
					shiftMonetarySetting = new ShiftMonetarySetting {
						PortalId = model.PortalId,
						CooperationTypeId = model.CooperationTypeId,
						JobId = model.JobId,
						MandatoryShiftCount = model.MandatoryShiftCount,
						NonMandatoryShiftWage = model.NonMandatoryShiftWage,
						IsDeleted = false
					};

					res = await _shiftMonetarySettingStore.InsertAsync(shiftMonetarySetting);
				}

				if (res < 0) {
					BaseResult = await LogError(new Exception("Failed to insert/update shiftMonetarySetting\r\n\r\n" + JsonSerializer.Serialize(shiftMonetarySetting, new JsonSerializerOptions() {
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

				var found = await _shiftMonetarySettingStore.FindByIdAsync(id);

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

				var res = await _shiftMonetarySettingStore.UpdateAsync(found);

				if (res < 0) {
					BaseResult = await LogError(new Exception("Failed to delete shiftMonetarySetting\r\n\r\n" + JsonSerializer.Serialize(found, new JsonSerializerOptions() {
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

				var foundMonetarySettings = await _shiftMonetarySettingStore.GetAllAsync(x => _ids.Contains(x.Id), x => x, x => x.Id);

				if (foundMonetarySettings.TotalCount == 0) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه مورد نظر یافت نشد";
					return BaseResult;
				}

				foreach (var found in foundMonetarySettings.Result) {
					if (CurrentUserPortalId > 1 && CurrentUserPortalId != found.PortalId) {
						BaseResult.Success = false;
						BaseResult.Message = "شما به این قسمت دسترسی ندارید";
						return BaseResult;
					}

					found.IsDeleted = true;

					var res = await _shiftMonetarySettingStore.UpdateAsync(found);

					if (res < 0) {
						BaseResult = await LogError(new Exception("Failed to delete shiftMonetarySetting\r\n\r\n" + JsonSerializer.Serialize(found, new JsonSerializerOptions() {
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
