using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness {
	public class ShiftCrewRewardFineService : ServiceBase, IShiftCrewRewardFineService {

		readonly private IShiftCrewRewardFineStore _shiftCrewRewardFineStore;
		readonly private IShiftLogStore _shiftLogStore;

		List<Expression<Func<ShiftCrewRewardFine, bool>>> Expressions = new List<Expression<Func<ShiftCrewRewardFine, bool>>>();


		public ShiftCrewRewardFineService(IPrincipal iPrincipal, IShiftCrewRewardFineStore shiftCrewRewardFineStore, IShiftLogStore shiftLogStore) : base(iPrincipal) {
			_shiftCrewRewardFineStore = shiftCrewRewardFineStore;
			_shiftLogStore = shiftLogStore;
		}

		public async Task<BaseResult> Delete(ShiftCrewRewardFineInputModel model) {

			try {
				var found = _shiftCrewRewardFineStore.FindById(model.Id);
				if (found == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه مورد نظر شناسایی نشد.";
				} else {
					found.IsDeleted = true;
					var res = await _shiftCrewRewardFineStore.Update(found);
				}
			} catch (Exception ex) {

				ShiftLog shiftLog = new ShiftLog { Message = ex.Message + " " + ex.InnerException?.Message ?? ex.Message };

				//_shiftLogStore.ResetContext();

				var ss = await _shiftLogStore.InsertAsync(shiftLog);
				BaseResult.Success = false;
				base.BaseResult.Message = $"خطای سیستمی شماره {shiftLog.Id} لطفای به مدیر سیستم اطلاع دهید.";
			}





			return BaseResult;

		}

		//public IQueryable<ShiftCrewRewardFine> GetAll() {
		//	throw new NotImplementedException();
		//}

		public Task<List<ShiftCrewRewardFine>>? GetAll(ShiftCrewRewardFineSearchModel model, out int totalCount) {



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
				if (model.IsDeleted != null) {
					Expressions.Add(pp => pp.IsDeleted == model.IsDeleted);
				}
				//expressions.Add(pp=> pp.IsDeleted==false);

			}
			Expressions.Add(pp => pp.IsDeleted != true);
			Task<List<ShiftCrewRewardFine>>? res = _shiftCrewRewardFineStore.GetAllWithPagingAsync(Expressions, pp => new ShiftCrewRewardFine { Id = pp.Id, Ammount = pp.Ammount }, pp => pp.Id, model.PageSize, model.PageNo, "desc", out totalCount);



			//_shiftCrewRewardFineStore.GetAllAsync()

			return res;
		}



		public async Task<BaseResult> Register(ShiftCrewRewardFineInputModel model) {



			try {
				ShiftCrewRewardFine shiftCrewRewardFine = new ShiftCrewRewardFine { ShiftTabletCrewId = model.ShiftTabletCrewId.Value, IsReward = model.IsReward.Value, IsDeleted = false, Ammount = model.Ammount.Value, Shiftpercentage = model.Shiftpercentage.Value, Description = model.Description };
				var res = await _shiftCrewRewardFineStore.InsertAsync(shiftCrewRewardFine);
			} catch (Exception ex) {

				ShiftLog shiftLog = new ShiftLog { Message = ex.Message + " " + ex.InnerException?.Message ?? ex.Message };

				//_shiftLogStore.ResetContext();

				var ss = await _shiftLogStore.InsertAsync(shiftLog);
				BaseResult.Success = false;
				base.BaseResult.Message = $"خطای سیستمی شماره {shiftLog.Id} لطفای به مدیر سیستم اطلاع دهید.";
			}


			return BaseResult;
		}

		public async Task<BaseResult> Update(ShiftCrewRewardFineInputModel model) {

			try {
				var found = _shiftCrewRewardFineStore.FindById(model.Id);
				var res = 0;
				if (found == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه مورد نظر شناسایی نشد.";
				} else {
					found.ShiftTabletCrewId = model.ShiftTabletCrewId.Value;
					found.IsReward = model.IsReward.Value;
					found.Ammount = model.Ammount.Value;
					found.Shiftpercentage = model.Shiftpercentage.Value;
					found.Description = model.Description;
					res = await _shiftCrewRewardFineStore.Update(found);

				}
			} catch (Exception ex) {

				ShiftLog shiftLog = new ShiftLog { Message = ex.Message + " " + ex.InnerException?.Message ?? ex.Message };

				//_shiftLogStore.ResetContext();

				var ss = await _shiftLogStore.InsertAsync(shiftLog);
				BaseResult.Success = false;
				base.BaseResult.Message = $"خطای سیستمی شماره {shiftLog.Id} لطفای به مدیر سیستم اطلاع دهید.";
			}
			return BaseResult;
		}
	}
}
