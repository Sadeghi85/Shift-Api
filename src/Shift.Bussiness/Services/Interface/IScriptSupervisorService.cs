using Shift.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Bussiness {
	public interface IScriptSupervisorService {
		public Task<BaseResult> RegisterScriptSupervisorDescription(ScriptSupervisorDescriptionModel model);
		public Task<BaseResult> UpdateScriptSupervisorDescription(ScriptSupervisorDescriptionModel model);
		public Task<BaseResult> DeleteScriptSupervisorDescription(ScriptSupervisorDescriptionModel model);

		public Task<StoreViewModel<ShiftTabletScriptSupervisorDescription>> GetAllScriptSupervisorDescription(ScriptSupervisorDescriptionSearchModel model);

		public Task<BaseResult> RegisterTabletConductorChanges(TabletConductorChangesModel model);
		public Task<BaseResult> UpdateTabletConductorChanges(TabletConductorChangesModel model);
		public Task<StoreViewModel<ShiftTabletConductorChanx>> GetAllTabletConductorChanges(TabletConductorChangesSearchModel model);
		public Task<BaseResult> DeleteTabletConductorChanges(TabletConductorChangesModel model);

		public Task<BaseResult> RegisterShiftRevisionProblem(ShiftRevisionProblemModel model);
		public Task<StoreViewModel<ShiftRevisionProblem>> GetAllShiftRevisionProblem(ShiftRevisionProblemSearchModel model);
		public Task<BaseResult> UpdateShiftRevisionProblem(ShiftRevisionProblemModel model);
		public Task<BaseResult> DeleteShiftRevisionProblem(ShiftRevisionProblemModel model);

	}
}
