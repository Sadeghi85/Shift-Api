using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Bussiness {
	public class PagerViewModel {

		public int PageNo { get; set; } = 0;
		public int PageSize { get; set; } = 10;
		public string OrderKey { get; set; } = "id";
		public bool Desc { get; set; } = true;
	}
}
