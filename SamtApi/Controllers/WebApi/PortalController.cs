using Leopard.Bussiness.Model;
using Leopard.Bussiness.Model.ReturnModel;
using Leopard.Bussiness.Services.Interface;
using Leopard.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SamtApi.Controllers.WebApi {

	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class PortalController : YaldaController {

		private readonly IPortalService _portal;
		public PortalController(IPortalService portal) {
			_portal = portal;
		}


		// GET: api/<PortalController>
		[HttpPost("GetAll")]
		public async Task<IActionResult> GetAll(PortalSearchModel model) {
			List<PortalResult>? res = await _portal.GetAll(model);
			return Ok(OperationResult<List<PortalResult>?>.SuccessResult(res, _portal.GetAllTotalCount()));
		}

		// GET api/<PortalController>/5
		//[HttpGet("{id}")]
		//public IActionResult Get(int id) {

		//	Portal res = _portal.GetById(id);
		//	if (res!=null) {
		//		return Ok(OperationResult<Portal>.SuccessResult(res));
		//	}
		//	return Ok(OperationResult<string>.FailureResult(""));
		//}

		//// POST api/<PortalController>
		//[HttpPost]
		//public void Post([FromBody] string value) {
		//}

		//// PUT api/<PortalController>/5
		//[HttpPut("{id}")]
		//public void Put(int id, [FromBody] string value) {
		//}

		//// DELETE api/<PortalController>/5
		//[HttpDelete("{id}")]
		//public void Delete(int id) {
		//}
	}
}
