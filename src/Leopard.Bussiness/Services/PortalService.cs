using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness {
	public class PortalService : ServiceBase, IPortalService {

		private readonly IPortalStore _portalStore;

		private List<Expression<Func<Portal, bool>>> GetAllExpressions = new();

		public PortalService(IPrincipal iPrincipal, IPortalStore portalStore) : base(iPrincipal) {
			_portalStore = portalStore;
		}
		public async Task<StoreViewModel<PortalViewModel>> GetAll(PortalSearchModel model) {

			GetAllExpressions.Clear();

			GetAllExpressions.Add(pp => !pp.NoDashboard);


			if (!string.IsNullOrWhiteSpace(model.Title)) {
				GetAllExpressions.Add(pp => pp.Title.Contains(model.Title));
			}
			if (model.PortalId != 0) {
				GetAllExpressions.Add(pp => pp.Id == model.PortalId);
			}


			var res = await _portalStore.GetAllWithPagingAsync(GetAllExpressions, t => new PortalViewModel { Id = t.Id, Title = t.Title }, t => t.Id, model.Desc, model.PageSize, model.PageNo);

			return res;
		}

		//public int GetAllTotalCount() {
		//	var res = _portalStore.TotalCount(GetAllExpressions);
		//	return res;
		//}


		public async ValueTask<Portal?> GetById(int id) {
			var res = await _portalStore.FindByIdAsync(id);

			return res;

		}
	}
}
