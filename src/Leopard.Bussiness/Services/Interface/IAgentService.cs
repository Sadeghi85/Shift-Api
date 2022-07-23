using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness {
	public interface IAgentService {
		public Task<List<AgentViewModel>> GetAll(AgentSearchModel model, out Task<int> totalCount);
		//int GetAllTotal();

		public Task<List<GetAgentByResourceTypeIDResult>> GetAgentByResourceTypeID(GetAgentByResourceTypeIDModel model, out Task<int> totalCount);
		//public int GetAgentByResourceTypeIDTotalCount();

	}
}
