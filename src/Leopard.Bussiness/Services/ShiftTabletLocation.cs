using Leopard.Bussiness.Model;
using Leopard.Bussiness.Model.ReturnModel;
using Leopard.Bussiness.Services.Interface;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Services {
	public class ShiftTabletLocationService : IShiftTabletLocationService {

		readonly private ShiftShiftTabletLocationStore _shiftShiftTabletLocationStore;

		private List<Expression<Func<ShiftShiftTabletLocation, bool>>> GetAllExpressions { get; set; } = new List<Expression<Func<ShiftShiftTabletLocation, bool>>>();

		public ShiftTabletLocationService(ShiftShiftTabletLocationStore shiftShiftTabletLocationStore) {
			_shiftShiftTabletLocationStore = shiftShiftTabletLocationStore;
		}

		public IQueryable<ShiftShiftTabletLocation> GetAll() {



			IQueryable<ShiftShiftTabletLocation>? res = _shiftShiftTabletLocationStore.GetAll();

			return res;
		}

		public Task<List<ShiftTabletLocationResult>>? GetAll(ShiftTabletLocationSearchModel model) {

			if (model.ShiftTabletId == 0 && string.IsNullOrWhiteSpace(model.ShiftTitle) && string.IsNullOrWhiteSpace(model.LocationTitle) && model.LocationId==0  ) {

				GetAllExpressions.Add(pp=> true);

			} else {
				if (model.ShiftTabletId != null) {
					GetAllExpressions.Add(pp => pp.ShiftTabletId==model.ShiftTabletId);
				}
				if (!string.IsNullOrWhiteSpace(model.ShiftTitle)) {
					GetAllExpressions.Add(pp=> model.ShiftTitle.Contains(pp.ShiftShiftTablet.ShiftShift.Title));
				}
				if (!string.IsNullOrWhiteSpace(model.LocationTitle)) {
					GetAllExpressions.Add(pp=> model.LocationTitle.Contains(pp.ShiftLocation.Title));
				}
				if (model.LocationId != 0) {
					GetAllExpressions.Add(pp => pp.LocationId==model.LocationId); 
				}
			}

			Task<List<ShiftTabletLocationResult>>? res = _shiftShiftTabletLocationStore.GetAllAsync(GetAllExpressions, pp => new ShiftTabletLocationResult { ShiftId = pp.ShiftShiftTablet.ShiftId.Value, ShiftTabletId = pp.ShiftTabletId.Value, ShiftTitle = pp.ShiftShiftTablet.ShiftShift.Title }, pp => pp.Id, "desc");


			return res;
		}

		public int GetAllTotalCount() {
			var res = _shiftShiftTabletLocationStore.TotalCount(GetAllExpressions);
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
