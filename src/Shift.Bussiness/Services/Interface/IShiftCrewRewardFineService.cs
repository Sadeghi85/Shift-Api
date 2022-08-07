using Shift.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Bussiness {
	public interface IShiftCrewRewardFineService {
		public Task<BaseResult> Register(ShiftCrewRewardFineInputModel model);
		public Task<BaseResult> Update(ShiftCrewRewardFineInputModel model);

		public Task<StoreViewModel<ShiftCrewRewardFine>> GetAll(ShiftCrewRewardFineSearchModel model);

		public Task<BaseResult> Delete(ShiftCrewRewardFineInputModel model);
	}
}
