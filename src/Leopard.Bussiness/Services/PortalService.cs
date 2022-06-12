using Leopard.Bussiness.Services.Interface;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Leopard.Bussiness.Services {
	public class PortalService : IPortalService {

		private readonly IPortalStore _portalStore;
		public PortalService(IPortalStore portalStore) {
			_portalStore = portalStore;
		}
		public IQueryable<Portal> GetAll() {
			IQueryable<Portal>? res = _portalStore.GetAll();
			return res;
		}

		public Portal GetById(int id) {
			Portal? res =_portalStore.FindById(id);
			return res;

		}
	}
}
