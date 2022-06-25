using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Model {
	public class ShiftModel {
		public int Id { get; set; } // ID (Primary key)
		[Required(ErrorMessage =ValidationConstants.TitleRquired)]
		public string Title { get; set; } // Title (length: 250)

		[Required(ErrorMessage =ValidationConstants.PortalIdRequired)]
		public int? PortalId { get; set; } // ProtalId
		[Range(1,2 , ErrorMessage =ValidationConstants.ShiftTypeRequired) ]
		public int? ShiftType { get; set; } // ShiftType

		[Required(ErrorMessage =ValidationConstants.StartTimeRequired)]
		public TimeSpan? StartTime { get; set; } // StartTime
		[Required(ErrorMessage =ValidationConstants.EndTimeRequired)]
		public TimeSpan? EndTime { get; set; } // EndTime
	}
}
