using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Bussiness {
	public class MonetarySettingInputModel {

		[Required(ErrorMessage = ValidationConstants.IdRequired)]
		public int Id { get; set; }
		[Required(ErrorMessage = ValidationConstants.PortalIdRequired)]
		public int PortalId { get; set; }
		
		public int? CooperationTypeId { get; set; }
		public int? JobId { get; set; }
		public int? MandatoryShiftCount { get; set; }
		public decimal? NonMandatoryShiftWage { get; set; }

		
	}

	public class MonetarySettingSearchModel : PagerViewModel {
		public int? Id { get; set; }
		public int? PortalId { get; set; }
		public int? CooperationTypeId { get; set; }
		public int? JobId { get; set; }
		public bool? IsDeleted { get; set; }
		public string? MandatoryField { get; set; }
	}

	public class MonetarySettingViewModel {
		public int Id { get; set; }
		public int PortalId { get; set; }

		public int? CooperationTypeId { get; set; }
		public int? JobId { get; set; }
		public int? MandatoryShiftCount { get; set; }
		public decimal? NonMandatoryShiftWage { get; set; }

		public string? PortalTitle { get; set; }
		public string? CooperationTypeTitle { get; set; }
		public string? JobTitle { get; set; }

	}
}
