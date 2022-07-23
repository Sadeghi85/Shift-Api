using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness {
	public interface IShiftTabletService {
		public Task<BaseResult> Register(ShiftTabletInputModel model);
		public List<ShiftShiftTablet> GetTabletShiftByPortalId(int portalId);
		//public IQueryable<ShiftShiftTablet> GetAll();

		public Task<BaseResult> Update(ShiftTabletInputModel model);
		public Task<List<ShiftTabletViewModel>>? GetAll(ShiftTabletSearchModel model, out int totalCount);
		//public int GetShiftTabletCount();
		public Task<BaseResult> Delete(ShiftTabletInputModel model);
	}
}
