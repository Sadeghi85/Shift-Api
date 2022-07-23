using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness {
	public interface IScriptSupervisorService {
		public Task<BaseResult> RegisterScriptSupervisorDescription(ScriptSupervisorDescriptionModel model);
		public Task<BaseResult> UpdateScriptSupervisorDescription(ScriptSupervisorDescriptionModel model);
		public Task<BaseResult> DeleteScriptSupervisorDescription(ScriptSupervisorDescriptionModel model);

		public Task<List<ShiftTabletScriptSupervisorDescription>>? GetAllScriptSupervisorDescription(ScriptSupervisorDescriptionSearchModel model, out Task<int> totalCount);

		public Task<BaseResult> RegisterTabletConductorChanges(TabletConductorChangesModel model);
		public Task<BaseResult> UpdateTabletConductorChanges(TabletConductorChangesModel model);
		public Task<List<ShiftTabletConductorChanx>>? GetAllTabletConductorChanges(TabletConductorChangesSearchModel model, out Task<int> totalCount);
		public Task<BaseResult> DeleteTabletConductorChanges(TabletConductorChangesModel model);

		public Task<BaseResult> RegisterShiftRevisionProblem(ShiftRevisionProblemModel model);
		public Task<List<ShiftRevisionProblem>>? GetAllShiftRevisionProblem(ShiftRevisionProblemSearchModel model, out Task<int> totalCount);
		public Task<BaseResult> UpdateShiftRevisionProblem(ShiftRevisionProblemModel model);
		public Task<BaseResult> DeleteShiftRevisionProblem(ShiftRevisionProblemModel model);

		//public int GetAllScriptSupervisorDescriptionTotalCount();
		//public int GetAllShiftRevisionProblemTotalCount();

		//public int GetAllTabletConductorChangesTotalCount();
	}
}
