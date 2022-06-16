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
	public class ShiftLocationService : IShiftLocationService {

		readonly private IShiftLocationStore _shiftLocationStore;
		private List<Expression<Func<ShiftLocation, bool>>> Expressions { get; set; } = new List<Expression<Func<ShiftLocation, bool>>>();

		public ShiftLocationService(IShiftLocationStore shiftLocationStore) {
			_shiftLocationStore = shiftLocationStore;
			
		}
		

		public Task<List<ShiftLocationReturnModel>> GetAll(ShiftLocationSearchModel model) {


			if (string.IsNullOrWhiteSpace( model.Title) && model.PortalId==0) {
				Expressions.Add(pp => true);

			} else {
				if(!string.IsNullOrWhiteSpace(model.Title)) {
					Expressions.Add(pp => model.Title.Contains(pp.Title));
				}
				if (model.PortalId != 0) {
					Expressions.Add(pp => pp.PortalId == model.PortalId);
				}
			}

			//var resCnt = _shiftLocationStore.TotalCount(Expressions);

			var res = _shiftLocationStore.GetAllWithPagingAsync(Expressions, pp => new ShiftLocationReturnModel { Id = pp.Id, PortalId = pp.PortalId.Value, Title=pp.Title , PortalTitle = pp.Portal.Title }, pp=> pp.Id,model.PageSize,model.PageNo, "desc");

			return res;

		}

		public int GetAllTotal() {
			var res = _shiftLocationStore.TotalCount(Expressions);
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
