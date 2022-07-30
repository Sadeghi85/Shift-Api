using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Leopard.Repository;
namespace Leopard.Bussiness {
	public class ShiftEmploymentDetailService : ServiceBase, IShiftEmploymentDetailService {
		private readonly IShiftEmploymentDetailStore _shiftEmploymentDetailStore;
		private readonly IShiftLogStore _shiftLogStore;
		private readonly IPortalStore _portalStore;
		private readonly ISamtHrCooperationTypeStore _samtHrCooperationTypeStore;

		private List<Expression<Func<ShiftEmploymentDetail, bool>>> GetAllExpressions { get; set; } = new();

		public ShiftEmploymentDetailService(IPrincipal iPrincipal, IShiftEmploymentDetailStore shiftEmploymentDetailStore, IShiftLogStore shiftLogStore, ISamtHrCooperationTypeStore samtHrCooperationTypeStore, IPortalStore portalStore) : base(iPrincipal, shiftLogStore) {
			_shiftEmploymentDetailStore = shiftEmploymentDetailStore;
			_shiftLogStore = shiftLogStore;
			_samtHrCooperationTypeStore = samtHrCooperationTypeStore;
			_portalStore = portalStore;
		}

		public async Task<BaseResult> Register(ShiftEmploymentDetailInputModel model) {

			try {

				var foundHrCooprationType = await _samtHrCooperationTypeStore.FindByIdAsync(model.CooperationTypeId);
				var foundPortal = await _portalStore.FindByIdAsync(model.PortalId);


				if (foundHrCooprationType == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه نوع همکاری جستجو نشد.";
					return BaseResult;
				} else if (foundPortal == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه پورتال شناسایی نشد.";
					return BaseResult;
				} else {
					//_mapper.Map<>
					ShiftEmploymentDetail employmentDetail =
						new ShiftEmploymentDetail {
							CooperationTypeId = model.CooperationTypeId,
							IsDeleted = false,
							LivePaymenetAmount = model.LivePaymenetAmount,
							LivePaymenetPercent = model.LivePaymenetPercent,
							PerformancePaymentAmount = model.PerformancePaymentAmount,
							PerformancePaymentMultiplicationPercent = model.PerformancePaymentMultiplicationPercent,
							PortalId = model.PortalId,
							RequiredShift = model.RequiredShift.Value,
							SpecialDayPaymentAmount = model.SpecialDayPaymentAmount,
							SpecialDayPaymetMultiplicationPercent = model.SpecialDayPaymetMultiplicationPercent,
							UnrequiredShiftPayment = model.UnrequiredShiftPayment.Value
						};
					await _shiftEmploymentDetailStore.InsertAsync(employmentDetail);

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

		public async Task<BaseResult> Update(ShiftEmploymentDetailInputModel model) {

			try {
				var foundHrCooprationType = await _samtHrCooperationTypeStore.FindByIdAsync(model.CooperationTypeId);
				var foundPortal = await _portalStore.FindByIdAsync(model.PortalId);

				var foundShiftEmployeeDetail = await _shiftEmploymentDetailStore.FindByIdAsync(model.Id);

				if (foundShiftEmployeeDetail == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه جزئیات استخدام یافت نشد.";
					return BaseResult;
				} else if (foundHrCooprationType == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه نوع همکاری جستجو نشد.";
					return BaseResult;
				} else if (foundPortal == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه پورتال شناسایی نشد.";
					return BaseResult;
				} else {

					foundShiftEmployeeDetail.PortalId = model.PortalId;
					foundShiftEmployeeDetail.SpecialDayPaymetMultiplicationPercent = model.SpecialDayPaymetMultiplicationPercent;
					foundShiftEmployeeDetail.PerformancePaymentMultiplicationPercent = model.PerformancePaymentMultiplicationPercent;
					foundShiftEmployeeDetail.UnrequiredShiftPayment = model.UnrequiredShiftPayment;
					foundShiftEmployeeDetail.PerformancePaymentMultiplicationPercent = model.SpecialDayPaymetMultiplicationPercent;
					foundShiftEmployeeDetail.LivePaymenetPercent = model.LivePaymenetPercent;
					foundShiftEmployeeDetail.LivePaymenetAmount = model.LivePaymenetAmount;
					foundShiftEmployeeDetail.RequiredShift = model.RequiredShift.Value;
					foundShiftEmployeeDetail.CooperationTypeId = model.CooperationTypeId;

					await _shiftEmploymentDetailStore.UpdateAsync(foundShiftEmployeeDetail);

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

		public async Task<BaseResult> Delete(ShiftEmploymentDetailInputModel model) {

			try {

				var foundShiftEmployeeDetail = await _shiftEmploymentDetailStore.FindByIdAsync(model.Id);

				if (foundShiftEmployeeDetail == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه جزئیات استخدام یافت نشد.";
					return BaseResult;
				} else {

					foundShiftEmployeeDetail.IsDeleted = true;
					await _shiftEmploymentDetailStore.UpdateAsync(foundShiftEmployeeDetail);

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

		public async Task<StoreViewModel<ShiftEmploymentDetailViewModel>> GetAll(ShiftEmploymentDetailSearchModel model) {

			GetAllExpressions.Clear();

			if (model.Id != 0) {
				GetAllExpressions.Add(pp => pp.Id == model.Id);
			}
			if (model.CooperationTypeId != 0) {
				GetAllExpressions.Add(pp => pp.CooperationTypeId == model.CooperationTypeId);
			}
			if (model.PortalId != 0) {
				GetAllExpressions.Add(pp => pp.PortalId == model.PortalId);
			}

			if (model.IsDeleted != null) {
				GetAllExpressions.Add(pp => pp.IsDeleted == model.IsDeleted);
			}

			//ShiftEmploymentDetail

			var res = await _shiftEmploymentDetailStore.GetAllWithPagingAsync(GetAllExpressions, pp => new ShiftEmploymentDetailViewModel {
				CooperationTypeId = pp.CooperationTypeId,
				Id = pp.Id,
				LivePaymenetAmount = pp.LivePaymenetAmount,
				LivePaymenetPercent = pp.LivePaymenetPercent,
				PerformancePaymentAmount = pp.PerformancePaymentAmount,
				PerformancePaymentMultiplicationPercent = pp.PerformancePaymentMultiplicationPercent,
				PortalId = pp.PortalId,
				RequiredShift = pp.RequiredShift,
				SpecialDayPaymentAmount = pp.SpecialDayPaymentAmount,
				SpecialDayPaymetMultiplicationPercent = pp.SpecialDayPaymetMultiplicationPercent,
				UnrequiredShiftPayment = pp.UnrequiredShiftPayment
			}, pp => pp.Id, model.Desc, model.PageSize, model.PageNo);

			return res;

		}



	}
}
