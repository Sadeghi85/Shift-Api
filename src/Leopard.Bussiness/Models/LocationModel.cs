using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness {
	public class LocationInputModel {
		public int Id { get; set; }

		private string _title;
		[Required(ErrorMessage = ValidationConstants.TitleRquired)]
		public string Title {  // Title (length: 250)
			get {
				_title ??= "";
				return _title.Trim();
			}
			set {
				_title = value;
			}
		}
	}

	public class LocationSearchModel : PagerViewModel {
		public int Id { get; set; }

		public string Title { get; set; }
		public bool? IsDeleted { get; set; }
	}

	public class LocationViewModel {
		public int Id { get; set; }
		public string Title { get; set; }
		public int PortalId { get; set; }

		public string PortalTitle { get; set; }

	}
}
