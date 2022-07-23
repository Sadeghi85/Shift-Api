using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness {
	public interface IPortalService {
		public Task<List<PortalViewModel>>? GetAll(PortalSearchModel model, out Task<int> totalCount);
		public Portal GetById(int id);
		//public int GetAllTotalCount();
	}
}
