using Leopard.Bussiness.Model;
using Leopard.Bussiness.Services.Interface;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Services {
	public class ShiftLocationService:BaseService, IShiftLocationService {

		readonly private IShiftLocationStore _shiftLocationStore;

		public ShiftLocationService(IShiftLocationStore shiftLocationStore) {
			_shiftLocationStore = shiftLocationStore;
		}

		public OperationResult GetAll() {

			try {
				var res = _shiftLocationStore.GetAll();
				OperationResult.Data = res;
			} catch (Exception ex) {
				OperationResult.Success = false;	
				OperationResult.Message= ex.Message;
				
			}
			return OperationResult;

		}

		public OperationResult GetShiftLocationByPortalId(int portalId) {
			try {
				var res = _shiftLocationStore.GetAll().Where(pp => pp.PortalId == portalId).ToList();
				OperationResult.Data = res;
			} catch (Exception ex) {

				OperationResult.Success= false;
				OperationResult.Message = ex.Message;
			}
			return OperationResult;
			
		}

		public async Task<OperationResult> RegisterShiftLocation(ShiftLocationModel model) {
			try {
				ShiftLocation shiftLocation = new ShiftLocation { Title = model.Title, PortalId = model.PortalId };
				var res = await _shiftLocationStore.InsertAsync(shiftLocation);
				OperationResult.Data = res;
			} catch (Exception ex) {

				OperationResult.Success=false;
				OperationResult.Message = ex.Message;
			}
			return OperationResult;

		}

		public async Task<OperationResult> Update(ShiftLocationModel model) {
			try {
				var found = _shiftLocationStore.FindById(model.Id);

				found.Title = model.Title;
				found.PortalId = model.PortalId;
				var res = await _shiftLocationStore.Update(found);
				OperationResult.Data = res;
			} catch (Exception ex) {


				OperationResult.Success= false;
				OperationResult.Message = ex.Message;

			}
			return OperationResult;

			
		}
	}
}
