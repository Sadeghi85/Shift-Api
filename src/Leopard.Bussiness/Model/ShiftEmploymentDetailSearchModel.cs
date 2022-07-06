using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Model {
	public class ShiftEmploymentDetailSearchModel:PagerViewModel {
		public int Id { get; set; }
		public int PortalId { get; set; }
		public int CooperationTypeId { get; set; }

		public bool? IsDeleted { get; set; }
	}
}
