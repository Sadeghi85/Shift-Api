using Leopard.Bussiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SamtApi.Controllers.WebApi {

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

			var ss = GetUserId();

			if (model == null) {
				return null;
			}

			Task<int> totalCount;

			var res = await _agentService.GetAll(model, out totalCount);
			var resCount = await totalCount;

			//return Ok(OperationResult<List<AgentViewModel>>.SuccessResult(res, _agentService.GetAllTotal()));

			return Ok(OperationResult<List<AgentViewModel>>.SuccessResult(res, resCount));
		}
		/// <summary>
		/// there is no relation in TelavatAgentResourceTypes to SAMT_Agents and SAMT_ResourceTypes
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> GetAgentByResourceTypeID(GetAgentByResourceTypeIDModel model) {

			Task<int> totalCount;

			var res = await _agentService.GetAgentByResourceTypeID(model, out totalCount);
			var resCount = await totalCount;

			return Ok(OperationResult<List<GetAgentByResourceTypeIDResult>?>.SuccessResult(res, resCount));

		}





	}
}
