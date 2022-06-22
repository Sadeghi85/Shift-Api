using Leopard.Bussiness.Model;
using Leopard.Bussiness.Model.ReturnModel;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Services.Interface {
	public interface IScriptSupervisorService {
		public Task<BaseResult> RegisterScriptSupervisorDescription(ScriptSupervisorDescriptionModel model);
		public Task<BaseResult> UpdateScriptSupervisorDescription(ScriptSupervisorDescriptionModel model);
		public Task<BaseResult> DeleteScriptSupervisorDescription(int id);

		public Task<List<ShiftTabletScriptSupervisorDescription>>? GetAllScriptSupervisorDescription(ScriptSupervisorDescriptionSearchModel model);

		public Task<BaseResult> RegisterTabletConductorChanges(TabletConductorChangesModel model);
		public Task<BaseResult> UpdateTabletConductorChanges(TabletConductorChangesModel model);
		public Task<List<ShiftTabletConductorChanx>>? GetAllTabletConductorChanges(TabletConductorChangesSearchModel model);
		public Task<BaseResult> DeleteTabletConductorChanges(int id);

		public Task<BaseResult> RegisterShiftRevisionProblem(ShiftRevisionProblemModel model);
		public Task<List<ShiftRevisionProblem>>? GetAllShiftRevisionProblem(ShiftRevisionProblemSearchModel model);
		public Task<BaseResult> UpdateShiftRevisionProblem(ShiftRevisionProblemModel model);
		public Task<BaseResult> DeleteShiftRevisionProblem(int id);

		public int GetAllScriptSupervisorDescriptionTotalCount();
		public int GetAllShiftRevisionProblemTotalCount();

		public int GetAllTabletConductorChangesTotalCount();
	}
}
