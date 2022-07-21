using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Model {
	public  class ShiftShiftJobTemplateModel {
		public int Id { get; set; } // Id (Primary key)
		[Required(ErrorMessage =ValidationConstants.ResourceTypeIdRquired)]
		public int JobId { get; set; } // JobId
		[Required(ErrorMessage =ValidationConstants.ShiftIdRequired)]
		public int ShiftId { get; set; } // ShiftId
		
		public bool IsDeleted { get; set; } // IsDeleted
	}
}
