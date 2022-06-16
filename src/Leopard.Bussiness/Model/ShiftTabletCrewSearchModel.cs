using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Model {
	public class ShiftTabletCrewSearchModel : PagerViewModel{
		public int AgentId { get; set; } // AgentId
		public int ResourceTypeId { get; set; } // ResourceId
		public int ShifTabletId { get; set; } // ShifTabletId
		public DateTime? EntranceTime { get; set; } // EntranceTime
		public DateTime? ExitTime { get; set; } // ExitTime
		
		public bool? IsReplaced { get; set; } // IsReplaced

		public string AgentName { get; set; }
		public string ShiftTitle { get; set; }
		public DateTime? FromDate { get; set; }	
		public DateTime? ToDate { get; set; }

		
	}
}
