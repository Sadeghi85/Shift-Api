using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Model {
	public class ShiftCrewRewardFineModel {
		public int Id { get; set; } // ID (Primary key)
		public int? ShiftTabletCrewId { get; set; } // ShiftTabletCrewId
		public bool? IsReward { get; set; } // IsReward
		public int? Shiftpercentage { get; set; } // Shiftpercentage
		public int? Ammount { get; set; } // Ammount
		public string Description { get; set; } // description (length: 500)
	}
}
