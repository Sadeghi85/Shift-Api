using Leopard.Repository;
using System.Linq.Expressions;
using System.Security.Principal;

namespace Leopard.Bussiness {
	public class ScriptSupervisorService : ServiceBase, IScriptSupervisorService {

		private readonly IShiftTabletScriptSupervisorDescriptionStore _scriptSupervisorDescriptionStore;
		private readonly IShiftLogStore _shiftLogStore;
		private readonly IShiftShiftTabletStore _shiftShiftTabletStore;
		private readonly IShiftTabletConductorChanxStore _shiftTabletConductorChanxStore;
		private readonly IShiftRevisionProblemStore _shiftRevisionProblemStore;

		private List<Expression<Func<ShiftTabletScriptSupervisorDescription, bool>>> GetAllScriptSupervisorDescriptionExpressions = new();
		private List<Expression<Func<ShiftTabletConductorChanx, bool>>> GetAllTabletConductorChangesExpressions = new();
		private List<Expression<Func<ShiftRevisionProblem, bool>>> GetAllShiftRevisionProblemExpressions = new();

		public ScriptSupervisorService(IPrincipal iPrincipal, IShiftTabletScriptSupervisorDescriptionStore scriptSupervisorDescriptionStore, IShiftLogStore shiftLogStore, IShiftShiftTabletStore shiftShiftTabletStore, IShiftTabletConductorChanxStore shiftTabletConductorChanxStore, IShiftRevisionProblemStore shiftRevisionProblemStore) : base(iPrincipal, shiftLogStore) {
			_scriptSupervisorDescriptionStore = scriptSupervisorDescriptionStore;
			_shiftLogStore = shiftLogStore;
			_shiftShiftTabletStore = shiftShiftTabletStore;
			_shiftTabletConductorChanxStore = shiftTabletConductorChanxStore;
			_shiftRevisionProblemStore = shiftRevisionProblemStore;
		}

		public async Task<BaseResult> RegisterScriptSupervisorDescription(ScriptSupervisorDescriptionModel model) {

			try {
				var foundShiftTablet = await _shiftShiftTabletStore.FindByIdAsync(model.ShiftTabletId);
				if (foundShiftTablet == null) {
					BaseResult.Success = false;
					BaseResult.Message = "لوح شیفت مورد نظر یافت نشد.";
				} else {
					var supervisorDescription = new ShiftTabletScriptSupervisorDescription { ShiftTabletId = model.ShiftTabletId, Description = model.Description };
					await _scriptSupervisorDescriptionStore.InsertAsync(supervisorDescription);
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

		public async Task<BaseResult> UpdateScriptSupervisorDescription(ScriptSupervisorDescriptionModel model) {

			try {
				var foundScriptSupervisorDescription = await _scriptSupervisorDescriptionStore.FindByIdAsync(model.Id);
				if (foundScriptSupervisorDescription == null) {
					BaseResult.Success = false;
					BaseResult.Message = "رکورد مورد نظر جستجو نشد.";
				} else {
					foundScriptSupervisorDescription.ShiftTabletId = model.ShiftTabletId;
					foundScriptSupervisorDescription.Description = model.Description;
					await _scriptSupervisorDescriptionStore.UpdateAsync(foundScriptSupervisorDescription);
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


		public async Task<BaseResult> DeleteScriptSupervisorDescription(ScriptSupervisorDescriptionModel model) {


			try {
				var foundScriptSupervisorDescription = await _scriptSupervisorDescriptionStore.FindByIdAsync(model.Id);
				if (foundScriptSupervisorDescription == null) {
					BaseResult.Success = false;
					BaseResult.Message = "رکورد مورد نظر جستجو نشد.";
				} else {
					foundScriptSupervisorDescription.IsDeleted = true;
					await _scriptSupervisorDescriptionStore.UpdateAsync(foundScriptSupervisorDescription);
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

		

		public async Task<StoreViewModel<ShiftTabletScriptSupervisorDescription>> GetAllScriptSupervisorDescription(ScriptSupervisorDescriptionSearchModel model) {

			GetAllScriptSupervisorDescriptionExpressions.Clear();

			if (model.Id != 0) {
				GetAllScriptSupervisorDescriptionExpressions.Add(pp => pp.Id == model.Id);
			}
			if (model.ShiftTabletId != 0) {
				GetAllScriptSupervisorDescriptionExpressions.Add(pp => pp.ShiftTabletId == model.ShiftTabletId);
			}
			if (model.CreateDateTime != null) {

				var inputDate = model.CreateDateTime.Value.Date;

				GetAllScriptSupervisorDescriptionExpressions.Add(pp => pp.CreateDateTime.Value.Date == model.CreateDateTime.Value.Date);
			}
			if (!string.IsNullOrWhiteSpace(model.Description)) {
				GetAllScriptSupervisorDescriptionExpressions.Add(pp => pp.Description.Contains(model.Description));

			}
			if (model.IsDeleted != null) {
				GetAllScriptSupervisorDescriptionExpressions.Add(pp => pp.IsDeleted == model.IsDeleted.Value);
			}


			GetAllScriptSupervisorDescriptionExpressions.Add(pp => pp.IsDeleted != true);

			var res = await _scriptSupervisorDescriptionStore.GetAllWithPagingAsync(GetAllScriptSupervisorDescriptionExpressions, pp => pp, pp => pp.CreateDateTime, model.Desc, model.PageSize, model.PageNo);


			return res;

		}

		public async Task<BaseResult> RegisterTabletConductorChanges(TabletConductorChangesModel model) {

			try {
				var foundTablet = await _shiftShiftTabletStore.FindByIdAsync(model.ShiftTabletId);
				if (foundTablet == null) {
					BaseResult.Success = false;
					BaseResult.Message = "لوح شیفت مورد نظر یافت نشد.";
				} else {

					var conductorChanx = new ShiftTabletConductorChanx { ProgramTitle = model.ProgramTitle, ReplacedProgramTitle = model.ReplacedProgramTitle, Description = model.Description, ShiftTabletId = model.ShiftTabletId.Value };
					await _shiftTabletConductorChanxStore.InsertAsync(conductorChanx);

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

		public async Task<BaseResult> UpdateTabletConductorChanges(TabletConductorChangesModel model) {

			try {

				var foudShiftTablet = await _shiftShiftTabletStore.FindByIdAsync(model.ShiftTabletId);
				var foundConductorChange = await _shiftTabletConductorChanxStore.FindByIdAsync(model.Id);
				if (foundConductorChange == null) {
					BaseResult.Success = false;
					BaseResult.Message = "رکورد مورد نظر جستجو نشد.";
					return BaseResult;
				}
				if (foudShiftTablet == null) {
					BaseResult.Success = false;
					BaseResult.Message = "لوح شیفت مورد نظر جستجو نشد.";
					return BaseResult;
				} else {
					foundConductorChange.ProgramTitle = model.ProgramTitle;
					foundConductorChange.ReplacedProgramTitle = model.ReplacedProgramTitle;
					foundConductorChange.ShiftTabletId = model.ShiftTabletId.Value;
					foundConductorChange.Description = model.Description;

					await _shiftTabletConductorChanxStore.UpdateAsync(foundConductorChange);
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

		

		public async Task<StoreViewModel<ShiftTabletConductorChanx>> GetAllTabletConductorChanges(TabletConductorChangesSearchModel model) {

			GetAllTabletConductorChangesExpressions.Clear();

			if (model.Id != 0) {
				GetAllTabletConductorChangesExpressions.Add(pp => pp.Id == model.Id);
			}
			if (!string.IsNullOrWhiteSpace(model.ProgramTitle)) {
				GetAllTabletConductorChangesExpressions.Add(pp => pp.ProgramTitle.Contains(model.ProgramTitle));
			}
			if (!string.IsNullOrWhiteSpace(model.ReplacedProgramTitle)) {
				GetAllTabletConductorChangesExpressions.Add(pp => pp.ReplacedProgramTitle.Contains(model.ReplacedProgramTitle));
			}
			if (model.ShiftTabletId != 0) {
				GetAllTabletConductorChangesExpressions.Add(pp => pp.ShiftTabletId == model.ShiftTabletId);
			}
			if (model.CreateDateTime != null) {
				GetAllTabletConductorChangesExpressions.Add(pp => pp.CreateDateTime.Value == model.CreateDateTime.Value.Date);
			}
			if (model.IsDeleted != null) {
				GetAllTabletConductorChangesExpressions.Add(pp => pp.IsDeleted == model.IsDeleted.Value);
			}


			GetAllTabletConductorChangesExpressions.Add(pp => pp.IsDeleted != true);

			var res = await _shiftTabletConductorChanxStore.GetAllWithPagingAsync(GetAllTabletConductorChangesExpressions, pp => pp, pp => pp.CreateDateTime, model.Desc, model.PageSize, model.PageNo);

			return res;

		}

		public async Task<BaseResult> DeleteTabletConductorChanges(TabletConductorChangesModel model) {

			try {
				var foundConductorChange = await _shiftTabletConductorChanxStore.FindByIdAsync(model.Id);
				if (foundConductorChange == null) {
					BaseResult.Success = false;
					BaseResult.Message = "رکورد مورد نظر جستجو نشد.";
					return BaseResult;
				} else {
					foundConductorChange.IsDeleted = true;

					await _shiftTabletConductorChanxStore.UpdateAsync(foundConductorChange);
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

		public async Task<BaseResult> RegisterShiftRevisionProblem(ShiftRevisionProblemModel model) {

			try {
				var foundShiftTablet = await _shiftShiftTabletStore.FindByIdAsync(model.ShiftTabletId);
				if (foundShiftTablet == null) {
					BaseResult.Success = false;
					BaseResult.Message = "لوح شیفت مورد نظر جستجو نشد.";
					return BaseResult;
				} else {
					ShiftRevisionProblem revisionProblem = new ShiftRevisionProblem {
						ClacketNo = model.ClacketNo.Value, ProgramName = model.FileName,
						Description = model.Description, FileNumber = model.FileNumber,
						ProblemDescription = model.ProblemDescription,
						RevisorCode = model.RevisorCode, ShiftTabletId = model.ShiftTabletId.Value
					};
					await _shiftRevisionProblemStore.InsertAsync(revisionProblem);
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

		

		public async Task<StoreViewModel<ShiftRevisionProblem>> GetAllShiftRevisionProblem(ShiftRevisionProblemSearchModel model) {

			GetAllShiftRevisionProblemExpressions.Clear();

			if (model.Id != 0) {
				GetAllShiftRevisionProblemExpressions.Add(pp => pp.Id == model.Id);
			}
			if (model.ClacketNo != 0) {
				GetAllShiftRevisionProblemExpressions.Add(pp => pp.ClacketNo == model.ClacketNo);
			}
			if (model.ShiftTabletId != 0) {
				GetAllShiftRevisionProblemExpressions.Add(pp => pp.ShiftTabletId == model.ShiftTabletId);
			}
			if (!string.IsNullOrWhiteSpace(model.FileNumber)) {
				GetAllShiftRevisionProblemExpressions.Add(pp => pp.FileNumber.Contains(model.FileNumber));
			}
			if (!string.IsNullOrWhiteSpace(model.FileName)) {
				GetAllShiftRevisionProblemExpressions.Add(pp => pp.ProgramName.Contains(model.FileName));
			}
			if (!string.IsNullOrWhiteSpace(model.RevisorCode)) {
				GetAllShiftRevisionProblemExpressions.Add(pp => pp.RevisorCode.Contains(model.RevisorCode));
			}
			if (!string.IsNullOrEmpty(model.Description)) {
				GetAllShiftRevisionProblemExpressions.Add(pp => pp.Description.Contains(model.Description));

			}
			if (model.CreateDateTime != null) {
				GetAllShiftRevisionProblemExpressions.Add(pp => pp.CreateDateTime.Value.Date == model.CreateDateTime.Value.Date);
			}

			if (model.IsDeleted != null) {
				GetAllShiftRevisionProblemExpressions.Add(pp => pp.IsDeleted == model.IsDeleted.Value);
			}

			GetAllShiftRevisionProblemExpressions.Add(pp => pp.IsDeleted != true);

			var res = await _shiftRevisionProblemStore.GetAllWithPagingAsync(GetAllShiftRevisionProblemExpressions, pp => pp, pp => pp.CreateDateTime, model.Desc, model.PageSize, model.PageNo);

			return res;

		}

		public async Task<BaseResult> UpdateShiftRevisionProblem(ShiftRevisionProblemModel model) {

			try {
				var foundShiftTblet = await _shiftShiftTabletStore.FindByIdAsync(model.ShiftTabletId);
				var foundRevision = await _shiftRevisionProblemStore.FindByIdAsync(model.Id);
				if (foundRevision == null) {
					BaseResult.Success = false;
					BaseResult.Message = "رکورد مورد نظر جستجو نشد.";
					return BaseResult;
				} else if (foundShiftTblet == null) {
					BaseResult.Success = false;
					BaseResult.Message = "لوح شیفت مورد نظر جستجو نشد.";
					return BaseResult;
				} else {
					foundRevision.ShiftTabletId = model.ShiftTabletId.Value;
					foundRevision.FileNumber = model.FileNumber;
					foundRevision.ProgramName = model.FileName;
					foundRevision.ClacketNo = model.ClacketNo.Value;
					foundRevision.RevisorCode = model.RevisorCode;
					foundRevision.Description = model.Description;

					await _shiftRevisionProblemStore.UpdateAsync(foundRevision);
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


		public async Task<BaseResult> DeleteShiftRevisionProblem(ShiftRevisionProblemModel model) {

			try {
				var foundRevision = await _shiftRevisionProblemStore.FindByIdAsync(model.Id);
				if (foundRevision == null) {
					BaseResult.Success = false;
					BaseResult.Message = "رکورد مورد نظر جستجو نشد.";
					return BaseResult;
				} else {
					foundRevision.IsDeleted = true;
					await _shiftRevisionProblemStore.UpdateAsync(foundRevision);
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
