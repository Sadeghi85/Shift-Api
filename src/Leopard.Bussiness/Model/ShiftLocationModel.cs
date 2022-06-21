using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Model {
	public class ShiftLocationModel {
		public int Id { get; set; }
		[Required(ErrorMessage ="عنوان محل برگزاری اجباری است.")]
		public string Title { get; set; } // Title (length: 250)
		[Required(ErrorMessage ="شناسه پورتال اجباری است.")]
		public int? PortalId { get; set; } // PortalId
	}
}
