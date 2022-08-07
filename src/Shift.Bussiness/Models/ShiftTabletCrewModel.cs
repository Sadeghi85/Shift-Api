using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Bussiness {
	public class ShiftTabletCrewInputModel {
		[Required(ErrorMessage = ValidationConstants.IdRequired)]
		public int Id { get; set; } // ID (Primary key)
		[Required(ErrorMessage =ValidationConstants.AgenetIdRequired)]
		public int AgentId { get; set; } // AgentId
		[Required(ErrorMessage = ValidationConstants.JobIdRquired)]
		public int JobId { get; set; } // ResourceId
		[Required(ErrorMessage = ValidationConstants.ShiftTabletIdRequired)]
		public int ShiftTabletId { get; set; } // ShifTabletId
		public TimeSpan? EntranceTime { get; set; } // EntranceTime
		public TimeSpan? ExitTime { get; set; } // ExitTime
		public bool? IsReplaced { get; set; } // IsReplaced
	}

	public class ShiftTabletCrewSearchModel : PagerViewModel {
		public int? Id { get; set; }
		public int? AgentId { get; set; } // AgentId
		public int? JobId { get; set; } // ResourceId
		public int? ShifTabletId { get; set; } // ShifTabletId
		public TimeSpan? EntranceTime { get; set; } // EntranceTime
		public TimeSpan? ExitTime { get; set; } // ExitTime
		public bool? IsReplaced { get; set; } // IsReplaced
		public string? AgentName { get; set; }
		public string? ShiftTitle { get; set; }
		public DateTime? FromDate { get; set; }
		public DateTime? ToDate { get; set; }
		public bool? IsDeleted { get; set; }
	}

	//public class ShiftTabletCrewViewModel {
	//	public int Id { get; set; } // ID (Primary key)
	//	public int AgentId { get; set; } // AgentId
	//	public int JobId { get; set; } // ResourceId
	//	public int ShifTabletId { get; set; } // ShifTabletId
	//	public DateTime EntranceTime { get; set; } // EntranceTime
	//	public DateTime ExitTime { get; set; } // ExitTime
	//	public int? CreatedBy { get; set; } // CreatedBy
	//	public int? ModifiedBy { get; set; } // ModifiedBy
	//	public DateTime? CreateDateTime { get; set; } // CreateDateTime
	//	public DateTime? LastModifiedDateTime { get; set; } // LastModifiedDateTime
	//	public bool IsReplaced { get; set; } // IsReplaced
	//	public string ShiftTitle { get; set; }
	//	public string FisrtName { get; set; }
	//	public string LastName { get; set; }
	//	public string JobTitle { get; set; }
	//}

	public class ShiftTabletCrewViewModel {

		public int Id { get; set; }
		public int AgentId { get; set; }
		public int JobId { get; set; }
		public int ShiftTabletId { get; set; }

		public string? ShiftTitle { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? JobTitle { get; set; }
		public DateTime ShiftDate { get; set; }

		public string? WeekDay {
			get {
				return ShiftDate.DayOfWeek.ToString();
			}
		}

		public string? PersianWeekDay {
			get {
				PersianDateTime persianDate = new PersianDateTime(ShiftDate);
				return persianDate.DayName;

			}
		}

		public string ShiftDatePersian {
			get {
				PersianDateTime persianDate = new PersianDateTime(ShiftDate);
				return persianDate.ToString(PersianDateTimeFormat.Date);
			}
		}

		public string? PortalTitle { get; set; }

		public string? AgentFullName {
			get {
				return FirstName + " " + LastName;
			}
		}

		public TimeSpan? EntranceTime { get; set; }
		public TimeSpan? ExitTime { get; set; }

		public TimeSpan DefaultEntranceTime { get; set; }
		public TimeSpan DefaultExitTime { get; set; }

	}

}
