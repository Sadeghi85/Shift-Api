using Leopard.Bussiness.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leopard.Repository;
using Leopard.Bussiness.Model.ReturnModel;
using Leopard.Bussiness.Model;

namespace Leopard.Bussiness.Services {
	internal class ScriptSupervisorService:BaseService, IScriptSupervisorService {

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
				ShiftLog shiftLog = new ShiftLog { Message = ex.Message + " " + ex.InnerException != null ? ex.InnerException.Message : "" };

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
				if (foundScriptSupervisorDescription==null) {
					BaseResult.Success=false;
					BaseResult.Message = "رکورد مورد نظر جستجو نشد.";
				} else {
					foundScriptSupervisorDescription.ShiftTabletId = model.ShiftTabletId;
					foundScriptSupervisorDescription.Description = model.Description;
					await _scriptSupervisorDescriptionStore.Update(foundScriptSupervisorDescription);
				}

			} catch (Exception ex) {

				ShiftLog shiftLog = new ShiftLog { Message = ex.Message + " " + ex.InnerException != null ? ex.InnerException.Message : "" };
				//_shiftLogStore.ResetContext();

				var ss = await _shiftLogStore.InsertAsync(shiftLog);
				BaseResult.Success = false;
				base.BaseResult.Message = $"خطای سیستمی شماره {shiftLog.Id} لطفای به مدیر سیستم اطلاع دهید.";
			}

			return BaseResult;
		}



		public async Task<BaseResult> RegisterTabletConductorChanges(TabletConductorChangesModel model) {

			try {
				var foundTablet= _shiftShiftTabletStore.FindById(model.ShiftTabletId);
				if (foundTablet == null) {
					BaseResult.Success = false;
					BaseResult.Message = "لوح شیفت مورد نظر یافت نشد.";
				} else {

					ShiftTabletConductorChanx conductorChanx = new ShiftTabletConductorChanx { ProgramTitle = model.ProgramTitle, ReplacedProgramTitle = model.ReplacedProgramTitle, Description = model.Description, ShiftTabletId = model.ShiftTabletId };
					await _shiftTabletConductorChanxStore.InsertAsync(conductorChanx);

				}
			}	
			catch(Exception ex) {
				ShiftLog shiftLog = new ShiftLog { Message = ex.Message + " " + ex.InnerException != null ? ex.InnerException.Message : "" };

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
				}
				else {
					foundConductorChange.ProgramTitle = model.ProgramTitle;
					foundConductorChange.ReplacedProgramTitle = model.ReplacedProgramTitle;
					foundConductorChange.ShiftTabletId= model.ShiftTabletId;	
					foundConductorChange.Description= model.Description;

					await _shiftTabletConductorChanxStore.Update(foundConductorChange);
				}

			} catch (Exception ex) {

				ShiftLog shiftLog = new ShiftLog { Message = ex.Message + " " + ex.InnerException != null ? ex.InnerException.Message : "" };

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
						RevisorCode = model.RevisorCode,ShiftTabletId = model.ShiftTabletId
					};
				}

			} catch (Exception ex) {

				ShiftLog shiftLog = new ShiftLog { Message = ex.Message + " " + ex.InnerException != null ? ex.InnerException.Message : "" };

				//_shiftLogStore.ResetContext();

				var ss = await _shiftLogStore.InsertAsync(shiftLog);
				BaseResult.Success = false;
				base.BaseResult.Message = $"خطای سیستمی شماره {shiftLog.Id} لطفای به مدیر سیستم اطلاع دهید.";
			}

			return BaseResult;
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

				ShiftLog shiftLog = new ShiftLog { Message = ex.Message + " " + ex.InnerException != null ? ex.InnerException.Message : "" };

				//_shiftLogStore.ResetContext();

				var ss = await _shiftLogStore.InsertAsync(shiftLog);
				BaseResult.Success = false;
				base.BaseResult.Message = $"خطای سیستمی شماره {shiftLog.Id} لطفای به مدیر سیستم اطلاع دهید.";
			}

			return BaseResult;
		}




	}
}
