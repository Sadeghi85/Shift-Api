using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Model {
	public class ShiftTabletLocationModel {

		public int Id { get; set; } // ID (Primary key)
		[Required(ErrorMessage =ValidationConstants.ShiftTabletIdRequred)]
		public int? ShiftTabletId { get; set; } // ShiftTabletID
		[Required(ErrorMessage =ValidationConstants.LocationIdRequired)]
		public int? LocationId { get; set; } // LocationID
		
	}
}
