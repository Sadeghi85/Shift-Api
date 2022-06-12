using Leopard.Bussiness.Model;
using Leopard.Bussiness.Services.Interface;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Services {
	public class ShiftTabletService : IShiftTabletService {

		readonly private IShiftShiftTabletStore _shiftShiftTabletStore;
		readonly private IShiftShiftStore _shiftShiftStore;

		public ShiftTabletService(IShiftShiftTabletStore shiftShiftTabletStore, IShiftShiftStore shiftShiftStore) {
			_shiftShiftTabletStore = shiftShiftTabletStore;
			_shiftShiftStore = shiftShiftStore;
		}

		public List<ShiftShiftTablet> GetTabletShiftByPortalId(int portalId) {

			List<ShiftShiftTablet>? res = _shiftShiftTabletStore.GetAll().Where(pp => pp.ShiftShift.PortalId == portalId && pp.IsDeleted == false).ToList();

			return res;
		}

		public IQueryable<ShiftShiftTablet> GetAll() {

			IQueryable<ShiftShiftTablet>? res = _shiftShiftTabletStore.GetAll();


			return res;
		}




		public async Task<int> RegisterShiftTablet(ShiftTabletModel model) {

			ShiftShiftTablet shiftTablet = new ShiftShiftTablet { ShiftId = model.ShiftId, ShiftDate = model.ShiftDate, ProductionTypeId = model.ProductionTypeId, ShiftWorthPercent = model.ShiftWorthPercent, IsDeleted = false };
			var foundShift = _shiftShiftStore.FindById(model.ShiftId);
			shiftTablet.ShiftTime = foundShift.EndTime - foundShift.StartTime;

			int res = await _shiftShiftTabletStore.InsertAsync(shiftTablet);

			return res;

		}

		public async Task<int> UpdateShifTablet(ShiftTabletModel model) {


			var found = _shiftShiftTabletStore.FindById(model.Id);

			found.ShiftId = model.ShiftId;
			found.ShiftDate = model.ShiftDate;
			found.ProductionTypeId = model.ProductionTypeId;
			found.ShiftWorthPercent = model.ShiftWorthPercent;

			var res = await _shiftShiftTabletStore.Update(found);

			return res;

		}
}
}
