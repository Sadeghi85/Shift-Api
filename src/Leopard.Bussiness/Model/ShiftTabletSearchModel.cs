using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Model {
	public class ShiftTabletSearchModel:PagerViewModel {

		public int Id { get; set; }
		public int ShiftId { get; set; } // ShiftID
		public DateTime? ShiftDate { get; set; } // ShiftDate
		public int ProductionTypeId { get; set; } // ProductionTypeId

	}
}
