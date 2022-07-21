using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Leopard.Bussiness.Model;
using Leopard.Bussiness.Model.ReturnModel;
using Leopard.Repository;
namespace Leopard.Bussiness.Services {
	public class ShiftEmploymentDetailService : ServiceBase, IShiftEmploymentDetailService {
		private IShiftEmploymentDetailStore _shiftEmploymentDetailStore;
		private IShiftLogStore _shiftLogStore;
		private IPortalStore _portalStore;
		private ISamtHrCooperationTypeStore _samtHrCooperationTypeStore;


		public ShiftEmploymentDetailService(IPrincipal iPrincipal, IShiftEmploymentDetailStore shiftEmploymentDetailStore, IShiftLogStore shiftLogStore, ISamtHrCooperationTypeStore samtHrCooperationTypeStore) : base(iPrincipal) {
			_shiftEmploymentDetailStore = shiftEmploymentDetailStore;
			_shiftLogStore = shiftLogStore;
			_samtHrCooperationTypeStore = samtHrCooperationTypeStore;
		}

		public async Task<BaseResult> Register(ShiftEmploymentDetailModel model) {


			try {

				var foundHrCooprationType = _samtHrCooperationTypeStore.FindById(model.CooperationTypeId);
				var foundPortal = _portalStore.FindById(model.PortalId);


				if (foundHrCooprationType == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه نوع همکاری جستجو نشد.";

				} else if (foundPortal == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه پورتال شناسایی نشد.";
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

		public async Task<BaseResult> Update(ShiftEmploymentDetailModel model) {

			try {
				var foundHrCooprationType = _samtHrCooperationTypeStore.FindById(model.CooperationTypeId);
				var foundPortal = _portalStore.FindById(model.PortalId);

				var foundShiftEmployeeDetail = _shiftEmploymentDetailStore.FindById(model.Id);

				if (foundShiftEmployeeDetail == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه جزئیات استخدام یافت نشد.";

				} else if (foundHrCooprationType == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه نوع همکاری جستجو نشد.";

				} else if (foundPortal == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه پورتال شناسایی نشد.";
				} else {

					foundShiftEmployeeDetail.PortalId = model.PortalId;
					foundShiftEmployeeDetail.SpecialDayPaymetMultiplicationPercent = model.SpecialDayPaymetMultiplicationPercent;
					foundShiftEmployeeDetail.PerformancePaymentMultiplicationPercent = model.PerformancePaymentMultiplicationPercent;
					foundShiftEmployeeDetail.UnrequiredShiftPayment = model.UnrequiredShiftPayment;
					foundShiftEmployeeDetail.PerformancePaymentMultiplicationPercent = model.SpecialDayPaymetMultiplicationPercent;
					foundShiftEmployeeDetail.LivePaymenetPercent= model.LivePaymenetPercent;
					foundShiftEmployeeDetail.LivePaymenetAmount= model.LivePaymenetAmount;
					foundShiftEmployeeDetail.RequiredShift = model.RequiredShift.Value;
					foundShiftEmployeeDetail.CooperationTypeId = model.CooperationTypeId;
					await _shiftEmploymentDetailStore.Update(foundShiftEmployeeDetail);

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

		public async Task<BaseResult> Delete(ShiftEmploymentDetailModel model) {

			try {
				
				var foundShiftEmployeeDetail = _shiftEmploymentDetailStore.FindById(model.Id);

				if (foundShiftEmployeeDetail == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه جزئیات استخدام یافت نشد.";

				}  else {

					foundShiftEmployeeDetail.IsDeleted = true;
					await _shiftEmploymentDetailStore.Update(foundShiftEmployeeDetail);

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

		private List<Expression<Func<ShiftEmploymentDetail, bool>>> GetAllExpressions { get; set; } = new List<Expression<Func<ShiftEmploymentDetail, bool>>>();


		public async Task<List<ShiftEmploymentDetailResult>> GetAll(ShiftEmploymentDetailSearchModel model) {

			if (model.Id!=0) {
				GetAllExpressions.Add(pp=> pp.Id ==model.Id);
			}
			if (model.CooperationTypeId!=0) {
				GetAllExpressions.Add(pp=> pp.CooperationTypeId== model.CooperationTypeId);
			}
			if (model.PortalId!=0) {
				GetAllExpressions.Add(pp=> pp.PortalId==model.PortalId);
			}

			if (model.IsDeleted != null) {
				GetAllExpressions.Add(pp=> pp.IsDeleted==model.IsDeleted);
			}

			//ShiftEmploymentDetail

			List<ShiftEmploymentDetailResult>? res = await _shiftEmploymentDetailStore.GetAllWithPagingAsync(GetAllExpressions , pp=> new ShiftEmploymentDetailResult 
			{ CooperationTypeId= pp.CooperationTypeId ,
				Id= pp.Id ,
				LivePaymenetAmount=pp.LivePaymenetAmount ,
				LivePaymenetPercent= pp.LivePaymenetPercent ,
				PerformancePaymentAmount=pp.PerformancePaymentAmount , 
				PerformancePaymentMultiplicationPercent =pp.PerformancePaymentMultiplicationPercent ,
				PortalId=pp.PortalId ,
				RequiredShift= pp.RequiredShift,
				SpecialDayPaymentAmount= pp.SpecialDayPaymentAmount,
				SpecialDayPaymetMultiplicationPercent= pp.SpecialDayPaymetMultiplicationPercent,
				UnrequiredShiftPayment= pp.UnrequiredShiftPayment
			},pp=> pp.Id , model.PageSize , model.PageNo , "desc");

			return res;

		}

		public int  GetAllCount() {
			var res = _shiftEmploymentDetailStore.TotalCount(GetAllExpressions);
			return res;
		}

	}
}
