using Leopard.Bussiness.Model;
using Leopard.Bussiness.Services.Interface;
using Leopard.Repository;
using Microsoft.AspNetCore.Mvc;
using SamtApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SamtApi.Controllers.WebApi {
	[Route("api/[controller]")]
	[ApiController]
	public class ProductionTypeController : ControllerBase {

		readonly private IShiftProductionTypeService _shiftProductionTypeService;



		public ProductionTypeController(IShiftProductionTypeService shiftProductionTypeService) {
			_shiftProductionTypeService = shiftProductionTypeService;
		}



		// GET: api/<ProductionTypeController>
		[HttpGet]
		public IActionResult Get() {





			var res = _shiftProductionTypeService.GetAll();
			return Ok(res);



			//return 


		}

		// GET api/<ProductionTypeController>/5
		[HttpGet("{id}")]
		public IActionResult Get(int id) {
			var res = _shiftProductionTypeService.FindById(id);

			return Ok(res);
		}

		// POST api/<ProductionTypeController>
		[HttpPost]
		public async Task<IActionResult> Post(ShiftProductionTypeModel model) {
			var res = await _shiftProductionTypeService.Register(model);

			return Ok(res);
		}

		// PUT api/<ProductionTypeController>/5
		[HttpPut]
		public async Task<OkObjectResult> PutAsync(ShiftProductionTypeModel model) {

			var res = await _shiftProductionTypeService.Update(model);

			return Ok(res);
		}

		// DELETE api/<ProductionTypeController>/5
		[HttpDelete("{id}")]
		public void Delete(int id) {
		}
	}
}
