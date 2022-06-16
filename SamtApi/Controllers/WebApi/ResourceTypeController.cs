using Leopard.Bussiness.Model;
using Leopard.Bussiness.Services.Interface;
using Leopard.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SamtApi.Controllers.WebApi {
	[Route("api/[controller]")]
	[ApiController]
	public class ResourceTypeController : ControllerBase {


		private readonly IResourceTypeService _resourceTypeService;


		public ResourceTypeController(IResourceTypeService resourceTypeService) {
			_resourceTypeService = resourceTypeService;
		}




		// GET: api/<ResourceTypeController>
		[HttpPost("GetAll")]
		public async Task<IActionResult> GetAll(ResourceTypeSearchModel model) {
			List<SamtResourceType>? res = await _resourceTypeService.GetAll(model);
			if (res.Count() > 0) {
				return Ok(OperationResult<List<SamtResourceType>>.SuccessResult(res, _resourceTypeService.GetAllCount()));
			}
			return Ok(OperationResult<string>.FailureResult(""));



		}

		// GET api/<ResourceTypeController>/5
		[HttpGet("{id}")]
		public string Get(int id) {
			return "value";
		}

		// POST api/<ResourceTypeController>
		[HttpPost]
		public void Post([FromBody] string value) {
		}

		// PUT api/<ResourceTypeController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value) {
		}

		// DELETE api/<ResourceTypeController>/5
		[HttpDelete("{id}")]
		public void Delete(int id) {
		}
	}
}
