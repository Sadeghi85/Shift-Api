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


		private List<Expression<Func<ShiftShiftTablet, bool>>> GetAllExpressions { get; set; } = new List<Expression<Func<ShiftShiftTablet, bool>>>();
		public ShiftTabletService(IShiftShiftTabletStore shiftShiftTabletStore, IShiftShiftStore shiftShiftStore, IShiftLogStore shiftLogStore) {
			_shiftShiftTabletStore = shiftShiftTabletStore;
			_shiftShiftStore = shiftShiftStore;
			_shiftLogStore = shiftLogStore;

		}

		public List<ShiftShiftTablet> GetTabletShiftByPortalId(int portalId) {

			List<ShiftShiftTablet>? res = _shiftShiftTabletStore.GetAll().Where(pp => pp.ShiftShift.PortalId == portalId && pp.IsDeleted == false).ToList();

			return res;
		}

		public Task<List<ShiftTabletResult>>? GetAll(ShiftTabletSearchModel model) {
			GetAllExpressions.Add(pp => pp.ShiftShift.IsDeleted == false);

			//if (model.ShiftId == 0 && model.ShiftDate == null && model.ProductionTypeId == 0) {
			//	GetAllExpressions.Add(pp => true);
			//} else {

			if (model.Id != 0) {
				GetAllExpressions.Add(pp => pp.Id == model.Id);
			}
			if (model.ShiftId != 0) {
				GetAllExpressions.Add(pp => pp.ShiftId == model.ShiftId);
			}


			if (model.FromDate != null) {
				GetAllExpressions.Add(pp => pp.ShiftDate >= model.FromDate);
			}
			if (model.ToDate != null) {
				GetAllExpressions.Add(pp => pp.ShiftDate <= model.ToDate);
			}
			if (model.IsDeleted != null) {
				GetAllExpressions.Add(pp => pp.IsDeleted == model.IsDeleted);
			}
			if (model.HasLivePrograms != null) {
				GetAllExpressions.Add(pp=> pp.HasLivePrograms==model.HasLivePrograms);
			}

			//}

			Task<List<ShiftTabletResult>>? res = _shiftShiftTabletStore.GetAllWithPagingAsync(GetAllExpressions, pp => new ShiftTabletResult {
				Id = pp.Id,
				ShiftDate = pp.ShiftDate,
				ShiftTitle = pp.ShiftShift.Title,
				ShiftId = pp.ShiftId,
				ShiftWorthPercent = pp.ShiftWorthPercent,
				PortalId = pp.ShiftShift.PortalId,
				ShiftStartTime = pp.ShiftShift.StartTime,
				ShiftEndTime = pp.ShiftShift.EndTime,
				PortalName = pp.ShiftShift.Portal.Title


			}, pp => pp.Id, model.PageSize, model.PageNo, "desc");

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


				var foundShiftTabletSameDate = _shiftShiftTabletStore.GetAll().Any(pp => pp.ShiftDate.Date == model.ShiftDate.Date && pp.ShiftId == model.ShiftId);


				var foundShift = _shiftShiftStore.FindById(model.ShiftId);
				if (foundShift == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شیفت مورد نظر جستجو نشد.";
				} else if (foundShiftTabletSameDate) {

					BaseResult.Success = false;
					BaseResult.Message = "این شیفت در این روز حاص از قبل موجود است.";
				} else {
					ShiftShiftTablet shiftTablet = new ShiftShiftTablet { 
						ShiftId = model.ShiftId,
						ShiftDate = model.ShiftDate,
						ShiftWorthPercent = model.ShiftWorthPercent.Value,
						IsDeleted = false ,
						HasLivePrograms= model.HasLivePrograms.Value
					};
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

				var foundShiftTabletSameDate = _shiftShiftTabletStore.GetAll().Any(pp => pp.ShiftDate.Date == model.ShiftDate.Date && pp.ShiftId == model.ShiftId && pp.Id != model.Id);

				var found = _shiftShiftTabletStore.FindById(model.Id);

				if (found == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه مورد نظر شناسایی نشد.";
				} else if (foundShiftTabletSameDate) {

					BaseResult.Success = false;
					BaseResult.Message = "این شیفت در تاریخ " + model.ShiftDate + " قبلا تعریف شده است";
				} else {

					found.ShiftId = model.ShiftId;
					found.ShiftDate = model.ShiftDate;
					found.ShiftWorthPercent = model.ShiftWorthPercent.Value;
					found.HasLivePrograms = model.HasLivePrograms.Value;

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
