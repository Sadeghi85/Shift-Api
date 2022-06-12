
using Leopard.Bussiness.Model;
using Leopard.Bussiness.Services.Interface;
using Leopard.Repository;

using Microsoft.AspNetCore.Mvc;
using SamtApi.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SamtApi.Controllers.WebApi {
	[Route("api/[controller]")]
	[ApiController]
	public class ShiftController : ControllerBase {

		private readonly IShiftService _shiftService;
		public ShiftController(IShiftService shiftService) {
			_shiftService = shiftService;
		}


		// GET: api/<ShiftController>
		[HttpGet]
		[ProducesDefaultResponseType]
		public IActionResult Get() {

			var res = _shiftService.GetAll();
			return Ok(res);
		}

		// GET api/<ShiftController>/5
		[HttpGet("{portalId}")]
		public IActionResult Get(int portalId) {

			var res = _shiftService.FindByPortalId(portalId);
			return Ok(res);
			

		}



		// POST api/<ShiftController>
		[HttpPost]
		public async Task<IActionResult> Post(ShiftModel model) {
			var res = await _shiftService.Register(model);
			return Ok(res);
			
		}


		// PUT api/<ShiftController>/5
		[HttpPut]
		public async Task<OkObjectResult> PutAsync(ShiftModel model) {

			var res = await _shiftService.Update(model);
			return Ok(res);
		}

		// DELETE api/<ShiftController>/5
		[HttpDelete]
		public async Task<OkObjectResult> Delete(int id) {

			var res = await _shiftService.Delete(id);
			return Ok(res);
		}
	}
}
