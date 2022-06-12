using Leopard.Bussiness.Model;
using Leopard.Bussiness.Services.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SamtApi.Controllers.WebApi {
	[Route("api/[controller]")]
	[ApiController]
	public class ShiftTabletLocationController : ControllerBase {

		readonly private IShiftTabletLocationService _shiftTabletLocationService;

		public ShiftTabletLocationController(IShiftTabletLocationService shiftTabletLocationService) {
			_shiftTabletLocationService = shiftTabletLocationService;
		}



		// GET: api/<ShiftTabletLocationController>
		[HttpGet]
		public IActionResult Get() {
			var res = _shiftTabletLocationService.GetAll();
			return Ok(res);
		}

		// GET api/<ShiftTabletLocationController>/5
		[HttpGet("{shiftTabletId}")]
		public IActionResult Get(int shiftTabletId) {
			var res =_shiftTabletLocationService.GetShiftLocattionsByshiftTabletId(shiftTabletId);
			return Ok(res);


		}

		// POST api/<ShiftTabletLocationController>
		[HttpPost]
		public async Task<OkObjectResult> Post(ShiftTabletLocationModel model) {
			var res = await  _shiftTabletLocationService.RegisterShiftTabletLocation(model);
			return Ok(res);

		}

		// PUT api/<ShiftTabletLocationController>/5
		[HttpPut]
		public async Task<OkObjectResult> Put(ShiftTabletLocationModel model) {
			var res = await _shiftTabletLocationService.Update(model);
			return Ok(res);

		}

		// DELETE api/<ShiftTabletLocationController>/5
		[HttpDelete("{id}")]
		public void Delete(int id) {
		}
	}
}
