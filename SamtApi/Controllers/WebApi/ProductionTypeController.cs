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





			IQueryable<ShiftProductionType>? res = _shiftProductionTypeService.GetAll();
			if (res.Count() > 0) {
				return Ok(OperationResult<IQueryable<ShiftProductionType>>.SuccessResult(res, res.Count()));
			}
			return Ok(OperationResult<string>.FailureResult(""));



			//return 


		}

		// GET api/<ProductionTypeController>/5
		[HttpGet("{id}")]
		public IActionResult Get(int id) {
			ShiftProductionType? res = _shiftProductionTypeService.FindById(id);

			if (res !=null) {
				return Ok(OperationResult<ShiftProductionType>.SuccessResult(res));
			}
			return Ok(OperationResult<string>.FailureResult(""));

			
		}

		// POST api/<ProductionTypeController>
		[HttpPost]
		public async Task<IActionResult> Post(ShiftProductionTypeModel model) {
			var res = await _shiftProductionTypeService.Register(model);

			if (res > 0) {
				return Ok(OperationResult<int>.SuccessResult(res));
			}
			return Ok(OperationResult<string>.FailureResult(""));
		}

		// PUT api/<ProductionTypeController>/5
		[HttpPut]
		public async Task<OkObjectResult> PutAsync(ShiftProductionTypeModel model) {

			var res = await _shiftProductionTypeService.Update(model);

			if (res > 0) {
				return Ok(OperationResult<int>.SuccessResult(res));
			}
			return Ok(OperationResult<string>.FailureResult(""));
		}

		// DELETE api/<ProductionTypeController>/5
		[HttpDelete("{id}")]
		public void Delete(int id) {
		}
	}
}
