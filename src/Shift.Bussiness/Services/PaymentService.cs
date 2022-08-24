using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shift.Repository;
using System.Linq.Expressions;
using System.Security.Principal;
using Cheetah.Utilities;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Shift.Bussiness {
	public class PaymentService : ServiceBase, IPaymentService {

		private readonly IShiftShiftTabletPaymentStore _shiftShiftTabletPaymentStore;
		private readonly IShiftShiftTabletCrewStore _shiftShiftTabletCrewStore;
		private readonly IShiftShiftTabletCrewAttendanceStore _shiftShiftTabletCrewAttendanceStore;

		public PaymentService(IPrincipal iPrincipal, IShiftLogStore shiftLogStore, IShiftShiftTabletPaymentStore shiftShiftTabletPaymentStore, IShiftShiftTabletCrewStore shiftShiftTabletCrewStore, IShiftShiftTabletCrewAttendanceStore shiftShiftTabletCrewAttendanceStore) : base(iPrincipal, shiftLogStore) {
			_shiftShiftTabletPaymentStore = shiftShiftTabletPaymentStore;
			_shiftShiftTabletCrewStore = shiftShiftTabletCrewStore;
			_shiftShiftTabletCrewAttendanceStore = shiftShiftTabletCrewAttendanceStore;
		}

		public async Task<StoreViewModel<PaymentViewModel>> GetAll(PaymentSearchModel model) {

			if (CurrentUserPortalId > 1) {
				model.PortalId = CurrentUserPortalId;
			}

			var getAllExpressions = new List<Expression<Func<ShiftShiftTabletPayment, bool>>>();


			if (model.Id > 0) {
				getAllExpressions.Add(x => x.Id == model.Id);
			}
			if (model.AgentId > 0) {
				getAllExpressions.Add(x => x.AgentId == model.AgentId);
			}
			if (model.PortalId > 0) {
				getAllExpressions.Add(x => x.PortalId == model.PortalId);
			}

			if (model.DatePersian.IsEmpty()) {
				model.DatePersian = PersianDateTime.Now.ToString(PersianDateTimeFormat.Date);
			}
			var datePersian = PersianDateTime.Parse(model.DatePersian);
			getAllExpressions.Add(x => x.YearPersian == datePersian.Year && x.MonthPersian == datePersian.Month);

			var res = await _shiftShiftTabletPaymentStore.GetAllWithPagingAsync(getAllExpressions, x => new PaymentViewModel {
				Id = x.Id,
				AgentId = x.AgentId,
				PortalId = x.PortalId,
				CalculatedPayment = x.CalculatedPayment,
				FinalPayment = x.FinalPayment,
				MandatoryShiftCount = x.MandatoryShiftCount,
				NonMandatoryShiftCount = x.NonMandatoryShiftCount,
				PortalTitle = x.Portal.Title,
				FirstName = x.SamtAgent.FirstName,
				LastName = x.SamtAgent.LastName,
			}, model.OrderKey, model.Desc, model.PageSize, model.PageNo);

			return res;

		}

		public async Task<BaseResult> CalculatePayment(PaymentSearchModel model) {
			try {

				var strDatePersian = model.DatePersian;
				var datePersian = PersianDateTime.Parse(strDatePersian);
				var firstDayDatePersian = datePersian.FirstDayOfMonth;
				var lastDayDatePersian = datePersian.LastDayOfMonth;

				var dateFrom = firstDayDatePersian.ToDateTime();
				var dateTo = lastDayDatePersian.ToDateTime();

				if (_shiftShiftTabletCrewAttendanceStore.IsAttendanceReportIncomplete(model.PortalId, dateFrom, dateTo)) {
					BaseResult.Success = false;
					BaseResult.Message = "گزارش حضور و غیاب عوامل در این بازه زمانی کامل نیست. حداقل یکی از گزارشات منشی صحنه یا ناظر پخش به ازای هر یک از عوامل لوح شیفت باید ثبت شده باشد.";
					return BaseResult;
				}

				//var found = await _shiftShiftTabletPaymentStore.FindByIdAsync(x => x.Id == model.Id);

				//if (found == null) {
				//	BaseResult.Success = false;
				//	BaseResult.Message = "شناسه مورد نظر یافت نشد";
				//	return BaseResult;
				//}
				//if (CurrentUserPortalId > 1 && CurrentUserPortalId != found.PortalId) {
				//	BaseResult.Success = false;
				//	BaseResult.Message = "شما به این قسمت دسترسی ندارید";
				//	return BaseResult;
				//}

				//found.FinalPayment = model.FinalPayment;

				//var res = await _shiftShiftTabletPaymentStore.UpdateAsync(found);

				//if (res < 0) {
				//	BaseResult = await LogError(new Exception("Failed to update shiftShiftTabletPayment\r\n\r\n" + JsonSerializer.Serialize(found, new JsonSerializerOptions() {
				//		ReferenceHandler = ReferenceHandler.IgnoreCycles,
				//		WriteIndented = true
				//	})));
				//	return BaseResult;
				//}


			} catch (Exception ex) {

				BaseResult = await LogError(ex);
			}

			return BaseResult;

		}

		public async Task<BaseResult> Update(PaymentInputModel model) {
			try {

				var found = await _shiftShiftTabletPaymentStore.FindByIdAsync(x => x.Id == model.Id);

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

				found.FinalPayment = model.FinalPayment;

				var res = await _shiftShiftTabletPaymentStore.UpdateAsync(found);

				if (res < 0) {
					BaseResult = await LogError(new Exception("Failed to update shiftShiftTabletPayment\r\n\r\n" + JsonSerializer.Serialize(found, new JsonSerializerOptions() {
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
