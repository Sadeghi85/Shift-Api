using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness {
	public class AgentService : ServiceBase, IAgentService {

		private readonly ISamtAgentStore _samtAgentStore;
		private readonly ITelavatAgentResourceTypeStore _telavatAgentResourceTypeStore;

		public AgentService(IPrincipal iPrincipal, ISamtAgentStore samtAgentStore, ITelavatAgentResourceTypeStore telavatAgentResourceTypeStore, IShiftLogStore shiftLogStore) : base(iPrincipal, shiftLogStore) {
			_samtAgentStore = samtAgentStore;
			_telavatAgentResourceTypeStore = telavatAgentResourceTypeStore;
		}

		public async Task<StoreViewModel<AgentViewModel>> GetAll(AgentSearchModel model) {

			var getAllExpressions = new List<Expression<Func<SamtAgent, bool>>>();

			getAllExpressions.Add(x => x.IsDeleted == false);

			if (model.Id > 0) {
				getAllExpressions.Add(x => x.Id == model.Id);
			}
			if (!string.IsNullOrWhiteSpace(model.Name)) {
				getAllExpressions.Add(x => x.FirstName.Contains(model.Name) || x.LastName.Contains(model.Name));
			}

			var res = await _samtAgentStore.GetAllWithPagingAsync(getAllExpressions, x => new AgentViewModel { Id = x.Id, Fullname = $"{x.FirstName} {x.LastName}" }, model.OrderKey, model.Desc, model.PageSize, model.PageNo);

			return res;
		}

		public async Task<StoreViewModel<AgentViewModel>> GetAgentByJobID(AgentByJobSearchModel model) {

			var getAgentByJobExpressions = new List<Expression<Func<TelavatAgentResourceType, bool>>>();

			if (model.IsDeleted != null) {
				getAgentByJobExpressions.Add(x => x.IsDeleted == model.IsDeleted);
			}
			if (model.JobId > 0) {
				getAgentByJobExpressions.Add(x => x.ResourceTypeId == model.JobId);
			}

			var res = await _telavatAgentResourceTypeStore.GetAllWithPagingAsync(getAgentByJobExpressions, x => new AgentViewModel { Id = x.AgentId }, model.OrderKey, model.Desc, model.PageSize, model.PageNo);

			return res;

		}

	}
}
