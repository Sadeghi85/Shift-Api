using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Model {
	public class ShiftTabletLocationSearchModel : PagerViewModel{
		
		public int? ShiftTabletId { get; set; } // ShiftTabletID
		public int? LocationId { get; set; } // LocationID
		public string ShiftTitle { get; set; }	
		public string LocationTitle { get; set; }	



	}
}
