using Leopard.Bussiness.Model;
using Leopard.Bussiness.Model.ReturnModel;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness {
	public interface IPortalService {
		public Task<List<PortalResult>>? GetAll(PortalSearchModel model);
		public Portal GetById(int id);
		public int GetAllTotalCount();
	}
}
