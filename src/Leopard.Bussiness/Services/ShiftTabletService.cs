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
	public class ShiftTabletService : IShiftTabletService {

		readonly private IShiftShiftTabletStore _shiftShiftTabletStore;
		readonly private IShiftShiftStore _shiftShiftStore;
		private List<Expression<Func<ShiftShiftTablet, bool>>> GetAllExpressions { get; set; } = new List<Expression<Func<ShiftShiftTablet, bool>>>();
		public ShiftTabletService(IShiftShiftTabletStore shiftShiftTabletStore, IShiftShiftStore shiftShiftStore) {
			_shiftShiftTabletStore = shiftShiftTabletStore;
			_shiftShiftStore = shiftShiftStore;
		}

		public List<ShiftShiftTablet> GetTabletShiftByPortalId(int portalId) {

			List<ShiftShiftTablet>? res = _shiftShiftTabletStore.GetAll().Where(pp => pp.ShiftShift.PortalId == portalId && pp.IsDeleted == false).ToList();

			return res;
		}

		public Task<List<ShiftTabletResult>>? GetAll(ShiftTabletSearchModel model) {

			if (model.ShiftId == 0 && model.ShiftDate == null && model.ProductionTypeId == 0) {
				GetAllExpressions.Add(pp => true);
			} else {
				if (model.ShiftId != 0) {
					GetAllExpressions.Add(pp => pp.ShiftId == model.ShiftId);
				}
				if (model.ShiftDate != null) {
					GetAllExpressions.Add(pp => pp.ShiftDate == model.ShiftDate);
				}
				if (model.ProductionTypeId != 0) {
					GetAllExpressions.Add((pp) => pp.ProductionTypeId == model.ProductionTypeId);
				}
			}
			Task<List<ShiftTabletResult>>? res =  _shiftShiftTabletStore.GetAllWithPagingAsync(GetAllExpressions, pp => new ShiftTabletResult {Id= pp.Id, ProductionTypeId= pp.ProductionTypeId, ProductionTypeTitle= pp.ShiftProductionType.Title , ShiftDate= pp.ShiftDate, ShiftTitle= pp.ShiftShift.Title, ShiftId= pp.ShiftId }, pp => pp.Id, model.PageSize, model.PageSize);
			
			//IQueryable<ShiftShiftTablet>? res = _shiftShiftTabletStore.GetAll();
			//_shiftShiftStore.GetAllAsync


			return res;
		}

		public int GetShiftTabletCount() {

			var res = _shiftShiftTabletStore.TotalCount(GetAllExpressions);
			return res;
		
		}



		public IQueryable<ShiftShiftTablet> GetAll() {
			return _shiftShiftTabletStore.GetAll();
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
