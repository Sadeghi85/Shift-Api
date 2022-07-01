using Leopard.Bussiness.Model;
using Leopard.Bussiness.Model.ReturnModel;
using Leopard.Bussiness.Services.Interface;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Services {
	public class AgentService : IAgentService {

		private readonly ISamtAgentStore _samtAgentStore;
		public AgentService(ISamtAgentStore samtAgentStore) {
			_samtAgentStore = samtAgentStore;
		}

		private List<Expression<Func<SamtAgent, bool>>> GetAllExpressions { get; set; } = new List<Expression<Func<SamtAgent, bool>>>();

		public Task<List<AgentResultModel>>? GetAll(AgentSearchModel model) {
			GetAllExpressions.Add(pp => !pp.IsDeleted);


			if (!string.IsNullOrWhiteSpace(model.Name)) {
				GetAllExpressions.Add(pp => pp.FirstName.Contains(model.Name) || pp.LastName.Contains(model.Name));
			}

			if (model.Id != 0) {
				GetAllExpressions.Add(pp => model.Id == pp.Id);
			}

			Task<List<AgentResultModel>>? res = _samtAgentStore.GetAllWithPagingAsync(GetAllExpressions, pp => new AgentResultModel { Id = pp.Id, FullName = $"{pp.FirstName} {pp.LastName}" }, pp => pp.LastName, model.PageSize, model.PageNo, "desc");
			return res;
		}

		public int GetAllTotal() {
			var res = _samtAgentStore.TotalCount(GetAllExpressions);
			return res;
		}
	}
}
