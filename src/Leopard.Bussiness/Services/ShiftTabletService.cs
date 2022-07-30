using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness {
	public class ShiftTabletService : ServiceBase, IShiftTabletService {

		readonly private IShiftShiftTabletStore _shiftShiftTabletStore;
		readonly private IShiftShiftStore _shiftShiftStore;
		readonly private IShiftLogStore _shiftLogStore;


		private List<Expression<Func<ShiftShiftTablet, bool>>> GetAllExpressions { get; set; } = new();

		public ShiftTabletService(IPrincipal iPrincipal, IShiftShiftTabletStore shiftShiftTabletStore, IShiftShiftStore shiftShiftStore, IShiftLogStore shiftLogStore) : base(iPrincipal, shiftLogStore) {
			_shiftShiftTabletStore = shiftShiftTabletStore;
			_shiftShiftStore = shiftShiftStore;
			_shiftLogStore = shiftLogStore;

		}

		//public List<ShiftShiftTablet> GetTabletShiftByPortalId(int portalId) {

		//	List<ShiftShiftTablet>? res = _shiftShiftTabletStore.GetAll().Where(pp => pp.ShiftShift.PortalId == portalId && pp.IsDeleted == false).ToList();

		//	return res;
		//}

		public async Task<StoreViewModel<ShiftTabletViewModel>> GetAll(ShiftTabletSearchModel model) {

			GetAllExpressions.Clear();

			GetAllExpressions.Add(pp => pp.ShiftShift.IsDeleted == false);

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
				GetAllExpressions.Add(pp => pp.HasLivePrograms == model.HasLivePrograms);
			}


			var res = await _shiftShiftTabletStore.GetAllWithPagingAsync(GetAllExpressions, pp => new ShiftTabletViewModel {
				Id = pp.Id,
				ShiftDate = pp.ShiftDate,
				ShiftTitle = pp.ShiftShift.Title,
				ShiftId = pp.ShiftId,
				ShiftWorthPercent = pp.ShiftWorthPercent,
				PortalId = pp.ShiftShift.PortalId,
				ShiftStartTime = pp.ShiftShift.StartTime,
				ShiftEndTime = pp.ShiftShift.EndTime,
				PortalTitle = pp.ShiftShift.Portal.Title


			}, model.OrderKey, model.Desc, model.PageSize, model.PageNo);

			return res;
		}


		public async Task<BaseResult> Register(ShiftTabletInputModel model) {

			try {

				var foundShiftTabletSameDate = await _shiftShiftTabletStore.AnyAsync(pp => pp.ShiftDate.Date == model.ShiftDate.Date && pp.ShiftId == model.ShiftId);

				var foundShift = await _shiftShiftStore.FindByIdAsync(model.ShiftId);
				if (foundShift == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شیفت مورد نظر جستجو نشد.";
					return BaseResult;
				} else if (foundShiftTabletSameDate) {

					BaseResult.Success = false;
					BaseResult.Message = "این شیفت در این روز حاص از قبل موجود است.";
					return BaseResult;
				} else {
					ShiftShiftTablet shiftTablet = new ShiftShiftTablet {
						ShiftId = model.ShiftId,
						ShiftDate = model.ShiftDate,
						ShiftWorthPercent = model.ShiftWorthPercent.Value,
						IsDeleted = false,
						HasLivePrograms = model.HasLivePrograms.Value
					};
					foundShift = await _shiftShiftStore.FindByIdAsync(model.ShiftId);
					shiftTablet.ShiftDuration = foundShift.EndTime - foundShift.StartTime;

					var res = await _shiftShiftTabletStore.InsertAsync(shiftTablet);
				}
			} catch (Exception ex) {

				ShiftLog shiftLog = new ShiftLog { Message = ex.Message + " " + ex.InnerException?.Message ?? ex.Message };

				var ss = await _shiftLogStore.InsertAsync(shiftLog);
				BaseResult.Success = false;
				base.BaseResult.Message = $"خطای سیستمی شماره {shiftLog.Id} لطفای به مدیر سیستم اطلاع دهید.";
			}

			return BaseResult;
		}

		public async Task<BaseResult> Update(ShiftTabletInputModel model) {
			try {

				var foundShiftTabletSameDate = await _shiftShiftTabletStore.AnyAsync(pp => pp.ShiftDate.Date == model.ShiftDate.Date && pp.ShiftId == model.ShiftId && pp.Id != model.Id);

				var found = await _shiftShiftTabletStore.FindByIdAsync(model.Id);

				if (found == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه مورد نظر شناسایی نشد.";
					return BaseResult;
				} else if (foundShiftTabletSameDate) {

					BaseResult.Success = false;
					BaseResult.Message = "این شیفت در تاریخ " + model.ShiftDate + " قبلا تعریف شده است";
					return BaseResult;
				} else {

					found.ShiftId = model.ShiftId;
					found.ShiftDate = model.ShiftDate;
					found.ShiftWorthPercent = model.ShiftWorthPercent.Value;
					found.HasLivePrograms = model.HasLivePrograms.Value;

					var res = await _shiftShiftTabletStore.UpdateAsync(found);
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

		public async Task<BaseResult> Delete(ShiftTabletInputModel model) {
			try {
				var found = await _shiftShiftTabletStore.FindByIdAsync(model.Id);

				if (found == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه مورد نظر شناسایی نشد.";
					return BaseResult;
				} else {

					found.IsDeleted = true;

					var res = await _shiftShiftTabletStore.UpdateAsync(found);
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
