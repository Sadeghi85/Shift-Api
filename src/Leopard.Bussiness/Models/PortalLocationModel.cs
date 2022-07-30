using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness {
	public class PortalLocationInputModel {

		[Required(ErrorMessage = ValidationConstants.IdRequired)]
		public int Id { get; set; }
		[Required(ErrorMessage = ValidationConstants.PortalIdRequired)]
		public int PortalId { get; set; }
		[Required(ErrorMessage = ValidationConstants.LocationIdRequired)]
		public int LocationId { get; set; }
	}

	public class PortalLocationSearchModel : PagerViewModel {
		public int? Id { get; set; }
		public int? PortalId { get; set; }
		public int? LocationId { get; set; }
		public bool? IsDeleted { get; set; }
	}

	public class PortalLocationViewModel {
		public int Id { get; set; }
		public int PortalId { get; set; }
		public int LocationId { get; set; }

		public string? PortalTitle { get; set; }
		public string? LocationTitle { get; set; }

	}
}
