using Leopard.Bussiness.Model;
using Leopard.Bussiness.Services.Interface;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Services {
	public class ShiftTabletService :BaseService, IShiftTabletService {

		readonly private IShiftShiftTabletStore _shiftShiftTabletStore;
		readonly private IShiftShiftStore _shiftShiftStore;

		public ShiftTabletService(IShiftShiftTabletStore shiftShiftTabletStore, IShiftShiftStore shiftShiftStore) {
			_shiftShiftTabletStore = shiftShiftTabletStore;
			_shiftShiftStore = shiftShiftStore;
		}

		public OperationResult GetTabletShiftByPortalId(int portalId) {
			try {
				var res = _shiftShiftTabletStore.GetAll().Where(pp => pp.ShiftShift.PortalId == portalId && pp.IsDeleted == false).ToList();
				OperationResult.Data = res;
			} catch (Exception ex) {

				OperationResult.Success=false;
				OperationResult.Message = ex.Message;
			}

			return OperationResult;
		}

		public OperationResult GetAll() {
			try {
				var res = _shiftShiftTabletStore.GetAll();
				OperationResult.Data = res;
			} catch (Exception ex) {
				OperationResult.Success=false;	
				OperationResult.Message = ex.Message;
				
			}

			return OperationResult;
		}




		public async Task<OperationResult> RegisterShiftTablet(ShiftTabletModel model) {
			try {
				ShiftShiftTablet shiftTablet = new ShiftShiftTablet { ShiftId = model.ShiftId, ShiftDate = model.ShiftDate, ProductionTypeId = model.ProductionTypeId, ShiftWorthPercent = model.ShiftWorthPercent, IsDeleted = false };
				var foundShift = _shiftShiftStore.FindById(model.ShiftId);
				shiftTablet.ShiftTime = foundShift.EndTime - foundShift.StartTime;



				var res = await _shiftShiftTabletStore.InsertAsync(shiftTablet);
				OperationResult.Data = res; 
			} catch (Exception ex) {

				OperationResult.Success = false;
				OperationResult.Message=ex.Message;	

			}
			return OperationResult;

		}

		public async Task<OperationResult> UpdateShifTablet(ShiftTabletModel model) {

			try {
				var found = _shiftShiftTabletStore.FindById(model.Id);

				found.ShiftId = model.ShiftId;
				found.ShiftDate = model.ShiftDate;
				found.ProductionTypeId = model.ProductionTypeId;
				found.ShiftWorthPercent = model.ShiftWorthPercent;

				var res = await _shiftShiftTabletStore.Update(found);
				OperationResult.Data = res;
			} catch (Exception ex) {

				OperationResult.Success=false;	
				OperationResult.Message = ex.Message;	

			}
			return OperationResult;

		}
	}
}
