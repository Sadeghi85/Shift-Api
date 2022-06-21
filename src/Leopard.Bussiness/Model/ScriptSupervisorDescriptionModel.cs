using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Model {
	public class ScriptSupervisorDescriptionModel {

		public int Id { get; set; } // Id (Primary key)
		[Required(ErrorMessage ="شناسه لوح شیفت اجباری است")]
		public int? ShiftTabletId { get; set; } // ShiftTabletId
		[Required(ErrorMessage ="توضیحات اجباری است.")]
		public string Description { get; set; } // Description (length: 1000)

	}
}
