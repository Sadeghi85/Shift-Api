using Leopard.Bussiness.Model;
using Leopard.Bussiness.Services.Interface;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Services {
	public class ShiftCrewRewardFineService : IShiftCrewRewardFineService {

		readonly private IShiftCrewRewardFineStore _shiftCrewRewardFineStore;

		public ShiftCrewRewardFineService(IShiftCrewRewardFineStore shiftCrewRewardFineStore) {
			_shiftCrewRewardFineStore = shiftCrewRewardFineStore;
		}

		public async Task<int> Delete(int id) {

			var found = _shiftCrewRewardFineStore.FindById(id);
			found.IsDeleted = true;
			var res = await _shiftCrewRewardFineStore.Update(found);





			return res;

		}

		public IQueryable<ShiftCrewRewardFine> GetAll() {
			return _shiftCrewRewardFineStore.GetAll();
		}

		public async Task<int> Register(ShiftCrewRewardFineModel model) {

			ShiftCrewRewardFine shiftCrewRewardFine = new ShiftCrewRewardFine { ShiftTabletCrewId = model.ShiftTabletCrewId, IsReward = model.IsReward, IsDeleted = false, Ammount = model.Ammount, Shiftpercentage = model.Shiftpercentage, Description = model.Description };
			var res = await _shiftCrewRewardFineStore.InsertAsync(shiftCrewRewardFine);

			return res;
		}

		public async Task<int> Update(ShiftCrewRewardFineModel model) {

			var found = _shiftCrewRewardFineStore.FindById(model.Id);
			var res = 0;
			if (found != null) {
				found.ShiftTabletCrewId = model.ShiftTabletCrewId;
				found.IsReward = model.IsReward;
				found.Ammount = model.Ammount;
				found.Shiftpercentage = model.Shiftpercentage;
				found.Description = model.Description;
				res = await _shiftCrewRewardFineStore.Update(found);

			}
			return res;
		}
	}
}
