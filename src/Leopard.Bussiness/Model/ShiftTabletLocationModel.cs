using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Model {
	public class ShiftTabletLocationModel {

		public int Id { get; set; } // ID (Primary key)
		public int? ShiftTabletId { get; set; } // ShiftTabletID
		public int? LocationId { get; set; } // LocationID
		
	}
}
