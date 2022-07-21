using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Model.ReturnModel {
	public class ShiftTabletCrewSearchResult {
		public int Id { get; set; } // ID (Primary key)
		public int AgentId { get; set; } // AgentId
		public int ResourceId { get; set; } // ResourceId
		public int ShifTabletId { get; set; } // ShifTabletId
		public DateTime EntranceTime { get; set; } // EntranceTime
		public DateTime ExitTime { get; set; } // ExitTime
		public int? CreatedBy { get; set; } // CreatedBy
		public int? ModifiedBy { get; set; } // ModifiedBy
		public DateTime? CreateDateTime { get; set; } // CreateDateTime
		public DateTime? LastModifiedDateTime { get; set; } // LastModifiedDateTime
		public bool IsReplaced { get; set; } // IsReplaced

		public string ShiftTitle{ get; set; }
		public string FisrtName { get; set; }	
		public string LastName { get; set; }
		public string ResourceTitle { get; set; }


	}
}
