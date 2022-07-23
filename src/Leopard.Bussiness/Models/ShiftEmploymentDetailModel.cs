using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness {
	public class ShiftEmploymentDetailInputModel {
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

	public class ShiftEmploymentDetailSearchModel : PagerViewModel {
		public int Id { get; set; }
		public int PortalId { get; set; }
		public int CooperationTypeId { get; set; }

		public bool? IsDeleted { get; set; }
	}

	public class ShiftEmploymentDetailViewModel {

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
