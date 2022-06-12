using Leopard.Bussiness.Model;
using Leopard.Bussiness.Services.Interface;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Services {
	public class ShiftTabletLocationService : IShiftTabletLocationService {

		readonly private ShiftShiftTabletLocationStore _shiftShiftTabletLocationStore;

		public ShiftTabletLocationService(ShiftShiftTabletLocationStore shiftShiftTabletLocationStore) {
			_shiftShiftTabletLocationStore = shiftShiftTabletLocationStore;
		}

		public IQueryable<ShiftShiftTabletLocation> GetAll() {

			IQueryable<ShiftShiftTabletLocation>? res = _shiftShiftTabletLocationStore.GetAll();

			return res;
		}

		public List<ShiftShiftTabletLocation> GetShiftLocattionsByshiftTabletId(int shiftTablettId) {

			List<ShiftShiftTabletLocation>? res = _shiftShiftTabletLocationStore.GetAll().Where(pp => pp.ShiftTabletId == shiftTablettId).ToList();

			return res;
		}

		public async Task<int> RegisterShiftTabletLocation(ShiftTabletLocationModel model) {


			ShiftShiftTabletLocation tabletLocation = new ShiftShiftTabletLocation { LocationId = model.LocationId, ShiftTabletId = model.ShiftTabletId };
			var res = await _shiftShiftTabletLocationStore.InsertAsync(tabletLocation);

			return res;

		}

		public async Task<int> Update(ShiftTabletLocationModel model) {

			var found = _shiftShiftTabletLocationStore.FindById(model.Id);

			found.ShiftTabletId = model.ShiftTabletId;
			found.LocationId = model.LocationId;
			var res = await _shiftShiftTabletLocationStore.Update(found);
			return res;

		}
}
}
