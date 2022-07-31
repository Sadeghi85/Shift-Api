using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness {
	public interface IShiftTabletService {
		public Task<BaseResult> Register(ShiftTabletInputModel model);
		//public List<ShiftShiftTablet> GetTabletShiftByPortalId(int portalId);

		public Task<BaseResult> Update(ShiftTabletInputModel model);
		public Task<StoreViewModel<ShiftTabletViewModel>> GetAll(ShiftTabletSearchModel model);
		public Task<BaseResult> Delete(int id);
	}
}
