using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness {
	public interface IDefaultService : IServiceBase {

		Task<List<PortalViewModel>> GetPortalsAsync();


	}
}
