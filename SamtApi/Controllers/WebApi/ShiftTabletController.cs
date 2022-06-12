using Leopard.Bussiness.Model;
using Leopard.Bussiness.Services.Interface;
using Leopard.Repository;
using Microsoft.AspNetCore.Mvc;
using SamtApi.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SamtApi.Controllers.WebApi {
	[Route("api/[controller]")]
	[ApiController]
	public class ShiftTabletController : ControllerBase {

		

		readonly private IShiftTabletService _shiftTabletService;

		

		public ShiftTabletController(IShiftTabletService shiftTabletService) {
			_shiftTabletService = shiftTabletService;
		}



		// GET: api/<ShiftTabletController>
		[HttpGet]
		public IActionResult Get() {

			
		
			var res = _shiftTabletService.GetAll();
			return Ok(res);

		}

		// GET api/<ShiftTabletController>/5
		[HttpGet("{portalId}")]
		public IActionResult Get(int portalId) {
			var res = _shiftTabletService.GetTabletShiftByPortalId(portalId);
			return Ok(res);

		}

		// POST api/<ShiftTabletController>
		[HttpPost]
		public async Task<OkObjectResult> Post(ShiftTabletModel model) {
			
			var res = await _shiftTabletService.RegisterShiftTablet(model);
			return Ok(res);

		}

		// PUT api/<ShiftTabletController>/5
		[HttpPut]
		public async Task<OkObjectResult> Put(ShiftTabletModel model) {
			var res = await _shiftTabletService.UpdateShifTablet(model);
			return Ok(res);

		}

		// DELETE api/<ShiftTabletController>/5
		[HttpDelete("{id}")]
		public void Delete(int id) {
		}
	}
}
