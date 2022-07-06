using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Leopard.Bussiness.Model;
using Leopard.Bussiness.Model.ReturnModel;
using Leopard.Repository;
namespace Leopard.Bussiness.Services {
	public class ShiftEmploymentDetailService:BaseService {
		private IShiftEmploymentDetailStore _shiftEmploymentDetailStore;
		private IShiftLogStore _shiftLogStore;
		private IPortalStore _portalStore;	

		public ShiftEmploymentDetailService(IShiftEmploymentDetailStore shiftEmploymentDetailStore, IShiftLogStore shiftLogStore) {
			_shiftEmploymentDetailStore = shiftEmploymentDetailStore;
			_shiftLogStore = shiftLogStore;
		}

		public async Task<BaseResult> Register(ShiftEmploymentDetailModel model) {


			try {
				if (true) { } else {
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



	}
}
