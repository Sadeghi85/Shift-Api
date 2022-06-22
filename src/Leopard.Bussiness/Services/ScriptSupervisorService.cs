using Leopard.Bussiness.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leopard.Repository;
using Leopard.Bussiness.Model.ReturnModel;
using Leopard.Bussiness.Model;
using System.Linq.Expressions;

namespace Leopard.Bussiness.Services {
	internal class ScriptSupervisorService : BaseService, IScriptSupervisorService {

		private readonly IShiftTabletScriptSupervisorDescriptionStore _scriptSupervisorDescriptionStore;
		private readonly IShiftLogStore _shiftLogStore;
		private readonly IShiftShiftTabletStore _shiftShiftTabletStore;
		private readonly IShiftTabletConductorChanxStore _shiftTabletConductorChanxStore;
		private readonly IShiftRevisionProblemStore _shiftRevisionProblemStore;

		public ScriptSupervisorService(IShiftTabletScriptSupervisorDescriptionStore scriptSupervisorDescriptionStore, IShiftLogStore shiftLogStore, IShiftShiftTabletStore shiftShiftTabletStore, IShiftTabletConductorChanxStore shiftTabletConductorChanxStore, IShiftRevisionProblemStore shiftRevisionProblemStore) {
			_scriptSupervisorDescriptionStore = scriptSupervisorDescriptionStore;
			_shiftLogStore = shiftLogStore;
			_shiftShiftTabletStore = shiftShiftTabletStore;
			_shiftTabletConductorChanxStore = shiftTabletConductorChanxStore;
			_shiftRevisionProblemStore = shiftRevisionProblemStore;
		}

		public async Task<BaseResult> RegisterScriptSupervisorDescription(ScriptSupervisorDescriptionModel model) {

			try {
				var foundShiftTablet = _shiftShiftTabletStore.FindById(model.ShiftTabletId);
				if (foundShiftTablet == null) {
					BaseResult.Success = false;
					BaseResult.Message = "لوح شیفت مورد نظر یافت نشد.";
				} else {
					ShiftTabletScriptSupervisorDescription supervisorDescription = new ShiftTabletScriptSupervisorDescription { ShiftTabletId = model.ShiftTabletId, Description = model.Description };
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
				var foundScriptSupervisorDescription = _scriptSupervisorDescriptionStore.FindById(model.Id);
				if (foundScriptSupervisorDescription == null) {
					BaseResult.Success = false;
					BaseResult.Message = "رکورد مورد نظر جستجو نشد.";
				} else {
					foundScriptSupervisorDescription.ShiftTabletId = model.ShiftTabletId;
					foundScriptSupervisorDescription.Description = model.Description;
					await _scriptSupervisorDescriptionStore.Update(foundScriptSupervisorDescription);
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


		public async Task<BaseResult> DeleteScriptSupervisorDescription(int id) {


			try {
				var foundScriptSupervisorDescription = _scriptSupervisorDescriptionStore.FindById(id);
				if (foundScriptSupervisorDescription == null) {
					BaseResult.Success = false;
					BaseResult.Message = "رکورد مورد نظر جستجو نشد.";
				} else {
					foundScriptSupervisorDescription.IsDeleted = true;
					await _scriptSupervisorDescriptionStore.Update(foundScriptSupervisorDescription);
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

		List<Expression<Func<ShiftTabletScriptSupervisorDescription, bool>>> GetAllScriptSupervisorDescriptionExpressions = new List<Expression<Func<ShiftTabletScriptSupervisorDescription, bool>>>();

		public Task<List<ShiftTabletScriptSupervisorDescription>>? GetAllScriptSupervisorDescription(ScriptSupervisorDescriptionSearchModel model) {

			if (model.Id == 0 && model.ShiftTabletId == 0 && model.CreateDateTime == null && string.IsNullOrWhiteSpace(model.Description)) {

				GetAllScriptSupervisorDescriptionExpressions.Add(pp => true);
			} else {
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
					GetAllScriptSupervisorDescriptionExpressions.Add(pp => model.Description.Contains(pp.Description));

				}

			}

			Task<List<ShiftTabletScriptSupervisorDescription>>? res = _scriptSupervisorDescriptionStore.GetAllWithPagingAsync(GetAllScriptSupervisorDescriptionExpressions, pp => pp, pp => pp.CreateDateTime, model.PageSize, model.PageNo);


			return res;

		}

		public int GetAllScriptSupervisorDescriptionTotalCount() {
			var res = _scriptSupervisorDescriptionStore.TotalCount(GetAllScriptSupervisorDescriptionExpressions);
			return res;
		}



		public async Task<BaseResult> RegisterTabletConductorChanges(TabletConductorChangesModel model) {

			try {
				var foundTablet = _shiftShiftTabletStore.FindById(model.ShiftTabletId);
				if (foundTablet == null) {
					BaseResult.Success = false;
					BaseResult.Message = "لوح شیفت مورد نظر یافت نشد.";
				} else {

					ShiftTabletConductorChanx conductorChanx = new ShiftTabletConductorChanx { ProgramTitle = model.ProgramTitle, ReplacedProgramTitle = model.ReplacedProgramTitle, Description = model.Description, ShiftTabletId = model.ShiftTabletId };
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

				var foudShiftTablet = _shiftShiftTabletStore.FindById(model.ShiftTabletId);
				var foundConductorChange = _shiftTabletConductorChanxStore.FindById(model.Id);
				if (foundConductorChange == null) {
					BaseResult.Success = false;
					BaseResult.Message = "رکورد مورد نظر جستجو نشد.";
				}
				if (foudShiftTablet == null) {
					BaseResult.Success = false;
					BaseResult.Message = "لوح شیفت مورد نظر جستجو نشد.";
				} else {
					foundConductorChange.ProgramTitle = model.ProgramTitle;
					foundConductorChange.ReplacedProgramTitle = model.ReplacedProgramTitle;
					foundConductorChange.ShiftTabletId = model.ShiftTabletId;
					foundConductorChange.Description = model.Description;

					await _shiftTabletConductorChanxStore.Update(foundConductorChange);
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

		List<Expression<Func<ShiftTabletConductorChanx, bool>>> GetAllTabletConductorChangesExpressions = new List<Expression<Func<ShiftTabletConductorChanx, bool>>>();

		public Task<List<ShiftTabletConductorChanx>>? GetAllTabletConductorChanges(TabletConductorChangesSearchModel model) {

			if (model.Id == 0 && string.IsNullOrWhiteSpace(model.ProgramTitle) && string.IsNullOrWhiteSpace(model.ReplacedProgramTitle) && model.ShiftTabletId == 0 && model.CreateDateTime == null) {

				GetAllTabletConductorChangesExpressions.Add(pp => true);


			} else {
				if (model.Id != 0) {
					GetAllTabletConductorChangesExpressions.Add(pp => pp.Id == model.Id);
				}
				if (!string.IsNullOrWhiteSpace(model.ProgramTitle)) {
					GetAllTabletConductorChangesExpressions.Add(pp => model.ProgramTitle.Contains(pp.ProgramTitle));
				}
				if (!string.IsNullOrWhiteSpace(model.ReplacedProgramTitle)) {
					GetAllTabletConductorChangesExpressions.Add(pp => model.ReplacedProgramTitle.Contains(pp.ReplacedProgramTitle));
				}
				if (model.ShiftTabletId != 0) {
					GetAllTabletConductorChangesExpressions.Add(pp => pp.ShiftTabletId == model.ShiftTabletId);
				}
				if (model.CreateDateTime != null) {
					GetAllTabletConductorChangesExpressions.Add(pp => pp.CreateDateTime.Value == model.CreateDateTime.Value.Date);
				}

			}
			Task<List<ShiftTabletConductorChanx>>? res = _shiftTabletConductorChanxStore.GetAllWithPagingAsync(GetAllTabletConductorChangesExpressions, pp => pp, pp => pp.CreateDateTime, model.PageSize, model.PageNo);
			return res;

		}

		public int GetAllTabletConductorChangesTotalCount() {
			var res= _shiftTabletConductorChanxStore.TotalCount(GetAllTabletConductorChangesExpressions);
			return res;
		}

		public async Task<BaseResult> DeleteTabletConductorChanges(int id) {

			try {
				var foundConductorChange = _shiftTabletConductorChanxStore.FindById(id);
				if (foundConductorChange == null) {
					BaseResult.Success = false;
					BaseResult.Message = "رکورد مورد نظر جستجو نشد.";
				} else {
					foundConductorChange.IsDeleted = true;

					await _shiftTabletConductorChanxStore.Update(foundConductorChange);
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
				var foundShiftTablet = _shiftShiftTabletStore.FindById(model.ShiftTabletId);
				if (foundShiftTablet == null) {
					BaseResult.Success = false;
					BaseResult.Message = "لوح شیفت مورد نظر جستجو نشد.";
				} else {
					ShiftRevisionProblem revisionProblem = new ShiftRevisionProblem {
						ClacketNo = model.ClacketNo, FileName = model.FileName,
						Description = model.Description, FileNumber = model.FileNumber,
						ProblemDescription = model.ProblemDescription,
						RevisorCode = model.RevisorCode, ShiftTabletId = model.ShiftTabletId
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

		List<Expression<Func<ShiftRevisionProblem, bool>>> GetAllShiftRevisionProblemExpressions = new List<Expression<Func<ShiftRevisionProblem, bool>>>();

		public Task<List<ShiftRevisionProblem>>? GetAllShiftRevisionProblem(ShiftRevisionProblemSearchModel model) {

			if (model.Id == 0 && model.ClacketNo == 0 && model.ShiftTabletId == 0 && string.IsNullOrWhiteSpace(model.FileNumber) && string.IsNullOrWhiteSpace(model.FileName) && string.IsNullOrWhiteSpace(model.RevisorCode) && string.IsNullOrWhiteSpace(model.Description) && model.CreateDateTime == null) {
				GetAllShiftRevisionProblemExpressions.Add(pp => true);


			} else {
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
					GetAllShiftRevisionProblemExpressions.Add(pp => model.FileNumber.Contains(pp.FileNumber));
				}
				if (!string.IsNullOrWhiteSpace(model.FileName)) {
					GetAllShiftRevisionProblemExpressions.Add(pp => model.FileName.Contains(pp.FileName));
				}
				if (!string.IsNullOrWhiteSpace(model.RevisorCode)) {
					GetAllShiftRevisionProblemExpressions.Add(pp => model.RevisorCode.Contains(pp.RevisorCode));
				}
				if (!string.IsNullOrEmpty(model.Description)) {
					GetAllShiftRevisionProblemExpressions.Add(pp => model.Description.Contains(pp.Description));

				}
				if (model.CreateDateTime != null) {
					GetAllShiftRevisionProblemExpressions.Add(pp => pp.CreateDateTime.Value.Date == model.CreateDateTime.Value.Date);
				}


			}
			Task<List<ShiftRevisionProblem>>? res = _shiftRevisionProblemStore.GetAllWithPagingAsync(GetAllShiftRevisionProblemExpressions, pp => pp, pp => pp.CreateDateTime, model.PageSize, model.PageNo);

			return res;

		}

		public int GetAllShiftRevisionProblemTotalCount() {
			var res = _shiftRevisionProblemStore.TotalCount(GetAllShiftRevisionProblemExpressions);
			return res;
		}

		public async Task<BaseResult> UpdateShiftRevisionProblem(ShiftRevisionProblemModel model) {

			try {
				var foundShiftTblet = _shiftShiftTabletStore.FindById(model.ShiftTabletId);
				var foundRevision = _shiftRevisionProblemStore.FindById(model.Id);
				if (foundRevision == null) {
					BaseResult.Success = false;
					BaseResult.Message = "رکورد مورد نظر جستجو نشد.";
				} else if (foundShiftTblet == null) {
					BaseResult.Success = false;
					BaseResult.Message = "لوح شیفت مورد نظر جستجو نشد.";
				} else {
					foundRevision.ShiftTabletId = model.ShiftTabletId;
					foundRevision.FileNumber = model.FileNumber;
					foundRevision.FileName = model.FileName;
					foundRevision.ClacketNo = model.ClacketNo;
					foundRevision.RevisorCode = model.RevisorCode;
					foundRevision.Description = model.Description;

					_shiftRevisionProblemStore.Update(foundRevision);
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


		public async Task<BaseResult> DeleteShiftRevisionProblem(int id) {

			try {
				var foundRevision = _shiftRevisionProblemStore.FindById(id);
				if (foundRevision == null) {
					BaseResult.Success = false;
					BaseResult.Message = "رکورد مورد نظر جستجو نشد.";
				} else {
					foundRevision.IsDeleted = true;
					await _shiftRevisionProblemStore.Update(foundRevision);
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
