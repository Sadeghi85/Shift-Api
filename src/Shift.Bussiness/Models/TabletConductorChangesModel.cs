using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Bussiness {
	public class TabletConductorChangesModel {
		public int Id { get; set; } // Id (Primary key)
		
		[Required(ErrorMessage =ValidationConstants.ProgramTitleRequired)]
		public string ProgramTitle { get; set; } // ProgramTitle (length: 250)
		
		[Required(ErrorMessage =ValidationConstants.ReplacedProgramTitleRequired)]
		public string ReplacedProgramTitle { get; set; } // ReplacedProgramTitle (length: 250)
		
		[Required(ErrorMessage =ValidationConstants.ShiftTabletIdRequired)]
		public int? ShiftTabletId { get; set; } // ShiftTabletId
		
		[Required(ErrorMessage =ValidationConstants.DescriptionRequired)]
		public string Description { get; set; } // Description (length: 1000)
	}
}