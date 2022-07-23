using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness {
	public interface IShiftCrewRewardFineService {
		public Task<BaseResult> Register(ShiftCrewRewardFineInputModel model);
		public Task<BaseResult> Update(ShiftCrewRewardFineInputModel model);

		public Task<List<ShiftCrewRewardFine>>? GetAll(ShiftCrewRewardFineSearchModel model, out Task<int> totalCount);

		public Task<BaseResult> Delete(ShiftCrewRewardFineInputModel model);
	}
}
