using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Model {
	public class ShiftTabletSearchModel : PagerViewModel {

		public int Id { get; set; }
		public int ShiftId { get; set; } // ShiftID
		
		public int ProductionTypeId { get; set; } // ProductionTypeId
		public DateTime? FromDate { get; set; }
		public DateTime? ToDate { get; set; }
		public bool? IsDeleted { get; set; }
		public bool? HasLivePrograms { get; set; }

	}
}
