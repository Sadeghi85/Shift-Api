using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Model {
	public class AgentSearchModel:PagerViewModel {

		public int Id { get; set; }
		public string FirstName { get; set; } // FirstName (length: 1000)
		public string LastName { get; set; } // LastName (length: 1000)
	}
}
