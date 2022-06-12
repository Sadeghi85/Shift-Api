using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Model {
	public class ShiftTabletModel {
		public int Id { get; set; } // ID (Primary key)
		public int? ShiftId { get; set; } // ShifID
		public DateTime? ShiftDate { get; set; } // ShiftDate
		public int? ProductionTypeId { get; set; } // ProductionTypeId

		public int? ShiftWorthPercent { get; set; } // ShiftWorthPercent
		public TimeSpan? ShiftTime { get; set; } // ShiftTime
	}
}
