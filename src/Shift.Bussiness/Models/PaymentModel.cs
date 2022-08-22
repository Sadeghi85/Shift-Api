using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Bussiness {

	public class PaymentInputModel {

		[Required(ErrorMessage = ValidationConstants.IdRequired)]
		public int Id { get; set; }
		
		public decimal? FinalPayment { get; set; }// Title (length: 250)
	}

	public class PaymentSearchModel : PagerViewModel {
		public int? Id { get; set; }
		public int? AgentId { get; set; }
		public int? PortalId { get; set; }
		public string? DatePersian { get; set; }
		public bool? IsDeleted { get; set; }
	}

	public class PaymentViewModel {
		public int Id { get; set; }
		public int AgentId { get; set; }
		public int PortalId { get; set; }

		public int? MandatoryShiftCount { get; set; }
		public int NonMandatoryShiftCount { get; set; }
		public decimal CalculatedPayment { get; set; }
		public decimal? FinalPayment { get; set; }



		public string? PortalTitle { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }

		public string? AgentFullName {
			get {
				return FirstName + " " + LastName;
			}
		}
	}
}
