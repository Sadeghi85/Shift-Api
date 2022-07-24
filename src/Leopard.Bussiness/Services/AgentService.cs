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

		private readonly TelavatAgentResourceTypeStore _telavatAgentResourceTypeStore;

		private List<Expression<Func<SamtAgent, bool>>> GetAllExpressions { get; set; } = new();
		private List<Expression<Func<TelavatAgentResourceType, bool>>> GetAgentByResourceTypeIDExpressions { get; set; } = new();

		public AgentService(IPrincipal iPrincipal, ISamtAgentStore samtAgentStore, TelavatAgentResourceTypeStore telavatAgentResourceTypeStore) : base(iPrincipal) {
			_samtAgentStore = samtAgentStore;
			_telavatAgentResourceTypeStore = telavatAgentResourceTypeStore;
		}

		public async Task<StoreViewModel<AgentViewModel>> GetAll(AgentSearchModel model) {

			GetAllExpressions.Clear();

			GetAllExpressions.Add(pp => !pp.IsDeleted);

			if (!string.IsNullOrWhiteSpace(model.Name)) {
				GetAllExpressions.Add(pp => pp.FirstName.Contains(model.Name) || pp.LastName.Contains(model.Name));
			}

			if (model.Id != 0) {
				GetAllExpressions.Add(pp => model.Id == pp.Id);
			}

			var res = await _samtAgentStore.GetAllWithPagingAsync(GetAllExpressions, pp => new AgentViewModel { Id = pp.Id, Fullname = $"{pp.FirstName} {pp.LastName}" }, model.OrderKey, model.Desc, model.PageSize, model.PageNo);
			return res;
		}


		public async Task<StoreViewModel<GetAgentByResourceTypeIDResult>> GetAgentByResourceTypeID(GetAgentByResourceTypeIDModel model) {

			GetAgentByResourceTypeIDExpressions.Clear();

			if (model.IsDeleted != null) {
				GetAgentByResourceTypeIDExpressions.Add(pp => pp.IsDeleted == model.IsDeleted);
			}
			if (model.ResourceTypeId != 0) {
				GetAgentByResourceTypeIDExpressions.Add(pp => pp.ResourceTypeId == model.ResourceTypeId);
			}


			var res = await _telavatAgentResourceTypeStore.GetAllWithPagingAsync(GetAgentByResourceTypeIDExpressions, pp => new GetAgentByResourceTypeIDResult { AgentID = pp.AgentId }, pp => pp.Id, model.Desc, model.PageSize, model.PageNo);

			return res;

		}


	}
}
