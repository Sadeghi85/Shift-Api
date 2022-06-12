using Leopard.Bussiness.Model;
using Leopard.Bussiness.Services.Interface;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Services {
	public class ShiftProductionTypeService : BaseService,IShiftProductionTypeService {

		readonly private ShiftProductionTypeStore _shiftProductionTypeStore;

		public ShiftProductionTypeService(ShiftProductionTypeStore shiftProductionTypeStore) {
			_shiftProductionTypeStore = shiftProductionTypeStore;
		}


		public OperationResult FindById(int id) {


			try {
				var res = _shiftProductionTypeStore.FindById(id);
				OperationResult.Data = res;
			} catch (Exception ex) {

				OperationResult.Success = false;
				OperationResult.Message = ex.Message;
			}
			return OperationResult;

		}

		public OperationResult GetAll() {


			try {
				var res = _shiftProductionTypeStore.GetAll();
				OperationResult.Data = res;
			} catch (Exception ex) {

				OperationResult.Success = false;
				OperationResult.Message= ex.Message;
			}


			return OperationResult;
		}

		public async Task<OperationResult> Register(ShiftProductionTypeModel model) {

			try {
				ShiftProductionType shiftProductionType = new ShiftProductionType { Title = model.Title };
				var res = await _shiftProductionTypeStore.InsertAsync(shiftProductionType);
				OperationResult.Data = res;
			} catch (Exception ex) {

				OperationResult.Success = false;
				OperationResult.Message = ex.Message;
				
			}


			return OperationResult;
			
		}

		public async Task<OperationResult> Update(ShiftProductionTypeModel model) {
			try {
				var found = _shiftProductionTypeStore.FindById(model.Id);

				found.Title = model.Title;

				var res = await _shiftProductionTypeStore.Update(found);

				OperationResult.Data = res;

			} catch (Exception ex) {

				OperationResult.Success= false;
				OperationResult.Message = ex.Message;
			}
			return OperationResult;
				
			

			
		}

	}
}
