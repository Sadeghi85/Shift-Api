using Leopard.Bussiness.Model;
using Leopard.Bussiness.Services.Interface;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Services {
	public class ShiftTabletLocationService : BaseService, IShiftTabletLocationService {

		readonly private ShiftShiftTabletLocationStore _shiftShiftTabletLocationStore;

		public ShiftTabletLocationService(ShiftShiftTabletLocationStore shiftShiftTabletLocationStore) {
			_shiftShiftTabletLocationStore = shiftShiftTabletLocationStore;
		}

		public OperationResult GetAll() {
			try {
				var res = _shiftShiftTabletLocationStore.GetAll();
				OperationResult.Data = res;
			} catch (Exception ex) {

				OperationResult.Success = false;
				OperationResult.Message = ex.Message;
			}
			return OperationResult;
		}

		public OperationResult GetShiftLocattionsByshiftTabletId(int shiftTablettId) {
			try {
				var res = _shiftShiftTabletLocationStore.GetAll().Where(pp => pp.ShiftTabletId == shiftTablettId).ToList();
				OperationResult.Data = res;
			} catch (Exception ex) {

				OperationResult.Success = false;
				OperationResult.Message = ex.Message;
			}
			return OperationResult;
		}

		public async Task<OperationResult> RegisterShiftTabletLocation(ShiftTabletLocationModel model) {

			try {
				ShiftShiftTabletLocation tabletLocation = new ShiftShiftTabletLocation { LocationId = model.LocationId, ShiftTabletId = model.ShiftTabletId };
				var res = await _shiftShiftTabletLocationStore.InsertAsync(tabletLocation);
				OperationResult.Data = res;
			} catch (Exception ex) {

				OperationResult.Success=false;
				OperationResult.Message = ex.Message;
			}
			return OperationResult;

		}

		public async Task<OperationResult> Update(ShiftTabletLocationModel model) {
			try {
				var found = _shiftShiftTabletLocationStore.FindById(model.Id);

				found.ShiftTabletId = model.ShiftTabletId;
				found.LocationId = model.LocationId;
				var res = await _shiftShiftTabletLocationStore.Update(found);
				OperationResult.Data = res;

			} catch (Exception ex) {

				OperationResult.Success = false;
				OperationResult.Message = ex.Message;
			}
			return OperationResult;
			

		}
	}
}
