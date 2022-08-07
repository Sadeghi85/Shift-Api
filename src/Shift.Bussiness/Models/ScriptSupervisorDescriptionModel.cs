using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Bussiness {
	public class ScriptSupervisorDescriptionModel {

		public int Id { get; set; } // Id (Primary key)
		[Required(ErrorMessage = ValidationConstants.ShiftTabletIdRequired)]
		public int? ShiftTabletId { get; set; } // ShiftTabletId
		[Required(ErrorMessage =ValidationConstants.DescriptionRequired)]
		public string Description { get; set; } // Description (length: 1000)

	}
}
