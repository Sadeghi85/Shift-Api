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
	public class PortalService : IPortalService {

		private readonly IPortalStore _portalStore;

		List<Expression<Func<Portal, bool>>> GetAllExpressions = new List<Expression<Func<Portal, bool>>>();
		public PortalService(IPortalStore portalStore) {
			_portalStore = portalStore;
		}
		public Task<List<PortalResult>>? GetAll(PortalSearchModel model) {

			GetAllExpressions.Add(pp => !pp.NoDashboard);


			if (!string.IsNullOrWhiteSpace(model.Title)) {
				GetAllExpressions.Add(pp => pp.Title.Contains(model.Title));
			}
			if (model.PortalId != 0) {
				GetAllExpressions.Add(pp => pp.Id == model.PortalId);
			}


			Task<List<PortalResult>>? res = _portalStore.GetAllWithPagingAsync(GetAllExpressions, t => new PortalResult { Id = t.Id, Title = t.Title }, t => t.Id, model.PageSize, model.PageNo, "asc");
			return res;
		}

		public int GetAllTotalCount() {
			var res = _portalStore.TotalCount(GetAllExpressions);
			return res;
		}


		public Portal GetById(int id) {
			Portal? res = _portalStore.FindById(id);
			return res;

		}
	}
}
