using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Model {
	public class ShiftEmploymentDetailModel {
		public int Id { get; set; } // ID (Primary key)

		[Required(ErrorMessage = ValidationConstants.RequiredShiftRequired)]
		public int? RequiredShift { get; set; } // RequiredShift
		public int? PerformancePaymentMultiplicationPercent { get; set; } // PerformancePaymentMultiplicationPercent
		public int PerformancePaymentAmount { get; set; } // performancePaymentAmount
		public int? LivePaymenetPercent { get; set; } // LivePaymenetPercent
		public int? LivePaymenetAmount { get; set; } // LivePaymenetAmount
				
		
		public int? SpecialDayPaymentAmount { get; set; } // SpecialDayPaymentAmount
		public int? SpecialDayPaymetMultiplicationPercent { get; set; } // SpecialDayPaymetMultiplicationPercent

		[Required(ErrorMessage =ValidationConstants.PortalIdRequired)]
		public int? PortalId { get; set; } // portalId
		[Required(ErrorMessage =ValidationConstants.UnrequiredShiftPaymentRequired)]
		public int? UnrequiredShiftPayment { get; set; } // UnrequiredShiftPayment
		[Required(ErrorMessage =ValidationConstants.CooperationTypeIdRequired)]
		public int? CooperationTypeId { get; set; } // CooperationTypeId
		public bool IsDeleted { get; set; } // IsDeleted
	}
}
