using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Bussiness {
	public class ShiftTabletReportInputModel {
		[Required(ErrorMessage = ValidationConstants.IdRequired)]
		public int Id { get; set; } // ID (Primary key)
		[Required(ErrorMessage = ValidationConstants.ShiftTabletIdRequired)]
		public int ShiftTabletId { get; set; } // ShifTabletId
		[Required(ErrorMessage = ValidationConstants.RoleTypeIdRequired)]
		public int RoleTypeId { get; set; }
		[Required(ErrorMessage = ValidationConstants.ReportDescriptionRequired)]
		public string ReportDescription { get; set; }
	}

	public class ShiftTabletReportSearchModel : PagerViewModel {
		public int? Id { get; set; }
		public int? ShifTabletId { get; set; } // ShifTabletId
		public int? RoleTypeId { get; set; }
		public bool? IsDeleted { get; set; }
	}

	public class ShiftTabletReportViewModel {

		public int Id { get; set; }
		public int ShiftTabletId { get; set; }
		public int RoleTypeId { get; set; }
		public string? ReportDescription { get; set; }

	}

}
