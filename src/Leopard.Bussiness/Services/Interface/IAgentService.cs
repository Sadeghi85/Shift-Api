using Leopard.Bussiness.Model;
using Leopard.Bussiness.Model.ReturnModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Services.Interface {
	public interface IAgentService {
		public Task<List<AgentResultModel>>? GetAll(AgentSearchModel model);
		int GetAllTotal();
	}
}
