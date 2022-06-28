using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Model {
	public  class ShiftNeededResourceModel {
		public int Id { get; set; } // Id (Primary key)
		[Required(ErrorMessage =ValidationConstants.ResourceTypeIdRquired)]
		public int ResourceTypeId { get; set; } // ResourceTypeId
		[Required(ErrorMessage =ValidationConstants.ShiftIdRequired)]
		public int ShiftId { get; set; } // ShiftId
		
		public bool IsDeleted { get; set; } // IsDeleted
	}
}
