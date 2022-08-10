using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Bussiness {
	public class ShiftTabletConductorChangeInputModel {
		[Required(ErrorMessage = ValidationConstants.IdRequired)]
		public int Id { get; set; } // ID (Primary key)
		[Required(ErrorMessage = ValidationConstants.ShiftTabletIdRequired)]
		public int ShiftTabletId { get; set; } // ShiftTabletId
		[Required(ErrorMessage = ValidationConstants.RoleTypeIdRequired)]
		public int RoleTypeId { get; set; }
		[Required(ErrorMessage = ValidationConstants.TitleRequired)]
		public string OldProgramTitle { get; set; }
		[Required(ErrorMessage = ValidationConstants.TitleRequired)]
		public string NewProgramTitle { get; set; }
		public string? Description { get; set; }
	}

	public class ShiftTabletConductorChangeSearchModel : PagerViewModel {
		public int? Id { get; set; }
		public int? ShiftTabletId { get; set; } // ShiftTabletId
		public int? RoleTypeId { get; set; }
		public bool? IsDeleted { get; set; }
	}

	public class ShiftTabletConductorChangeViewModel {

		public int Id { get; set; }
		public int ShiftTabletId { get; set; }
		public int RoleTypeId { get; set; }
		public string? Description { get; set; }
		public string? OldProgramTitle { get; set; }
		public string? NewProgramTitle { get; set; }

	}

}
