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
	public class ShiftTabletService : BaseService, IShiftTabletService {

		readonly private IShiftShiftTabletStore _shiftShiftTabletStore;
		readonly private IShiftShiftStore _shiftShiftStore;
		readonly private IShiftLogStore _shiftLogStore;
		readonly private IShiftProductionTypeStore _shiftProductionTypeStore;

		private List<Expression<Func<ShiftShiftTablet, bool>>> GetAllExpressions { get; set; } = new List<Expression<Func<ShiftShiftTablet, bool>>>();
		public ShiftTabletService(IShiftShiftTabletStore shiftShiftTabletStore, IShiftShiftStore shiftShiftStore, IShiftLogStore shiftLogStore, IShiftProductionTypeStore shiftProductionTypeStore) {
			_shiftShiftTabletStore = shiftShiftTabletStore;
			_shiftShiftStore = shiftShiftStore;
			_shiftLogStore = shiftLogStore;
			_shiftProductionTypeStore = shiftProductionTypeStore;
		}

		public List<ShiftShiftTablet> GetTabletShiftByPortalId(int portalId) {

			List<ShiftShiftTablet>? res = _shiftShiftTabletStore.GetAll().Where(pp => pp.ShiftShift.PortalId == portalId && pp.IsDeleted == false).ToList();

			return res;
		}

		public Task<List<ShiftTabletResult>>? GetAll(ShiftTabletSearchModel model) {
			GetAllExpressions.Add(pp => pp.IsDeleted != true);

			//if (model.ShiftId == 0 && model.ShiftDate == null && model.ProductionTypeId == 0) {
			//	GetAllExpressions.Add(pp => true);
			//} else {

			if (model.Id != 0) {
				GetAllExpressions.Add(pp => pp.Id == model.Id);
			}

			if (model.ShiftId != 0) {
				GetAllExpressions.Add(pp => pp.ShiftId == model.ShiftId);
			}
			if (model.ShiftDate != null) {
				GetAllExpressions.Add(pp => pp.ShiftDate == model.ShiftDate);
			}
			if (model.ProductionTypeId != 0) {
				GetAllExpressions.Add((pp) => pp.ProductionTypeId == model.ProductionTypeId);
			}
			//}

			Task<List<ShiftTabletResult>>? res = _shiftShiftTabletStore.GetAllWithPagingAsync(GetAllExpressions, pp => new ShiftTabletResult { Id = pp.Id, ProductionTypeId = pp.ProductionTypeId, ProductionTypeTitle = pp.ShiftProductionType.Title, ShiftDate = pp.ShiftDate, ShiftTitle = pp.ShiftShift.Title, ShiftId = pp.ShiftId, ShiftWorthPercent = pp.ShiftWorthPercent }, pp => pp.Id, model.PageSize, model.PageNo, "desc");

			//IQueryable<ShiftShiftTablet>? res = _shiftShiftTabletStore.GetAll();
			//_shiftShiftStore.GetAllAsync


			return res;
		}

		public int GetShiftTabletCount() {

			var res = _shiftShiftTabletStore.TotalCount(GetAllExpressions);
			return res;

		}



		public IQueryable<ShiftShiftTablet> GetAll() {
			return _shiftShiftTabletStore.GetAll();
		}


		public async Task<BaseResult> RegisterShiftTablet(ShiftTabletModel model) {

			try {
				var foundProductionType = _shiftProductionTypeStore.FindById(model.ProductionTypeId);

				var foundShiftTabletSameDate = _shiftShiftTabletStore.GetAll().Any(pp => pp.ShiftDate.Value.Date == model.ShiftDate.Value.Date && pp.ShiftId == model.ShiftId);


				var foundShift = _shiftShiftStore.FindById(model.ShiftId);
				if (foundShift == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شیفت مورد نظر جستجو نشد.";
				} else if (foundShiftTabletSameDate) {

					BaseResult.Success = false;
					BaseResult.Message = "این شیفت در این روز حاص از قبل موجود است.";
				} else if (foundProductionType == null) {
					BaseResult.Success = false;
					BaseResult.Message = "نوع تولید شیفت یافت نشد.";
				} else {
					ShiftShiftTablet shiftTablet = new ShiftShiftTablet { ShiftId = model.ShiftId, ShiftDate = model.ShiftDate, ProductionTypeId = model.ProductionTypeId, ShiftWorthPercent = model.ShiftWorthPercent, IsDeleted = false };
					foundShift = _shiftShiftStore.FindById(model.ShiftId);
					shiftTablet.ShiftTime = foundShift.EndTime - foundShift.StartTime;

					int res = await _shiftShiftTabletStore.InsertAsync(shiftTablet);
				}
			} catch (Exception ex) {

				ShiftLog shiftLog = new ShiftLog { Message = ex.Message + " " + ex.InnerException?.Message ?? ex.Message };
				//ex.InnerException?.Message ?? ex.Message;
				//ShiftLog shiftLog = new ShiftLog { Message = ex.Message };


				//_shiftLogStore.ResetContext();

				var ss = await _shiftLogStore.InsertAsync(shiftLog);
				BaseResult.Success = false;
				base.BaseResult.Message = $"خطای سیستمی شماره {shiftLog.Id} لطفای به مدیر سیستم اطلاع دهید.";
			}
			return BaseResult;
		}

		public async Task<BaseResult> UpdateShifTablet(ShiftTabletModel model) {


			try {

				var foundShiftTabletSameDate = _shiftShiftTabletStore.GetAll().Any(pp => pp.ShiftDate.Value.Date == model.ShiftDate.Value.Date && pp.ShiftId == model.ShiftId);

				var found = _shiftShiftTabletStore.FindById(model.Id);

				if (found == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه مورد نظر شناسایی نشد.";
				} else if (foundShiftTabletSameDate) {

					BaseResult.Success = false;
					BaseResult.Message = "این شیفت در این روز حاص از قبل موجود است.";
				} else {

					found.ShiftId = model.ShiftId;
					found.ShiftDate = model.ShiftDate;
					found.ProductionTypeId = model.ProductionTypeId;
					found.ShiftWorthPercent = model.ShiftWorthPercent;

					var res = await _shiftShiftTabletStore.Update(found);
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

		public async Task<BaseResult> Delete(ShiftTabletModel model) {
			try {
				var found = _shiftShiftTabletStore.FindById(model.Id);

				if (found == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه مورد نظر شناسایی نشد.";
				} else {

					found.IsDeleted = true;

					var res = await _shiftShiftTabletStore.Update(found);
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
