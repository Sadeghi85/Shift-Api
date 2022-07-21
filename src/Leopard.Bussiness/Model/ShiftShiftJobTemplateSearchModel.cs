using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Model {
	public class ShiftShiftJobTemplateSearchModel : PagerViewModel {
		public int ShiftId { get; set; }
		public int JobId { get; set; }	

		public bool? IsDeleted { get; set; }	

	}
}
