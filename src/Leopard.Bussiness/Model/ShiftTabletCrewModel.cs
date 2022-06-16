using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Model {
	public class ShiftTabletCrewModel {
		public int Id { get; set; } // ID (Primary key)
		public int AgentId { get; set; } // AgentId
		public int ResourceTypeId { get; set; } // ResourceId
		public int ShiftTabletId { get; set; } // ShifTabletId
		public DateTime EntranceTime { get; set; } // EntranceTime
		public DateTime ExitTime { get; set; } // ExitTime
		
		public bool IsReplaced { get; set; } // IsReplaced
	}
}
