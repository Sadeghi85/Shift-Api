using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Model.ReturnModel {
	public  class ShiftEmploymentDetailResult {

		public int Id { get; set; } // ID (Primary key)
		public int RequiredShift { get; set; } // RequiredShift
		public int? PerformancePaymentMultiplicationPercent { get; set; } // PerformancePaymentMultiplicationPercent
		public int PerformancePaymentAmount { get; set; } // performancePaymentAmount
		public int? LivePaymenetPercent { get; set; } // LivePaymenetPercent
		public int? LivePaymenetAmount { get; set; } // LivePaymenetAmount
		
		public int? SpecialDayPaymentAmount { get; set; } // SpecialDayPaymentAmount
		public int? SpecialDayPaymetMultiplicationPercent { get; set; } // SpecialDayPaymetMultiplicationPercent
		public int? PortalId { get; set; } // portalId
		public int? UnrequiredShiftPayment { get; set; } // UnrequiredShiftPayment
		public int? CooperationTypeId { get; set; } // CooperationTypeId
	}
}
