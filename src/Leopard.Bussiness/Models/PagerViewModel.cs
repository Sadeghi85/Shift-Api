using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness {
	public class PagerViewModel {

		public int PageNo { get; set; } = 1;
		public int PageSize { get; set; } = 10;
		public string orderKey { get; set; }
		public bool desc { get; set; }
	}
}
