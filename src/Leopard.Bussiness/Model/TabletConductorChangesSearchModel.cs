using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Model {
	public class TabletConductorChangesSearchModel: PagerViewModel {
		public int Id { get; set; } // Id (Primary key)
		public string ProgramTitle { get; set; } // ProgramTitle (length: 250)
		public string ReplacedProgramTitle { get; set; } // ReplacedProgramTitle (length: 250)
		public int? ShiftTabletId { get; set; } // ShiftTabletId

		public DateTime? CreateDateTime { get; set; } // CreateDateTime

	}
}
