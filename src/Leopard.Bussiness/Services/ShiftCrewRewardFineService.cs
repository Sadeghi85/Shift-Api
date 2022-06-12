using Leopard.Bussiness.Model;
using Leopard.Bussiness.Services.Interface;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Services {
	public class ShiftCrewRewardFineService : BaseService, IShiftCrewRewardFineService {

		readonly private IShiftCrewRewardFineStore _shiftCrewRewardFineStore;

		public ShiftCrewRewardFineService(IShiftCrewRewardFineStore shiftCrewRewardFineStore) {
			_shiftCrewRewardFineStore = shiftCrewRewardFineStore;
		}

		public async Task<OperationResult> Delete(int id) {
			try {
				var found = _shiftCrewRewardFineStore.FindById(id);
				found.IsDeleted = true;
				var res = await _shiftCrewRewardFineStore.Update(found);
				OperationResult.Data = res;
			} catch (Exception ex) {
				OperationResult.Success = false;
				OperationResult.Message= ex.Message;
			}
			return OperationResult;

		}

		public IQueryable<ShiftCrewRewardFine> GetAll() {
			return _shiftCrewRewardFineStore.GetAll();
		}

		public async Task<OperationResult> Register(ShiftCrewRewardFineModel model) {
			try {
				ShiftCrewRewardFine shiftCrewRewardFine = new ShiftCrewRewardFine { ShiftTabletCrewId = model.ShiftTabletCrewId, IsReward = model.IsReward, IsDeleted = false, Ammount = model.Ammount, Shiftpercentage = model.Shiftpercentage, Description = model.Description };
				var res = await _shiftCrewRewardFineStore.InsertAsync(shiftCrewRewardFine);
				OperationResult.Data = res;


			} catch (Exception ex) {

				OperationResult.Success = false;
				OperationResult.Message = ex.Message;

			}
			return OperationResult;
		}

		public async Task<OperationResult> Update(ShiftCrewRewardFineModel model) {
			try {
				var found = _shiftCrewRewardFineStore.FindById(model.Id);
				if (found != null) {
					found.ShiftTabletCrewId = model.ShiftTabletCrewId;
					found.IsReward = model.IsReward;
					found.Ammount = model.Ammount;
					found.Shiftpercentage = model.Shiftpercentage;
					found.Description = model.Description;
					var res = await _shiftCrewRewardFineStore.Update(found);
					OperationResult.Data = res;
				}
			} catch (Exception ex) {

				OperationResult.Success = false;
				OperationResult.Message = ex.Message;
			}
			return OperationResult;
		}
	}
}
