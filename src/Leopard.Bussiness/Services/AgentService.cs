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

		public AgentService(IPrincipal iPrincipal, ISamtAgentStore samtAgentStore, TelavatAgentResourceTypeStore telavatAgentResourceTypeStore) : base(iPrincipal) {
			_samtAgentStore = samtAgentStore;
			_telavatAgentResourceTypeStore = telavatAgentResourceTypeStore;
		}

		private List<Expression<Func<SamtAgent, bool>>> GetAllExpressions { get; set; } = new List<Expression<Func<SamtAgent, bool>>>();

		public Task<List<AgentViewModel>> GetAll(AgentSearchModel model, out int totalCount) {

			GetAllExpressions.Add(pp => !pp.IsDeleted);

			if (!string.IsNullOrWhiteSpace(model.Name)) {
				GetAllExpressions.Add(pp => pp.FirstName.Contains(model.Name) || pp.LastName.Contains(model.Name));
			}

			if (model.Id != 0) {
				GetAllExpressions.Add(pp => model.Id == pp.Id);
			}

			var res = _samtAgentStore.GetAllWithPagingAsync(GetAllExpressions, pp => new AgentViewModel { Id = pp.Id, Fullname = $"{pp.FirstName} {pp.LastName}" }, model.OrderKey, model.Desc ? "desc" : "asc", model.PageSize, model.PageNo, out totalCount);
			return res;
		}

		//public int GetAllTotal() {
		//	var res = _samtAgentStore.TotalCount(GetAllExpressions);
		//	return res;
		//}

		private List<Expression<Func<TelavatAgentResourceType, bool>>> GetAgentByResourceTypeIDExpressions { get; set; } = new List<Expression<Func<TelavatAgentResourceType, bool>>>();


		public Task<List<GetAgentByResourceTypeIDResult>> GetAgentByResourceTypeID(GetAgentByResourceTypeIDModel model, out int totalCount) {
			if (model.IsDeleted != null) {
				GetAgentByResourceTypeIDExpressions.Add(pp => pp.IsDeleted == model.IsDeleted);
			}
			if (model.ResourceTypeId != 0) {
				GetAgentByResourceTypeIDExpressions.Add(pp => pp.ResourceTypeId == model.ResourceTypeId);
			}


			var res = _telavatAgentResourceTypeStore.GetAllWithPagingAsync(GetAgentByResourceTypeIDExpressions, pp => new GetAgentByResourceTypeIDResult { AgentID = pp.AgentId }, pp => pp.Id, "desc", model.PageSize, model.PageNo, out totalCount);
			return res;


		}

		//public int GetAgentByResourceTypeIDTotalCount() {
		//	var res = _telavatAgentResourceTypeStore.TotalCount(GetAgentByResourceTypeIDExpressions);
		//	return res;
		//}
	}
}
