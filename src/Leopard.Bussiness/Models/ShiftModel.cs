using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness {
	public class ShiftInputModel {
		public int Id { get; set; } // ID (Primary key)
		[Required(ErrorMessage =ValidationConstants.TitleRquired)]
		public string Title { get; set; } // Title (length: 250)

		[Required(ErrorMessage =ValidationConstants.PortalIdRequired)]
		public int PortalId { get; set; } // ProtalId
		[Range(1,2 , ErrorMessage =ValidationConstants.ShiftTypeRequired) ]
		public int ShiftTypeId { get; set; } // ShiftTypeId

		[Required(ErrorMessage =ValidationConstants.StartTimeRequired)]
		public TimeSpan StartTime { get; set; } // StartTime
		[Required(ErrorMessage =ValidationConstants.EndTimeRequired)]
		public TimeSpan EndTime { get; set; } // EndTime
	}

	public class ShiftSearchModel : PagerViewModel {

		private string _title;

		public string Title {
			get {
				_title = _title ?? "";
				return _title.Trim();
			}
			set {
				_title = value;
			}
		}
		public int PortalId { get; set; }
		public int? ShiftType { get; set; } // ShiftType
		public int Id { get; set; }
		public bool? IsDeleted { get; set; }



	}

	public class ShiftViewModel {

		public int Id { get; set; } // ID (Primary key)
		public string Title { get; set; } // Title (length: 250)
		public int? PortalId { get; set; } // PortalId
		public TimeSpan? StartTime { get; set; } // StartTime
		public TimeSpan? EndTime { get; set; } // EndTime
		public string PortalTitle { get; set; }
		public int? ShiftTypeId { get; set; }
		public string ShiftTypeTitle { get; set; }
	}
}
