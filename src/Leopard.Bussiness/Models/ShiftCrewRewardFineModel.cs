using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness {
	public class ShiftCrewRewardFineInputModel {
		public int Id { get; set; } // ID (Primary key)
		[Required(ErrorMessage =ValidationConstants.ShiftTabletCrewIdRequired)]
		public int? ShiftTabletCrewId { get; set; } // ShiftTabletCrewId

		[Required(ErrorMessage =ValidationConstants.IsRewardRequred)]
		public bool? IsReward { get; set; } // IsReward

		[Required(ErrorMessage =ValidationConstants.RewardShiftpercentageRequired)]
		public int? Shiftpercentage { get; set; } // Shiftpercentage
		[Required(ErrorMessage =ValidationConstants.RewardAmmountRequired)]
		public int? Ammount { get; set; } // Ammount
		[Required(ErrorMessage =ValidationConstants.DescriptionRequired)]
		public string Description { get; set; } // description (length: 500)
	}


	public class ShiftCrewRewardFineSearchModel : PagerViewModel {
		public string CrewName { get; set; }
		public DateTime? RewardFineDate { get; set; }
		public bool? IsRewardFine { get; set; }
		public string Description { get; set; }

		public bool? IsDeleted { get; set; }

	}


}
