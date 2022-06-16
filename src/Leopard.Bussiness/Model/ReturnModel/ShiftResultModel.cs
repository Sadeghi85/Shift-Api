using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Model.ReturnModel {
	public class ShiftResultModel  {

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
