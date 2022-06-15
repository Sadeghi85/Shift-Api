using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Model.ReturnModel {
	public class ShiftTabletResult {
		public int Id { get; set; } // ID (Primary key)
		public int? ShiftId { get; set; } // ShiftID
		public DateTime? ShiftDate { get; set; } // ShiftDate
		public int? ProductionTypeId { get; set; } // ProductionTypeId

		public string ShiftTitle { get; set; }
		public string ProductionTypeTitle { get; set; }
	}
}
