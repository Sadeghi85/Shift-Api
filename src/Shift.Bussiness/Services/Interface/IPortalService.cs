using Shift.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Bussiness {
	public interface IPortalService {
		public Task<StoreViewModel<PortalViewModel>> GetAll(PortalSearchModel model);
		//public ValueTask<Portal?> GetById(int id);
	}
}
