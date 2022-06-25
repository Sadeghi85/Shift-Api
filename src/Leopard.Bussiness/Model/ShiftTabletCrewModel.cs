using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Model {
	public class ShiftTabletCrewModel {

		public int Id { get; set; } // ID (Primary key)

		[Required(ErrorMessage =ValidationConstants.AgenetIdRequired)]
		public int AgentId { get; set; } // AgentId

		[Required(ErrorMessage = ValidationConstants.ResourceTypeIdRquired)]
		public int ResourceTypeId { get; set; } // ResourceId

		[Required(ErrorMessage = ValidationConstants.ShiftTabletIdRequred)]
		public int ShiftTabletId { get; set; } // ShifTabletId
		
		public DateTime? EntranceTime { get; set; } // EntranceTime
	
		public DateTime? ExitTime { get; set; } // ExitTime
		
		public bool IsReplaced { get; set; } // IsReplaced
	}
}
