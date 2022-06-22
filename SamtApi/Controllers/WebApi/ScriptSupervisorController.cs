using Leopard.Bussiness.Model;
using Leopard.Bussiness.Model.ReturnModel;
using Leopard.Bussiness.Services.Interface;
using Leopard.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SamtApi.Controllers.WebApi {
	[Route("api/[controller]")]
	[ApiController]
	public class ScriptSupervisorController : ControllerBase {

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
		public async Task<IActionResult> DeleteScriptSupervisorDescription(int id) {

			BaseResult? res = await _scriptSupervisorService.DeleteScriptSupervisorDescription(id);
			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));
		}

		[HttpPost("GetAllScriptSupervisorDescription")]
		public async Task<IActionResult> GetAllScriptSupervisorDescription(ScriptSupervisorDescriptionSearchModel model) {

			List<ShiftTabletScriptSupervisorDescription>? res = await _scriptSupervisorService.GetAllScriptSupervisorDescription(model);
			return Ok(OperationResult<List<ShiftTabletScriptSupervisorDescription>?>.SuccessResult(res, _scriptSupervisorService.GetAllScriptSupervisorDescriptionTotalCount()));
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

			List<ShiftTabletConductorChanx>? res =await _scriptSupervisorService.GetAllTabletConductorChanges(model);
			return Ok(OperationResult<List<ShiftTabletConductorChanx>?>.SuccessResult(res, _scriptSupervisorService.GetAllTabletConductorChangesTotalCount()));
		}

		[HttpPost("DeleteTabletConductorChanges")]
		public async Task<IActionResult> DeleteTabletConductorChanges(int id) {

			BaseResult? res = await _scriptSupervisorService.DeleteTabletConductorChanges(id);
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

			List<ShiftRevisionProblem>? res =await _scriptSupervisorService.GetAllShiftRevisionProblem(model);
			return Ok(OperationResult<List<ShiftRevisionProblem>?>.SuccessResult(res, _scriptSupervisorService.GetAllShiftRevisionProblemTotalCount()));
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
		public async Task<IActionResult> DeleteShiftRevisionProblem(int id) {

			BaseResult? res = await _scriptSupervisorService.DeleteShiftRevisionProblem(id);
			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));
		}

		// GET: api/<ScriptSupervisorController>
		[HttpGet]
		public IEnumerable<string> Get() {
			return new string[] { "value1", "value2" };
		}

		// GET api/<ScriptSupervisorController>/5
		[HttpGet("{id}")]
		public string Get(int id) {
			return "value";
		}

		// POST api/<ScriptSupervisorController>
		[HttpPost]
		public void Post([FromBody] string value) {
		}

		// PUT api/<ScriptSupervisorController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value) {
		}

		// DELETE api/<ScriptSupervisorController>/5
		[HttpDelete("{id}")]
		public void Delete(int id) {
		}
	}
}
