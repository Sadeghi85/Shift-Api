using Leopard.Bussiness.Model;
using Leopard.Bussiness.Model.ReturnModel;
using Leopard.Bussiness.Services.Interface;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Services {
	public class ShiftLocationService : BaseService, IShiftLocationService {

		readonly private IShiftLocationStore _shiftLocationStore;
		readonly private IShiftLogStore _shiftLogStore;
		readonly private IPortalStore _portalStore;
		private List<Expression<Func<ShiftLocation, bool>>> GetAllExpressions { get; set; } = new List<Expression<Func<ShiftLocation, bool>>>();

		public ShiftLocationService(IShiftLocationStore shiftLocationStore, IShiftLogStore shiftLogStore, IPortalStore portalStore) {
			_shiftLocationStore = shiftLocationStore;
			_shiftLogStore = shiftLogStore;
			_portalStore = portalStore;
		}


		public Task<List<ShiftLocationReturnModel>> GetAll(ShiftLocationSearchModel model) {



			if (!string.IsNullOrWhiteSpace(model.Title)) {
				GetAllExpressions.Add(pp => pp.Title.Contains(model.Title));
			}
			if (model.PortalId != 0) {
				GetAllExpressions.Add(pp => pp.PortalId == model.PortalId);
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

			//GetAllExpressions.Add(pp => pp.IsDeleted != true);

			//var resCnt = _shiftLocationStore.TotalCount(Expressions);

			var res = _shiftLocationStore.GetAllWithPagingAsync(GetAllExpressions, pp => new ShiftLocationReturnModel { Id = pp.Id, PortalId = pp.PortalId, Title = pp.Title, PortalTitle = pp.Portal.Title }, pp => pp.Id, model.PageSize, model.PageNo, "desc");

			return res;

		}

		public int GetAllTotal() {
			var res = _shiftLocationStore.TotalCount(GetAllExpressions);
			return res;
		}

		public List<ShiftLocation> GetShiftLocationByPortalId(int portalId) {

			List<ShiftLocation>? res = _shiftLocationStore.GetAll().Where(pp => pp.PortalId == portalId).ToList();
			return res;

		}

		public async Task<BaseResult> RegisterShiftLocation(ShiftLocationModel model) {

			try {

				var foundPortalTitle = _shiftLocationStore.GetAll().Any(pp => pp.PortalId == model.PortalId && pp.Title == model.Title);
				var foundPortal = _portalStore.FindById(model.PortalId);
				if (foundPortal == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه پورتال یافت نشد.";
				} else if (foundPortalTitle) {
					BaseResult.Success = false;
					BaseResult.Message = "این آیتم قبلا ثبت شده است.";
				} else {

					ShiftLocation shiftLocation = new ShiftLocation { Title = model.Title, PortalId = model.PortalId.Value };
					var res = await _shiftLocationStore.InsertAsync(shiftLocation);
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

		public async Task<BaseResult> Update(ShiftLocationModel model) {

			try {
				var found = _shiftLocationStore.FindById(model.Id);
				if (found == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه مورد نظر یافت نشد";

				} else {
					found.Title = model.Title;
					found.PortalId = model.PortalId.Value;
					var res = await _shiftLocationStore.Update(found);
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

		public async Task<BaseResult> Delete(ShiftLocationModel model) {
			try {
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
				base.BaseResult.Message = $"خطای سیستمی شماره {shiftLog.Id} لطفای به مدیر سیستم اطلاع دهید.";
			}
			return BaseResult;
		}
	}
}
