using Leopard.Bussiness.Model;
using Leopard.Bussiness.Services.Interface;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Services {
	public class ShiftTabletCrewService : BaseService, IShiftTabletCrewService {

		readonly private IShiftShiftTabletCrewStore _shiftShiftTabletCrewStore;
		readonly private IShiftShiftTabletCrewReplacementStore _shiftShiftTabletCrewReplacementStore;

		public ShiftTabletCrewService(IShiftShiftTabletCrewStore shiftShiftTabletCrewStore, IShiftShiftTabletCrewReplacementStore shiftShiftTabletCrewReplacementStore) {
			_shiftShiftTabletCrewStore = shiftShiftTabletCrewStore;
			_shiftShiftTabletCrewReplacementStore = shiftShiftTabletCrewReplacementStore;
		}

		public async Task<OperationResult> Delete(int id) {

			try {
				var found = _shiftShiftTabletCrewStore.FindById(id);

				found.IsDeleted = true;
				var res = await _shiftShiftTabletCrewStore.Update(found);
				OperationResult.Data = res;

			} catch (Exception ex) {

				OperationResult.Success = false;
				OperationResult.Message = ex.Message;

			}
			return OperationResult;

		}

		public OperationResult GetAll() {
			var res = _shiftShiftTabletCrewStore.GetAll();
			OperationResult.Data = res;
			return OperationResult;
		}

		public OperationResult GetByShiftId(int shifTabletId) {
			try {
				var res = _shiftShiftTabletCrewStore.GetAll().Where(pp => pp.ShifTabletId == shifTabletId).ToList();
				OperationResult.Data = res;
			} catch (Exception ex) {


				OperationResult.Success = false;
				OperationResult.Message = ex.Message;
			}
			return OperationResult;

		}

		public async Task<OperationResult> Register(ShiftTabletCrewModel model) {
			try {
				ShiftShiftTabletCrew shiftShiftTabletCrew = new ShiftShiftTabletCrew { AgentId = model.AgentId, EntranceTime = model.EntranceTime, ExitTime = model.ExitTime, IsReplaced = false, ResourceId = model.ResourceId, ShifTabletId = model.ShifTabletId };
				var res =await _shiftShiftTabletCrewStore.InsertAsync(shiftShiftTabletCrew);
				OperationResult.Data = res;
			} catch (Exception ex) {
				OperationResult.Success = false;
				OperationResult.Message = ex.Message;
				
			}
			return OperationResult;
		}

		public async Task<OperationResult> Replace(int replaced, int replacedBy) {
			try {
				var found = _shiftShiftTabletCrewStore.FindById(replaced);
				if (found != null) {
					found.IsReplaced = true;
					_shiftShiftTabletCrewStore.Update(found).Wait();
				}
				var res = await _shiftShiftTabletCrewReplacementStore.InsertAsync(new ShiftShiftTabletCrewReplacement { ShiftTabletCrewId = replaced, ShiftTabletCrewIdReplaceMent = replacedBy });
				OperationResult.Data = res;

			} catch (Exception ex) {

				OperationResult.Success = false;
				OperationResult.Message = ex.Message;
			}
			return OperationResult;

		}

		public async Task<OperationResult> Update(ShiftTabletCrewModel model) {
			try {
				var found = _shiftShiftTabletCrewStore.FindById(model.Id);

				found.ShifTabletId = model.ShifTabletId;
				found.EntranceTime = model.EntranceTime;
				found.ExitTime = model.ExitTime;
				found.ResourceId = model.ResourceId;
				found.AgentId = model.AgentId;

				var res = await _shiftShiftTabletCrewStore.Update(found);
				OperationResult.Data = res;	
			} catch (Exception ex) {

				OperationResult.Success = false;
				OperationResult.Message = ex.Message;

			}

			return OperationResult;


		}

		
	}



}
