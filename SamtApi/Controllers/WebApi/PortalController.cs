using Leopard.Bussiness.Model;
using Leopard.Bussiness.Services.Interface;
using Leopard.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SamtApi.Controllers.WebApi {
	[Route("api/[controller]")]
	[ApiController]
	public class PortalController : ControllerBase {

		private readonly IPortalService _portal;
		public PortalController(IPortalService portal) {
			_portal = portal;
		}	


		// GET: api/<PortalController>
		[HttpPost("GetAll")]
		public async  Task<IActionResult> GetAll(PortalSearchModel model) {
			var res = await _portal.GetAll( model);

			if (res.Count > 0) {
				return Ok(OperationResult<List<Portal>?>.SuccessResult(res, res.Count()));
			}
			return Ok(OperationResult<string>.FailureResult(""));


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
