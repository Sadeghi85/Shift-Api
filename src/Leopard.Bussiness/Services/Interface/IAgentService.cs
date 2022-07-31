using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness {
	public interface IAgentService {
		public Task<StoreViewModel<AgentViewModel>> GetAll(AgentSearchModel model);

		public Task<StoreViewModel<AgentViewModel>> GetAgentByJobID(AgentByJobSearchModel model);

	}
}
