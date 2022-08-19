using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Bussiness {
	public class CooperationTypeSearchModel : PagerViewModel {
		public int? Id { get; set; }
		public string? Title { get; set; }
	}

	public class CooperationTypeViewModel {
		public int Id { get; set; }
		public string? Title { get; set; }
	}

}
