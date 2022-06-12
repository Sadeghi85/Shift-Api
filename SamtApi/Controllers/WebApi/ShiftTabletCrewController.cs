using Leopard.Bussiness.Model;
using Leopard.Bussiness.Services.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SamtApi.Controllers.WebApi {
	[Route("api/[controller]")]
	[ApiController]
	public class ShiftTabletCrewController : ControllerBase {

		private readonly IShiftTabletCrewService _shiftTabletCrewService;

		public ShiftTabletCrewController(IShiftTabletCrewService shiftTabletCrewService) {
			_shiftTabletCrewService = shiftTabletCrewService;
		}



		// GET: api/<ShiftTabletCrewController>
		[HttpGet]
		public IActionResult Get() {
			var res = _shiftTabletCrewService.GetAll();
			return Ok(res);
		}

		// GET api/<ShiftTabletCrewController>/5
		[HttpGet("{id}")]
		public IActionResult Get(int id) {
			var res = _shiftTabletCrewService.GetByShiftId(id);
			return Ok( res);
		}

		// POST api/<ShiftTabletCrewController>
		[HttpPost]
		public async Task<IActionResult> Post( ShiftTabletCrewModel model) {
			var res = await _shiftTabletCrewService.Register(model);

			return Ok(res);

		}

		// PUT api/<ShiftTabletCrewController>/5
		[HttpPut]
		public async Task<IActionResult> Put(ShiftTabletCrewModel model) {
			var res = await _shiftTabletCrewService.Update(model);
			return Ok(res);
		}

		[HttpGet("{replaced}/{replacedBy}")]
		public async Task<OkObjectResult> Replace(int replaced , int replacedBy) {
			var res = await _shiftTabletCrewService.Replace(replaced, replacedBy);
			return Ok(res);
		}

		// DELETE api/<ShiftTabletCrewController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id) {
			var res = await _shiftTabletCrewService.Delete(id);
			return Ok(res);
		}
	}
}
