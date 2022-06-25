using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Model {
	public class ShiftLocationModel {
		public int Id { get; set; }
		[Required(ErrorMessage =ValidationConstants.TitleRquired)]
		public string Title { get; set; } // Title (length: 250)
		[Required(ErrorMessage =ValidationConstants.PortalIdRequired)]
		public int? PortalId { get; set; } // PortalId
	}
}
