using Leopard.Bussiness;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness {
	public class ShiftService : ServiceBase, IShiftService {

		private readonly IShiftShiftStore _shiftShiftStore;
		private readonly IPortalStore _portalStore;
		private readonly IShiftLogStore _shiftLogStore;
		private readonly IShiftShiftJobTemplateStore _shiftShiftJobTemplateStore;
		private readonly ISamtResourceTypeStore _samtResourceTypeStore;

		private List<Expression<Func<ShiftShift, bool>>> GetAllExpressions { get; set; } = new();

		private List<Expression<Func<ShiftShiftJobTemplate, bool>>> GetAllShiftShiftJobTemplateExpressions { get; set; } = new();

		public ShiftService(IPrincipal iPrincipal, IShiftShiftStore shiftShiftStore, IPortalStore portalStore, IShiftLogStore shiftLogStore, IShiftShiftJobTemplateStore shiftShiftJobTemplateStore, ISamtResourceTypeStore samtResourceTypeStore) : base(iPrincipal, shiftLogStore) {
			_shiftShiftStore = shiftShiftStore;
			_portalStore = portalStore;
			_shiftLogStore = shiftLogStore;
			_shiftShiftJobTemplateStore = shiftShiftJobTemplateStore;
			_samtResourceTypeStore = samtResourceTypeStore;
		}

		public async Task<BaseResult> Delete(ShiftInputModel model) {

			try {
				var found = await _shiftShiftStore.FindByIdAsync(model.Id);
				if (found == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه مورد نظر شناسایی نشد.";
					return BaseResult;
				} else {
					found.IsDeleted = true;
					var res = await _shiftShiftStore.UpdateAsync(found);
				}
			} catch (Exception ex) {

				ShiftLog shiftLog = new ShiftLog { Message = ex.Message + " " + ex.InnerException?.Message ?? ex.Message };

				//_shiftLogStore.ResetContext();

				var ss = await _shiftLogStore.InsertAsync(shiftLog);
				BaseResult.Success = false;
				base.BaseResult.Message = $"خطای سیستمی شماره {shiftLog.Id} لطفای به مدیر سیستم اطلاع دهید.";
			}

			return BaseResult;

		}

		public async Task<StoreViewModel<ShiftShift>> FindByPortalId(int portalId) {

			var res = await _shiftShiftStore.GetAllAsync(pp => pp.PortalId == portalId, x => x, x => x.Id);

			return res;

		}

		public async Task<StoreViewModel<ShiftViewModel>> GetAll(ShiftSearchModel model) {

			GetAllExpressions.Clear();

			if (model.PortalId != 0) {
				GetAllExpressions.Add(pp => pp.PortalId == model.PortalId);
			}
			if (!string.IsNullOrWhiteSpace(model.Title)) {
				GetAllExpressions.Add(pp => pp.Title.Contains(model.Title));
			}
			if (model.ShiftType != 0) {
				GetAllExpressions.Add(pp => pp.ShiftTypeId == model.ShiftType);
			}
			if (model.Id != 0) {
				GetAllExpressions.Add(pp => pp.Id == model.Id);
			}
			if (model.IsDeleted != null) {
				GetAllExpressions.Add(pp => pp.IsDeleted == model.IsDeleted.Value);
			}

			GetAllExpressions.Add(pp => pp.IsDeleted != true);

			var res = await _shiftShiftStore.GetAllWithPagingAsync(GetAllExpressions, pp => new ShiftViewModel { Id = pp.Id, Title = pp.Title, PortalTitle = pp.Portal.Title, PortalId = pp.PortalId, EndTime = pp.EndTime, StartTime = pp.StartTime, ShiftTypeId = pp.ShiftTypeId, ShiftTypeTitle = GetShiftTypeTitleByShiftTypeId(pp.ShiftTypeId) }, pp => pp.Id, model.Desc, model.PageSize, model.PageNo);

			return res;
		}

		private static string GetShiftTypeTitleByShiftTypeId(int? ShiftTypeId) {

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

		public async Task<BaseResult> Register(ShiftInputModel model) {

			var foundPortal = await _portalStore.FindByIdAsync(model.PortalId);
			if (null == foundPortal) {
				BaseResult.Success = false;
				BaseResult.Message = "شناسه پورتال شناسایی نشد.";

				return BaseResult;
			}

			try {

				var found = await _shiftShiftStore.AnyAsync(x => x.Title == model.Title);
				if (found) {
					BaseResult.Success = false;
					BaseResult.Message = "نام انتخاب شده برای شیفت تکراری است.";

					return BaseResult;
				}

				found = _shiftShiftStore.CheckTimeOverlap(0, model.PortalId, model.ShiftTypeId, model.StartTime, model.EndTime);
				if (found) {
					BaseResult.Success = false;
					BaseResult.Message = "بازه زمانی انتخاب شده با موارد ثبت شده تداخل دارد.";

					return BaseResult;
				}

				ShiftShift shiftShift = new ShiftShift { Title = model.Title, PortalId = model.PortalId, ShiftTypeId = model.ShiftTypeId, StartTime = model.StartTime, EndTime = model.EndTime, IsDeleted = false };

				await _shiftShiftStore.InsertAsync(shiftShift);


			} catch (Exception ex) {

				ShiftLog shiftLog = new ShiftLog { Message = ex.Message + Environment.NewLine + ex.InnerException?.Message + Environment.NewLine + ex.StackTrace ?? "" };

				//_shiftLogStore.ResetContext();

				await _shiftLogStore.InsertAsync(shiftLog);
				BaseResult.Success = false;
				base.BaseResult.Message = $"خطای سیستمی شماره {shiftLog.Id} لطفا به مدیر سیستم اطلاع دهید.";

				return BaseResult;
			}


			return BaseResult;

		}

		private bool IsInShiftType(int shiftType) {
			List<int> shiftTypes = new List<int>() { 1, 2 };
			var res = shiftTypes.Contains(shiftType);
			return res;
		}

		public async Task<BaseResult> Update(ShiftInputModel model) {

			try {
				var foundShift = await _shiftShiftStore.FindByIdAsync(model.Id);

				if (null == foundShift) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه مورد نظر جستجو نشد.";

					return BaseResult;
				}

				var foundPortal = await _portalStore.FindByIdAsync(model.PortalId);
				if (null == foundPortal) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه پورتال شناسایی نشد.";

					return BaseResult;
				}

				var found = await _shiftShiftStore.AnyAsync(x => x.Title == model.Title && x.Id != model.Id);
				if (found) {
					BaseResult.Success = false;
					BaseResult.Message = "نام انتخاب شده برای شیفت تکراری است.";

					return BaseResult;
				}

				found = _shiftShiftStore.CheckTimeOverlap(model.Id, model.PortalId, model.ShiftTypeId, model.StartTime, model.EndTime);
				if (found) {
					BaseResult.Success = false;
					BaseResult.Message = "بازه زمانی انتخاب شده با موارد ثبت شده تداخل دارد.";

					return BaseResult;
				}

				foundShift.Title = model.Title;
				foundShift.StartTime = model.StartTime;
				foundShift.EndTime = model.EndTime;
				foundShift.ShiftTypeId = model.ShiftTypeId;
				foundShift.PortalId = model.PortalId;
				await _shiftShiftStore.UpdateAsync(foundShift);


			} catch (Exception ex) {

				ShiftLog shiftLog = new ShiftLog { Message = ex.Message + Environment.NewLine + ex.InnerException?.Message + Environment.NewLine + ex.StackTrace ?? "" };

				//_shiftLogStore.ResetContext();

				await _shiftLogStore.InsertAsync(shiftLog);
				BaseResult.Success = false;
				base.BaseResult.Message = $"خطای سیستمی شماره {shiftLog.Id} لطفا به مدیر سیستم اطلاع دهید.";

				return BaseResult;
			}
			return BaseResult;
		}

		public async Task<BaseResult> RegisterShiftJobTemplate(ShiftShiftJobTemplateInputModel model) {
			try {
				var foundResourceShift = await _shiftShiftJobTemplateStore.AnyAsync(pp => pp.ShiftId == model.ShiftId && pp.JobId == model.JobId);
				var foundShift = await _shiftShiftStore.FindByIdAsync(model.ShiftId);
				var foundResource = await _samtResourceTypeStore.FindByIdAsync(model.JobId);

				if (foundResourceShift) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه سمت برای شیفت قبلا ثبت شده است.";
					return BaseResult;
				} else if (foundResource == null) {
					BaseResult.Success = false;
					BaseResult.Message = "سمت مورد نظر یافت نشد.";
					return BaseResult;
				} else if (foundShift == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شیفت مورد نظر یافت نشد.";
					return BaseResult;
				} else {
					await _shiftShiftJobTemplateStore.InsertAsync(new ShiftShiftJobTemplate {
						IsDeleted = false,
						JobId = model.JobId,
						ShiftId = model.ShiftId
					});
				}
			} catch (Exception ex) {

				ShiftLog shiftLog = new ShiftLog { Message = ex.Message + " " + ex.InnerException?.Message ?? ex.Message };

				//_shiftLogStore.ResetContext();

				var ss = await _shiftLogStore.InsertAsync(shiftLog);
				BaseResult.Success = false;
				base.BaseResult.Message = $"خطای سیستمی شماره {shiftLog.Id} لطفای به مدیر سیستم اطلاع دهید.";
			}

			return BaseResult;
		}

		public async Task<BaseResult> UpdateShiftJobTemplate(ShiftShiftJobTemplateInputModel model) {

			try {
				var founded = await _shiftShiftJobTemplateStore.FindByIdAsync(model.Id);
				var foundResourceShift = await _shiftShiftJobTemplateStore.AnyAsync(pp => pp.ShiftId == model.ShiftId && pp.JobId == model.JobId);
				var foundShift = await _shiftShiftStore.FindByIdAsync(model.ShiftId);
				var foundResource = await _samtResourceTypeStore.FindByIdAsync(model.JobId);

				if (foundResourceShift) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه سمت برای شیفت قبلا ثبت شده است.";
					return BaseResult;
				} else if (foundResource == null) {
					BaseResult.Success = false;
					BaseResult.Message = "سمت مورد نظر یافت نشد.";
					return BaseResult;
				} else if (foundShift == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شیفت مورد نظر یافت نشد.";
					return BaseResult;
				} else if (founded == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه مورد نظر یافت نشد.";
					return BaseResult;
				} else {
					founded.ShiftId = model.ShiftId;
					founded.JobId = model.JobId;
					await _shiftShiftJobTemplateStore.UpdateAsync(founded);
				}
			} catch (Exception ex) {

				ShiftLog shiftLog = new ShiftLog { Message = ex.Message + " " + ex.InnerException?.Message ?? ex.Message };

				//_shiftLogStore.ResetContext();

				var ss = await _shiftLogStore.InsertAsync(shiftLog);
				BaseResult.Success = false;
				base.BaseResult.Message = $"خطای سیستمی شماره {shiftLog.Id} لطفای به مدیر سیستم اطلاع دهید.";
			}

			return BaseResult;
		}

		public async Task<BaseResult> DeleteShiftJobTemplate(ShiftShiftJobTemplateInputModel model) {

			try {
				var founded = await _shiftShiftJobTemplateStore.FindByIdAsync(model.Id);


				if (founded == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه مورد نظر یافت نشد.";
					return BaseResult;
				} else {
					founded.IsDeleted = true;

					await _shiftShiftJobTemplateStore.UpdateAsync(founded);
				}
			} catch (Exception ex) {

				ShiftLog shiftLog = new ShiftLog { Message = ex.Message + " " + ex.InnerException?.Message ?? ex.Message };

				//_shiftLogStore.ResetContext();

				var ss = await _shiftLogStore.InsertAsync(shiftLog);
				BaseResult.Success = false;
				base.BaseResult.Message = $"خطای سیستمی شماره {shiftLog.Id} لطفای به مدیر سیستم اطلاع دهید.";
			}

			return BaseResult;
		}

		public async Task<StoreViewModel<ShiftShiftJobTemplateViewModel>> GetAllShiftJobTemplates(ShiftShiftJobTemplateSearchModel model) {

			GetAllShiftShiftJobTemplateExpressions.Clear();

			if (model.ShiftId != 0) {
				GetAllShiftShiftJobTemplateExpressions.Add(pp => pp.ShiftId == model.ShiftId);
			}
			if (model.JobId != 0) {
				GetAllShiftShiftJobTemplateExpressions.Add(pp => pp.JobId == model.JobId);
			}
			if (model.IsDeleted != null) {
				GetAllShiftShiftJobTemplateExpressions.Add(pp => pp.IsDeleted == model.IsDeleted);
			}

			var res = await _shiftShiftJobTemplateStore.GetAllWithPagingAsync(GetAllShiftShiftJobTemplateExpressions, pp =>
			new ShiftShiftJobTemplateViewModel {
				Id = pp.Id,
				ResourceId = pp.JobId,
				JobTitle = pp.SamtResourceType.Title,
				ShiftId = pp.ShiftId,
				ShiftTitle = pp.ShiftShift.Title
			}, pp => pp.Id, model.Desc, model.PageSize, model.PageNo);

			return res;
		}

	}
}
