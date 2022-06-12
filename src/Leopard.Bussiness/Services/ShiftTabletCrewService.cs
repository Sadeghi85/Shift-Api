using Leopard.Bussiness.Model;
using Leopard.Bussiness.Services.Interface;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Services {
	public class ShiftTabletCrewService : IShiftTabletCrewService {

		readonly private IShiftShiftTabletCrewStore _shiftShiftTabletCrewStore;
		readonly private IShiftShiftTabletCrewReplacementStore _shiftShiftTabletCrewReplacementStore;

		public ShiftTabletCrewService(IShiftShiftTabletCrewStore shiftShiftTabletCrewStore, IShiftShiftTabletCrewReplacementStore shiftShiftTabletCrewReplacementStore) {
			_shiftShiftTabletCrewStore = shiftShiftTabletCrewStore;
			_shiftShiftTabletCrewReplacementStore = shiftShiftTabletCrewReplacementStore;
		}

		public async Task<int> Delete(int id) {


			var found = _shiftShiftTabletCrewStore.FindById(id);

			found.IsDeleted = true;
			var res = await _shiftShiftTabletCrewStore.Update(found);

			return res;

		}

		public IQueryable<ShiftShiftTabletCrew> GetAll() {
			IQueryable<ShiftShiftTabletCrew>? res = _shiftShiftTabletCrewStore.GetAll();

			return res;
		}

		public List<ShiftShiftTabletCrew> GetByShiftId(int shifTabletId) {

			List<ShiftShiftTabletCrew>? res = _shiftShiftTabletCrewStore.GetAll().Where(pp => pp.ShifTabletId == shifTabletId).ToList();

			return res;

		}

		public async Task<int> Register(ShiftTabletCrewModel model) {

			ShiftShiftTabletCrew shiftShiftTabletCrew = new ShiftShiftTabletCrew { AgentId = model.AgentId, EntranceTime = model.EntranceTime, ExitTime = model.ExitTime, IsReplaced = false, ResourceId = model.ResourceId, ShifTabletId = model.ShifTabletId };
			var res = await _shiftShiftTabletCrewStore.InsertAsync(shiftShiftTabletCrew);


			return res;
		}

		public async Task<int> Replace(int replaced, int replacedBy) {

			var found = _shiftShiftTabletCrewStore.FindById(replaced);
			if (found != null) {
				found.IsReplaced = true;
				_shiftShiftTabletCrewStore.Update(found).Wait();
			}
			var res = await _shiftShiftTabletCrewReplacementStore.InsertAsync(new ShiftShiftTabletCrewReplacement { ShiftTabletCrewId = replaced, ShiftTabletCrewIdReplaceMent = replacedBy });
			return res;

		}

		public async Task<int> Update(ShiftTabletCrewModel model) {

			var found = _shiftShiftTabletCrewStore.FindById(model.Id);

			found.ShifTabletId = model.ShifTabletId;
			found.EntranceTime = model.EntranceTime;
			found.ExitTime = model.ExitTime;
			found.ResourceId = model.ResourceId;
			found.AgentId = model.AgentId;

			var res = await _shiftShiftTabletCrewStore.Update(found);

			return res;


		}


	}



}
