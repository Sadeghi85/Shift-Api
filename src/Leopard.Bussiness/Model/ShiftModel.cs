using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Model {
	public class ShiftModel {
		public int Id { get; set; } // ID (Primary key)
		public string Title { get; set; } // Title (length: 250)
		public int? PortalId { get; set; } // ProtalId
		public int? ShiftType { get; set; } // ShiftType

		public TimeSpan? StartTime { get; set; } // StartTime
		public TimeSpan? EndTime { get; set; } // EndTime
	}
}
