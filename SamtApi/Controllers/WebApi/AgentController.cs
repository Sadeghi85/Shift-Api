using Leopard.Bussiness.Model;
using Leopard.Bussiness.Model.ReturnModel;
using Leopard.Bussiness.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SamtApi.Controllers.WebApi {

	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class AgentController : YaldaController {

		private IAgentService _agentService;

		public AgentController(IAgentService agentService) {
			_agentService = agentService;
		}



		// GET: api/<AgentController>
		[HttpPost("GetAll")]
		public async Task<IActionResult> GetAll(AgentSearchModel model) {

			var ss = GetUserId();

			List<AgentResultModel>? res = await _agentService.GetAll(model);

			return Ok(OperationResult<List<AgentResultModel>>.SuccessResult(res, _agentService.GetAllTotal()));
		}

		
		
	}
}
