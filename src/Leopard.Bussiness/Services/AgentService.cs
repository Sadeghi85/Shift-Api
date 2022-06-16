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
	public class AgentService: IAgentService {

		private readonly ISamtAgentStore _samtAgentStore;
		public AgentService(ISamtAgentStore samtAgentStore) {
			_samtAgentStore = samtAgentStore;
		}

		private List<Expression<Func<SamtAgent, bool>>> GetAllExpressions { get; set; } = new List<Expression<Func<SamtAgent, bool>>>();

		public Task<List<AgentResultModel>>? GetAll(AgentSearchModel model) {

			if (string.IsNullOrWhiteSpace(model.FirstName) && string.IsNullOrWhiteSpace(model.LastName) && model.Id==0) {
				GetAllExpressions.Add(pp=> true);
			} else {
				if (!string.IsNullOrWhiteSpace(model.FirstName)) {
					GetAllExpressions.Add(pp => model.FirstName.Contains(pp.FirstName));
				}
				if (!string.IsNullOrWhiteSpace(model.LastName)) {

					GetAllExpressions.Add(pp => model.LastName.Contains(pp.LastName));

				}
				if (model.Id != 0) {
					GetAllExpressions.Add(pp => model.Id==pp.Id);
				}
			}
			GetAllExpressions.Add(pp=>!string.IsNullOrEmpty( pp.FirstName) && !string.IsNullOrEmpty(pp.LastName));


			Task<List<AgentResultModel>>? res = _samtAgentStore.GetAllWithPagingAsync(GetAllExpressions, pp => new AgentResultModel {Id=pp.Id , FullName=$"{pp.FirstName} {pp.LastName}" }, pp => pp.Id, model.PageSize, model.PageNo, "desc");
			return res;

		}

		public int GetAllTotal() {
			var res = _samtAgentStore.TotalCount(GetAllExpressions);
			return res;
		}
	}
}
