using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Model {
	public class ShiftProductionTypeModel {
		public int Id { get; set; } // ID (Primary key)
		[Required(ErrorMessage =ValidationConstants.TitleRquired)]
		public string Title { get; set; } // Title (length: 250)
	}
}
