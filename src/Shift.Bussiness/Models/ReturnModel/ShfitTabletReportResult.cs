using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Bussiness.Model.ReturnModel {
	public class ShfitTabletReportResult {

		public int id { get; set; }
		public string shiftTitle { get; set; }
		public string firstName { get; set; }
		public string lastName { get; set; }
		public string jobName { get; set; }
		public DateTime shiftDate { get; set; }

		public string weekDay {
			get {
				return shiftDate.DayOfWeek.ToString();
			}
		}

		public string PersianWeekDay {
			get {
				PersianDateTime persianDate = new PersianDateTime(shiftDate);
				return persianDate.DayName;

			}
		}

		public string PersianDate {
			get {
				PersianDateTime persianDate = new PersianDateTime(shiftDate);
				return persianDate.ToString(PersianDateTimeFormat.Date);
			}
		}

		public string PortalName { get; set; }

		public string AgentFullName {
			get {
				return firstName + " " + lastName;
			}
		}

		public int AgentId { get; set; }

		public int ResourceTypeId { get; set; }

		public int ShiftTabletId { get; set; }

		public DateTime? EntranceTime { get; set; }
		public DateTime? ExitTime { get; set; }

		public TimeSpan DefaultEntranceTime { get; set; }
		public TimeSpan DefaultExitTime { get; set; }

	}
}
