using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness {
	public class DefaultService : IDefaultService {

		private readonly IPortalStore _portalStore;

		public DefaultService(IPortalStore portalStore) {
			_portalStore = portalStore;
		}

		public async Task<List<PortalViewModel>> GetPortalsAsync() {
			return await _portalStore.GetAllAsync(c => true, t => new PortalViewModel() {
				ID = t.Id,
				Title = t.Title
			}, o => o.Id, "desc");
		}
	}
}
