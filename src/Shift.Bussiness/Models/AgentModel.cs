using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Bussiness {
	public class AgentSearchModel : PagerViewModel {
		public int? Id { get; set; }
		public string? Name { get; set; } // FirstName (length: 1000)
		public int? JobId { get; set; }
	}

	public class AgentViewModel {
		public int Id { get; set; }
		public string? Fullname { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>

	public class AgentByJobSearchModel : PagerViewModel {
		public int? JobId { get; set; }
		public bool? IsDeleted { get; set; }

	}
}
