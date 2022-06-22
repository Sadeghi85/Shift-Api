using Leopard.Bussiness.Model;
using Leopard.Bussiness.Model.ReturnModel;
using Leopard.Bussiness.Services.Interface;
using Leopard.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SamtApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SamtApi.Controllers.WebApi {
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class ProductionTypeController : YaldaController {

		readonly private IShiftProductionTypeService _shiftProductionTypeService;



		public ProductionTypeController(IShiftProductionTypeService shiftProductionTypeService) {
			_shiftProductionTypeService = shiftProductionTypeService;
		}



		// GET: api/<ProductionTypeController>
		[HttpPost("GetAll")]
		public async Task< IActionResult> GetAll(ShiftProductionSearchModel model) {





			List<ShiftProductionResult>? res = await _shiftProductionTypeService.GetAll(model);
			if (res.Count > 0) {
				return Ok(OperationResult<List<ShiftProductionResult>>.SuccessResult(res, _shiftProductionTypeService.GetAllCount()));
			}
			return Ok(OperationResult<string>.FailureResult(""));



			//return 


		}

		// GET api/<ProductionTypeController>/5
		[HttpPost("Get/{id}")]
		public IActionResult Get(int id) {
			ShiftProductionType? res = _shiftProductionTypeService.FindById(id);

			if (res !=null) {
				return Ok(OperationResult<ShiftProductionType>.SuccessResult(res));
			}
			return Ok(OperationResult<string>.FailureResult(""));

			
		}

		// POST api/<ProductionTypeController>
		[HttpPost("Register")]
		public async Task<IActionResult> Register(ShiftProductionTypeModel model) {

			if (!ModelState.IsValid) {


				var errors = ModelState.Select(x => x.Value.Errors)
						   .Where(y => y.Count > 0)
						   .ToList();

				var errMsgs = string.Join(",", errors[0].Select(pp => pp.ErrorMessage));
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var res = await _shiftProductionTypeService.Register(model);

			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));
		}

		// PUT api/<ProductionTypeController>/5
		[HttpPost("Update")]
		public async Task<OkObjectResult> UpDate(ShiftProductionTypeModel model) {

			var res = await _shiftProductionTypeService.Update(model);

			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));
		}

		[HttpPost("Delete")]
		public async Task<IActionResult> Delete(ShiftProductionTypeModel model) {
			var res = await _shiftProductionTypeService.Delete(model);

			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));
		}

	}
}
