using Shift.Bussiness;
using Shift.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shift.Api.Controllers.WebApi {
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class ScriptSupervisorController : YaldaController {

		private readonly IScriptSupervisorService _scriptSupervisorService;

		public ScriptSupervisorController(IScriptSupervisorService scriptSupervisorService) {
			_scriptSupervisorService = scriptSupervisorService;
		}



		[HttpPost("RegisterScriptSupervisorDescription")]
		public async Task<IActionResult> RegisterScriptSupervisorDescription(ScriptSupervisorDescriptionModel model) {

			BaseResult? res = await _scriptSupervisorService.RegisterScriptSupervisorDescription(model);
			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));
		}

		[HttpPost("UpdateScriptSupervisorDescription")]
		public async Task<IActionResult> UpdateScriptSupervisorDescription(ScriptSupervisorDescriptionModel model) {

			BaseResult? res = await _scriptSupervisorService.UpdateScriptSupervisorDescription(model);
			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));
		}

		[HttpPost("DeleteScriptSupervisorDescription")]
		public async Task<IActionResult> DeleteScriptSupervisorDescription(ScriptSupervisorDescriptionModel model) {

			var res = await _scriptSupervisorService.DeleteScriptSupervisorDescription(model);
			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));
		}

		[HttpPost("GetAllScriptSupervisorDescription")]
		public async Task<IActionResult> GetAllScriptSupervisorDescription(ScriptSupervisorDescriptionSearchModel model) {


			var res = await _scriptSupervisorService.GetAllScriptSupervisorDescription(model);

			return Ok(OperationResult<List<ShiftTabletScriptSupervisorDescription>>.SuccessResult(res.Result, res.TotalCount));
		}


		[HttpPost("RegisterTabletConductorChanges")]
		public async Task<IActionResult> RegisterTabletConductorChanges(TabletConductorChangesModel model) {

			BaseResult? res = await _scriptSupervisorService.RegisterTabletConductorChanges(model);
			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));
		}

		[HttpPost("UpdateTabletConductorChanges")]
		public async Task<IActionResult> UpdateTabletConductorChanges(TabletConductorChangesModel model) {

			BaseResult? res = await _scriptSupervisorService.UpdateTabletConductorChanges(model);
			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));
		}


		[HttpPost("GetAllTabletConductorChanges")]
		public async Task<IActionResult> GetAllTabletConductorChanges(TabletConductorChangesSearchModel model) {


			var res = await _scriptSupervisorService.GetAllTabletConductorChanges(model);

			return Ok(OperationResult<List<ShiftTabletConductorChanx>>.SuccessResult(res.Result, res.TotalCount));
		}

		[HttpPost("DeleteTabletConductorChanges")]
		public async Task<IActionResult> DeleteTabletConductorChanges(TabletConductorChangesModel model) {

			BaseResult? res = await _scriptSupervisorService.DeleteTabletConductorChanges(model);
			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));
		}

		[HttpPost("RegisterShiftRevisionProblem")]
		public async Task<IActionResult> RegisterShiftRevisionProblem(ShiftRevisionProblemModel model) {

			BaseResult? res = await _scriptSupervisorService.RegisterShiftRevisionProblem(model);
			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));
		}

		[HttpPost("GetAllShiftRevisionProblem")]
		public async Task<IActionResult> GetAllShiftRevisionProblem(ShiftRevisionProblemSearchModel model) {



			var res = await _scriptSupervisorService.GetAllShiftRevisionProblem(model);

			return Ok(OperationResult<List<ShiftRevisionProblem>>.SuccessResult(res.Result, res.TotalCount));
			//return Ok(res);
		}


		[HttpPost("UpdateShiftRevisionProblem")]
		public async Task<IActionResult> UpdateShiftRevisionProblem(ShiftRevisionProblemModel model) {

			BaseResult? res = await _scriptSupervisorService.UpdateShiftRevisionProblem(model);
			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));
		}



		[HttpPost("DeleteShiftRevisionProblem")]
		public async Task<IActionResult> DeleteShiftRevisionProblem(ShiftRevisionProblemModel model) {

			BaseResult? res = await _scriptSupervisorService.DeleteShiftRevisionProblem(model);
			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));
		}

	}
}
