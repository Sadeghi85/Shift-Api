using Leopard.Bussiness.Model;
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
		public PortalService(IPortalStore portalStore) {
			_portalStore = portalStore;
		}
		public Task<List<Portal>>? GetAll(PortalSearchModel model) {

			List<Expression<Func<Portal, bool>>> expressions = new List<Expression<Func<Portal, bool>>>();

			if (string.IsNullOrEmpty(model.Title) && model.PortalId == null) {
				expressions.Add(pp => true);
			} else if (!string.IsNullOrEmpty(model.Title)) {
					expressions.Add(pp => pp.Title.Contains(model.Title));
			}else if (model.PortalId != null) {
				expressions.Add(pp => pp.Id == model.PortalId.Value);
			}



			Task<List<Portal>>? res =	_portalStore.GetAllWithPagingAsync(expressions,t=> new Portal {Id=t.Id, Title= t.Title }, t => t.Id,model.PageSize,model.PageNo, "desc");



			//IQueryable<Portal>? res = _portalStore.GetAll();
			return res;
		}

		public Portal GetById(int id) {
			Portal? res = _portalStore.FindById(id);
			return res;

		}
	}
}
