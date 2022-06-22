using Leopard.Bussiness.Model;
using Leopard.Bussiness.Model.ReturnModel;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Services.Interface {
	public interface IShiftCrewRewardFineService {
		public Task<BaseResult> Register(ShiftCrewRewardFineModel model);
		public Task<BaseResult> Update(ShiftCrewRewardFineModel model);

		public Task<List<ShiftCrewRewardFine>>? GetAll(ShiftCrewRewardFineSearchModel model);

		public Task<BaseResult> Delete(ShiftCrewRewardFineModel model);
	}
}
