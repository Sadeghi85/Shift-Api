using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Bussiness {
	public class JobSearchModel : PagerViewModel {
		public int? Id { get; set; }
		public string? Title { get; set; }
		public bool? IsDeleted { get; set; }
	}

	public class JobViewModel {
		public int Id { get; set; }
		public string? Title { get; set; }
	}
}
