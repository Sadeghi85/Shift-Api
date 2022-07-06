using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Model {
	public class GetAgentByResourceTypeIDModel:PagerViewModel {
		public int ResourceTypeId { get; set; }
		public bool? IsDeleted { get; set; } 

	}
}
