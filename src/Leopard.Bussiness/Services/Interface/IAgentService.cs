using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness {
	public interface IAgentService {
		public Task<List<AgentViewModel>>? GetAll(AgentSearchModel model);
		int GetAllTotal();

		public Task<List<GetAgentByResourceTypeIDResult>>? GetAgentByResourceTypeID(GetAgentByResourceTypeIDModel model);
		public int GetAgentByResourceTypeIDTotalCount();

	}
}
