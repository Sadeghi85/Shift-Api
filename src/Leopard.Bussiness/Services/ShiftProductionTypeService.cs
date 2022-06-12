using Leopard.Bussiness.Model;
using Leopard.Bussiness.Services.Interface;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Services {
	public class ShiftProductionTypeService : IShiftProductionTypeService {

		readonly private ShiftProductionTypeStore _shiftProductionTypeStore;

		public ShiftProductionTypeService(ShiftProductionTypeStore shiftProductionTypeStore) {
			_shiftProductionTypeStore = shiftProductionTypeStore;
		}


		public ShiftProductionType FindById(int id) {



			var res = _shiftProductionTypeStore.FindById(id);

			return res;

		}

		public IQueryable<ShiftProductionType> GetAll() {

			IQueryable<ShiftProductionType>? res = _shiftProductionTypeStore.GetAll();

			return res;
		}

		public async Task<int> Register(ShiftProductionTypeModel model) {
			ShiftProductionType shiftProductionType = new ShiftProductionType { Title = model.Title };
			int res = await _shiftProductionTypeStore.InsertAsync(shiftProductionType);

			return res;

		}

		public async Task<int> Update(ShiftProductionTypeModel model) {

			var found = _shiftProductionTypeStore.FindById(model.Id);

			found.Title = model.Title;

			var res = await _shiftProductionTypeStore.Update(found);

			return res;

		}

	}
}
