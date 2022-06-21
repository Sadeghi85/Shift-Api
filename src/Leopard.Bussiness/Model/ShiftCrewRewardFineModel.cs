using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Model {
	public class ShiftCrewRewardFineModel {
		public int Id { get; set; } // ID (Primary key)
		[Required(ErrorMessage ="شناسه لوح شیفت اجباری است.")]
		public int? ShiftTabletCrewId { get; set; } // ShiftTabletCrewId

		[Required(ErrorMessage ="نوع پاداش یا جریمه اجباری است 1 پاداش 0 جریمه")]
		public bool? IsReward { get; set; } // IsReward

		[Required(ErrorMessage ="درصد پاداش یا جریمه")]
		public int? Shiftpercentage { get; set; } // Shiftpercentage
		[Required(ErrorMessage ="مقدار پاداش یا جریمه")]
		public int? Ammount { get; set; } // Ammount
		[Required(ErrorMessage ="توضیحات اجباری است")]
		public string Description { get; set; } // description (length: 500)
	}
}
