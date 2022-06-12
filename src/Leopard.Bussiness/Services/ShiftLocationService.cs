using Leopard.Bussiness.Model;
using Leopard.Bussiness.Model.ReturnModel;
using Leopard.Bussiness.Services.Interface;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Services {
	public class ShiftLocationService : IShiftLocationService {

		readonly private IShiftLocationStore _shiftLocationStore;

		public ShiftLocationService(IShiftLocationStore shiftLocationStore) {
			_shiftLocationStore = shiftLocationStore;
		}

		public List<ShiftLocationReturnModel> GetAll() {

			List<ShiftLocationReturnModel>? res = _shiftLocationStore.GetAll().Select(pp=> new ShiftLocationReturnModel { Id= pp.Id, PortalId = pp.PortalId.Value , PortalTitle= pp.Portal.Title , Title = pp.Title }).ToList();
			return res;

		}

		public List<ShiftLocation> GetShiftLocationByPortalId(int portalId) {

			List<ShiftLocation>? res = _shiftLocationStore.GetAll().Where(pp => pp.PortalId == portalId).ToList();
			return res;

		}

		public async Task<int> RegisterShiftLocation(ShiftLocationModel model) {

			ShiftLocation shiftLocation = new ShiftLocation { Title = model.Title, PortalId = model.PortalId };
			var res = await _shiftLocationStore.InsertAsync(shiftLocation);
			return res;

		}

		public async Task<int> Update(ShiftLocationModel model) {

			var found = _shiftLocationStore.FindById(model.Id);
			found.Title = model.Title;
			found.PortalId = model.PortalId;
			var res = await _shiftLocationStore.Update(found);
			return res;
		}
}
}
