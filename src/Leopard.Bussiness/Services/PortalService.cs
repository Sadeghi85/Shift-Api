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

		public PortalService(IPrincipal iPrincipal, IPortalStore portalStore, IShiftLogStore shiftLogStore) : base(iPrincipal, shiftLogStore) {
			_portalStore = portalStore;
		}

		public async Task<StoreViewModel<PortalViewModel>> GetAll(PortalSearchModel model) {

			if (CurrentUserPortalId > 1) {
				model.Id = CurrentUserPortalId;
			}

			var getAllExpressions = new List<Expression<Func<Portal, bool>>>();

			getAllExpressions.Add(x => x.NoDashboard == false);

			if (!string.IsNullOrWhiteSpace(model.Title)) {
				getAllExpressions.Add(x => x.Title.Contains(model.Title));
			}

			if (model.Id > 0) {
				getAllExpressions.Add(x => x.Id == model.Id);
			}

			var res = await _portalStore.GetAllWithPagingAsync(getAllExpressions, x => new PortalViewModel { Id = x.Id, Title = x.Title }, model.OrderKey, model.Desc, model.PageSize, model.PageNo);

			return res;
		}

		//public async ValueTask<Portal?> GetById(int id) {
		//	var res = await _portalStore.FindByIdAsync(id);

		//	return res;

		//}
	}
}
