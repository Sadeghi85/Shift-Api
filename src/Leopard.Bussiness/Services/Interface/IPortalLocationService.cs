using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness {
	public interface IPortalLocationService {
		public Task<StoreViewModel<PortalLocationViewModel>> GetAll(PortalLocationSearchModel model);

		public Task<BaseResult> Register(PortalLocationInputModel model);

		public Task<BaseResult> Update(PortalLocationInputModel model);
		public Task<BaseResult> Delete(PortalLocationInputModel model);



	}
}
