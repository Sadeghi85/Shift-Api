using Shift.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Bussiness {
	public interface IAgentService {
		public Task<StoreViewModel<AgentViewModel>> GetAll(AgentSearchModel model);

		public Task<StoreViewModel<AgentViewModel>> GetAgentByJobID(AgentByJobSearchModel model);

	}
}
