

using Leopard.Bussiness.Model;
using Leopard.Bussiness.Services.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SamtApi.Controllers.WebApi {
	[Route("api/[controller]")]
	[ApiController]
	public class ShiftCrewRewardFineController : ControllerBase {

		private readonly IShiftCrewRewardFineService _shiftCrewRewardFineService;

		public ShiftCrewRewardFineController(IShiftCrewRewardFineService shiftCrewRewardFineService) {
			_shiftCrewRewardFineService = shiftCrewRewardFineService;
		}
	



		// GET: api/<ShiftCrewRewardFineController>
		[HttpGet]
		public IActionResult Get() {

			var res =_shiftCrewRewardFineService.GetAll();
			return Ok(res);
			
		}

		// GET api/<ShiftCrewRewardFineController>/5
		[HttpGet("{id}")]
		public string Get(int id) {
			return "value";
		}

		// POST api/<ShiftCrewRewardFineController>
		[HttpPost]
		public async Task<OkObjectResult> Post(ShiftCrewRewardFineModel model) {
			var res = await _shiftCrewRewardFineService.Register(model);
			return Ok(res);
		}

		// PUT api/<ShiftCrewRewardFineController>/5
		[HttpPut]
		public async Task<OkObjectResult> Put(ShiftCrewRewardFineModel model) {

			var res =await _shiftCrewRewardFineService.Update(model);
			return Ok(res);
		}

		// DELETE api/<ShiftCrewRewardFineController>/5
		[HttpDelete("{id}")]
		public async Task<OkObjectResult> Delete(int id) {

			var res = await _shiftCrewRewardFineService.Delete(id);
			return Ok(res);
		}
	}
}
