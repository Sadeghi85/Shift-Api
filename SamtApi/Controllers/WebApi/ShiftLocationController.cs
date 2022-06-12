using Leopard.Bussiness.Model;
using Leopard.Bussiness.Services.Interface;
using Leopard.Repository;
using Microsoft.AspNetCore.Mvc;
using SamtApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SamtApi.Controllers.WebApi {
	[Route("api/[controller]")]
	[ApiController]
	public class ShiftLocationController : ControllerBase {

		readonly private IShiftLocationService _shiftLocationService;

		public ShiftLocationController(IShiftLocationService shiftLocationService) {
			_shiftLocationService = shiftLocationService;
		}
	



		// GET: api/<ShiftLocationController>
		[HttpGet]
		public IActionResult Get() {
			var res = _shiftLocationService.GetAll();
			return Ok(res);

		}

		// GET api/<ShiftLocationController>/5
		[HttpGet("{id}")]
		public IActionResult Get(int portalId) {

			var res = _shiftLocationService.GetShiftLocationByPortalId(portalId);

			return  Ok(res);
		}


		// POST api/<ShiftLocationController>
		[HttpPost]
		public async Task<OkObjectResult> PostAsync(ShiftLocationModel model) {

			ShiftLocation shiftLocation = new ShiftLocation { Title = model.Title, PortalId = model.PortalId };
			var res = await _shiftLocationService.RegisterShiftLocation(model);
			return Ok(res);

		}

		// PUT api/<ShiftLocationController>/5
		[HttpPut]
		public async Task<OkObjectResult> Put( ShiftLocationModel model) {
			var res = await _shiftLocationService.Update(model);
			return Ok(res);


		}

		// DELETE api/<ShiftLocationController>/5
		[HttpDelete("{id}")]
		public void Delete(int id) {
		}
	}
}
