using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Model {
	public class ShiftCrewRewardFineSearchModel: PagerViewModel {
		public string CrewName { get; set; }
		public DateTime? RewardFineDate { get; set; }
		public bool? IsRewardFine { get; set; }
		public string Description { get; set; }

		public bool? IsDeleted { get; set; }

	}
}
