using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Model {
	public class TabletConductorChangesModel {
		public int Id { get; set; } // Id (Primary key)
		
		[Required(ErrorMessage ="نام برنامه اجباری است.")]
		public string ProgramTitle { get; set; } // ProgramTitle (length: 250)
		
		[Required(ErrorMessage ="نام برنامه جایگزین شونده اجباری است.")]
		public string ReplacedProgramTitle { get; set; } // ReplacedProgramTitle (length: 250)
		
		[Required(ErrorMessage ="شناسه لوح شیفت اجباری است.")]
		public int? ShiftTabletId { get; set; } // ShiftTabletId
		
		[Required(ErrorMessage ="توضیحات اجباری است.")]
		public string Description { get; set; } // Description (length: 1000)
	}
}
