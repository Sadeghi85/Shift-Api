using Shift.Bussiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shift.Api.Controllers.WebApi {

	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class AgentController : YaldaController {

		private readonly IAgentService _agentService;

		public AgentController(IAgentService agentService) {
			_agentService = agentService;
		}

		// GET: api/<AgentController>
		[HttpPost("GetAll")]
		public async Task<IActionResult> GetAll(AgentSearchModel model) {

			if (!ModelState.IsValid) {
				var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

				var errMsgs = string.Join(Environment.NewLine, allErrors);
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var ss = GetUserId();

			var res = await _agentService.GetAll(model);

			return Ok(OperationResult<List<AgentViewModel>>.SuccessResult(res.Result, res.TotalCount));
		}

		/// <summary>
		/// there is no relation in TelavatAgentResourceTypes to SAMT_Agents and SAMT_ResourceTypes
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPost("GetAgentByJobID")]
		public async Task<IActionResult> GetAgentByJobID(AgentByJobSearchModel model) {

			if (!ModelState.IsValid) {
				var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

				var errMsgs = string.Join(Environment.NewLine, allErrors);
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var res = await _agentService.GetAgentByJobID(model);

			return Ok(OperationResult<List<AgentViewModel>>.SuccessResult(res.Result, res.TotalCount));

		}





	}
}
