

using Shift.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Bussiness {
	public interface IShiftTabletConductorChangeService {
		
		public Task<StoreViewModel<ShiftTabletConductorChangeViewModel>> GetAll(ShiftTabletConductorChangeSearchModel model);
		public Task<BaseResult> Create(ShiftTabletConductorChangeInputModel model);
		public Task<BaseResult> Update(ShiftTabletConductorChangeInputModel model);
		public Task<BaseResult> Delete(int id);
		public Task<BaseResult> Delete(string ids);

	}
}
