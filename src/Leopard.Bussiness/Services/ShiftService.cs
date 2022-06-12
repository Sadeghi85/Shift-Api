using Leopard.Bussiness.Model;
using Leopard.Bussiness.Services.Interface;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Services {
	public class ShiftService : IShiftService {

		private readonly IShiftShiftStore _shiftShiftStore;

		public ShiftService(IShiftShiftStore shiftShiftStore) {
			_shiftShiftStore = shiftShiftStore;
		}



		public async Task<int> Delete(int id) {

			var found = _shiftShiftStore.FindById(id);
			found.IsDeleted = true;
			var res = await _shiftShiftStore.Update(found);

			return res;

		}

		public List<ShiftShift> FindByPortalId(int portalId) {

			List<ShiftShift>? res = _shiftShiftStore.GetAll().Where(pp => pp.PortalId == portalId).ToList();

			return res;

		}

		public IQueryable<ShiftShift> GetAll() {



			IQueryable<ShiftShift>? res = _shiftShiftStore.GetAll();

			return res;
		}

		public IQueryable<ShiftShift> GetByPortalId(int portalId) {
			//throw new NotImplementedException();
			IQueryable<ShiftShift>? res = _shiftShiftStore.GetAll().Where(pp => pp.PortalId == portalId);
			return res;

		}

		public async Task<int> Register(ShiftModel model) {

			ShiftShift shiftShift = new ShiftShift { Title = model.Title, PortalId = model.PortalId, ShiftType = model.ShiftType, StartTime = model.StartTime, EndTime = model.EndTime, IsDeleted = false };

			var res = await _shiftShiftStore.InsertAsync(shiftShift);
			return res;
		}

		public async Task<int> Update(ShiftModel model) {

			var found = _shiftShiftStore.FindById(model.Id);
			var res = 0;
			if (found != null) {

				found.Title = model.Title;
				found.StartTime = model.StartTime;
				found.EndTime = model.EndTime;
				found.ShiftType = model.ShiftType;
				found.PortalId = model.PortalId;
				res = await _shiftShiftStore.Update(found);

			}
			return res;
		}
	}
}
