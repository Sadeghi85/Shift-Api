using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Bussiness {
	public class LocationInputModel {

		[Required(ErrorMessage = ValidationConstants.IdRequired)]
		public int Id { get; set; }
		[Required(ErrorMessage = ValidationConstants.TitleRquired)]
		public string? Title { get; set; }// Title (length: 250)
	}

	public class LocationSearchModel : PagerViewModel {

		public int? Id { get; set; }
		public string? Title { get; set; }
		public bool? IsDeleted { get; set; }
	}

	public class LocationViewModel {
		public int Id { get; set; }
		public string? Title { get; set; }
		public bool? IsDeleted { get; set; }
	}
}
