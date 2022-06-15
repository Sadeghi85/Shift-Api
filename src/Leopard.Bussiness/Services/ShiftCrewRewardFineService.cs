using Leopard.Bussiness.Model;
using Leopard.Bussiness.Services.Interface;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Services {
	public class ShiftCrewRewardFineService : IShiftCrewRewardFineService {

		readonly private IShiftCrewRewardFineStore _shiftCrewRewardFineStore;
		List<Expression<Func<ShiftCrewRewardFine, bool>>> Expressions = new List<Expression<Func<ShiftCrewRewardFine, bool>>>();

		public ShiftCrewRewardFineService(IShiftCrewRewardFineStore shiftCrewRewardFineStore) {
			_shiftCrewRewardFineStore = shiftCrewRewardFineStore;
		}

		public async Task<int> Delete(int id) {

			var found = _shiftCrewRewardFineStore.FindById(id);
			found.IsDeleted = true;
			var res = await _shiftCrewRewardFineStore.Update(found);





			return res;

		}

		public IQueryable<ShiftCrewRewardFine> GetAll() {
			throw new NotImplementedException();
		}

		public Task<List<ShiftCrewRewardFine>>? GetAll(ShiftCrewRewardFineSearchModel model) {

			

			if (model.IsRewardFine == null && model.RewardFineDate == null && string.IsNullOrWhiteSpace(model.Description) && string.IsNullOrWhiteSpace(model.CrewName)) {
				Expressions.Add(pp => true);
			} else {
				if (model.IsRewardFine != null) {
					Expressions.Add(pp => pp.IsReward == model.IsRewardFine);
				}
				if (model.RewardFineDate != null) {
					Expressions.Add(pp => pp.CreateDateTime.Value.ToShortDateString() == model.RewardFineDate.Value.ToShortDateString());
				}
				if (!string.IsNullOrWhiteSpace(model.Description)) {
					Expressions.Add(pp => pp.Description.Contains(model.Description));
				}
				if (!string.IsNullOrWhiteSpace(model.CrewName)) {
					Expressions.Add(pp => model.CrewName.Contains(pp.ShiftShiftTabletCrew.SamtAgent.FirstName) || model.CrewName.Contains(pp.ShiftShiftTabletCrew.SamtAgent.LastName));
				}
				//expressions.Add(pp=> pp.IsDeleted==false);

			}

			Task<List<ShiftCrewRewardFine>>? res = _shiftCrewRewardFineStore.GetAllWithPagingAsync(Expressions, pp => new ShiftCrewRewardFine {Id= pp.Id , Ammount= pp.Ammount }, pp=> pp.Id , model.PageSize,model.PageNo );



			//_shiftCrewRewardFineStore.GetAllAsync()

			return res;
		}

		

		public async Task<int> Register(ShiftCrewRewardFineModel model) {

			ShiftCrewRewardFine shiftCrewRewardFine = new ShiftCrewRewardFine { ShiftTabletCrewId = model.ShiftTabletCrewId, IsReward = model.IsReward, IsDeleted = false, Ammount = model.Ammount, Shiftpercentage = model.Shiftpercentage, Description = model.Description };
			var res = await _shiftCrewRewardFineStore.InsertAsync(shiftCrewRewardFine);

			return res;
		}

		public async Task<int> Update(ShiftCrewRewardFineModel model) {

			var found = _shiftCrewRewardFineStore.FindById(model.Id);
			var res = 0;
			if (found != null) {
				found.ShiftTabletCrewId = model.ShiftTabletCrewId;
				found.IsReward = model.IsReward;
				found.Ammount = model.Ammount;
				found.Shiftpercentage = model.Shiftpercentage;
				found.Description = model.Description;
				res = await _shiftCrewRewardFineStore.Update(found);

			}
			return res;
		}
	}
}
