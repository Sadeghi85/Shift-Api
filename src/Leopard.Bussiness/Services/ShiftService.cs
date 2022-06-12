using Leopard.Bussiness.Model;
using Leopard.Bussiness.Services.Interface;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Services {
	public class ShiftService : BaseService, IShiftService {

		private readonly IShiftShiftStore _shiftShiftStore;

		public ShiftService(IShiftShiftStore shiftShiftStore) {
			_shiftShiftStore = shiftShiftStore;
		}



		public async Task<OperationResult> Delete(int id) {
			try {
				var found = _shiftShiftStore.FindById(id);
				found.IsDeleted = true;
				var res =await _shiftShiftStore.Update(found);
				OperationResult.Data = res;
				

			} catch (Exception ex) {

				OperationResult.Success = false;
				OperationResult.Message = ex.Message;
			}
			return OperationResult;

		}

		public OperationResult FindByPortalId(int portalId) {


			try {
				var res = _shiftShiftStore.GetAll().Where(pp => pp.PortalId == portalId).ToList();
				OperationResult.Data = res;
			} catch (Exception ex) {

				OperationResult.Success=false;
				OperationResult.Message=ex.Message;
			}
			return OperationResult;

		}

		public OperationResult GetAll() {

			try {
				
				var res = _shiftShiftStore.GetAll();
				OperationResult.Data = res;
			} catch (Exception ex) {

				OperationResult.Success = false;
				OperationResult.Message = ex.Message;

			}
			return OperationResult;
		}

		public OperationResult GetByPortalId(int portalId) {
			throw new NotImplementedException();
		}

		public async Task<OperationResult> Register(ShiftModel model) {
			try {
				ShiftShift shiftShift = new ShiftShift { Title = model.Title, PortalId = model.PortalId, ShiftType = model.ShiftType, StartTime = model.StartTime, EndTime = model.EndTime, IsDeleted = false };

				var res = await _shiftShiftStore.InsertAsync(shiftShift);
				OperationResult.Data = res;
			} catch (Exception ex) {

				OperationResult.Success= false;
				OperationResult.Message = ex.Message;
			}
			return OperationResult;
		}

		public async Task<OperationResult> Update(ShiftModel model) {
			try {
				var found = _shiftShiftStore.FindById(model.Id);
				if (found != null) {

					found.Title = model.Title;
					found.StartTime = model.StartTime;
					found.EndTime = model.EndTime;
					found.ShiftType = model.ShiftType;
					found.PortalId = model.PortalId;
					var res =await _shiftShiftStore.Update(found);
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
