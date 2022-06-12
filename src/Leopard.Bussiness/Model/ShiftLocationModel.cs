using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Model {
	public class ShiftLocationModel {
		public int Id { get; set; }
		public string Title { get; set; } // Title (length: 250)
		public int? PortalId { get; set; } // PortalId
	}
}
