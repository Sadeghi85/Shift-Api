using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness {
	public class ShiftTabletInputModel {

		public int Id { get; set; } // ID (Primary key)

		[Required(ErrorMessage =ValidationConstants.ShiftIdRequired)]
		public int ShiftId { get; set; } // ShifID

		[Required(ErrorMessage =ValidationConstants.ShiftDateRequired)]
		public DateTime ShiftDate { get; set; } // ShiftDate

		[Required(ErrorMessage =ValidationConstants.ProductionTypeIdRequired)]
		public int ProductionTypeId { get; set; } // ProductionTypeId

		public int? ShiftWorthPercent { get; set; } // ShiftWorthPercent
		public TimeSpan? ShiftTime { get; set; } // ShiftTime

		[Required(ErrorMessage =ValidationConstants.HasLiveProgramsRequired)]
		public bool? HasLivePrograms { get; set; }

	}

	public class ShiftTabletSearchModel : PagerViewModel {

		public int Id { get; set; }
		public int ShiftId { get; set; } // ShiftID

		public int ProductionTypeId { get; set; } // ProductionTypeId
		public DateTime? FromDate { get; set; }
		public DateTime? ToDate { get; set; }
		public bool? IsDeleted { get; set; }
		public bool? HasLivePrograms { get; set; }

	}

	public class ShiftTabletViewModel {
		public int Id { get; set; } // ID (Primary key)
		public int? ShiftId { get; set; } // ShiftID
		public DateTime? ShiftDate { get; set; } // ShiftDate


		public string ShiftTitle { get; set; }

		public int? ShiftWorthPercent { get; set; }

		public int PortalId { get; set; }
		public TimeSpan ShiftStartTime { get; set; }
		public TimeSpan ShiftEndTime { get; set; }

		public string PortalTitle { get; set; }
	}

}
