using Leopard.Bussiness.Model;
using Leopard.Bussiness.Model.ReturnModel;
using Leopard.Bussiness.Services.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SamtApi.Controllers.WebApi {
	[Route("api/[controller]")]
	[ApiController]
	public class AgentController : ControllerBase {

		private IAgentService _agentService;

		public AgentController(IAgentService agentService) {
			_agentService = agentService;
		}



		// GET: api/<AgentController>
		[HttpPost("GetAll")]
		public async Task<IActionResult> GetAll(AgentSearchModel model) {

			List<AgentResultModel>? res = await _agentService.GetAll(model);
			if (res.Count() > 0) {
				return Ok(OperationResult<List<AgentResultModel>>.SuccessResult(res, _agentService.GetAllTotal()));
			}
			return Ok(OperationResult<string>.FailureResult(""));

			
		}

		// GET api/<AgentController>/5
		[HttpGet("{id}")]
		public string Get(int id) {
			return "value";
		}

		// POST api/<AgentController>
		[HttpPost]
		public void Post([FromBody] string value) {
		}

		// PUT api/<AgentController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value) {
		}

		// DELETE api/<AgentController>/5
		[HttpDelete("{id}")]
		public void Delete(int id) {
		}
	}
}
