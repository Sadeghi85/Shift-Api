using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Bussiness {
	public class PortalSearchModel : PagerViewModel {
		public int? Id { get; set; }
		public string? Title { get; set; }
	}

	public class PortalViewModel {
		public int Id { get; set; }
		public string? Title { get; set; }
	}

}
