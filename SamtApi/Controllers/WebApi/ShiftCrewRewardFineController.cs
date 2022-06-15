

using Leopard.Bussiness.Model;
using Leopard.Bussiness.Services.Interface;
using Leopard.Repository;
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
		[HttpPost("GetAll")]
		public async Task< IActionResult> GetAll(ShiftCrewRewardFineSearchModel model) {

			List<ShiftCrewRewardFine>? res = await _shiftCrewRewardFineService.GetAll(model);


			if (res.Count() > 0) {
				return Ok(OperationResult<List<ShiftCrewRewardFine>>.SuccessResult(res, res.Count()));
			}
			return Ok(OperationResult<string>.FailureResult(""));

		}

		// GET api/<ShiftCrewRewardFineController>/5
		//[HttpGet("{id}")]
		//public string Get(int id) {
		//	return "value";
		//}

		// POST api/<ShiftCrewRewardFineController>
		[HttpPost("Register")]
		public async Task<IActionResult> Register(ShiftCrewRewardFineModel model) {
			var res = await _shiftCrewRewardFineService.Register(model);
			if (res > 0) {
				return Ok(OperationResult<int>.SuccessResult(res));
			}
			return Ok(OperationResult<string>.FailureResult(""));
		}

		// PUT api/<ShiftCrewRewardFineController>/5
		[HttpPost("Update")]
		public async Task<IActionResult> Update(ShiftCrewRewardFineModel model) {

			var res =await _shiftCrewRewardFineService.Update(model);
			if (res > 0) {
				return Ok(OperationResult<int>.SuccessResult(res));
			}
			return Ok(OperationResult<string>.FailureResult(""));
		}

		// DELETE api/<ShiftCrewRewardFineController>/5
		[HttpPost("Delete/{id}")]
		public async Task<IActionResult> Delete(int id) {

			var res = await _shiftCrewRewardFineService.Delete(id);
			if (res > 0) {
				return Ok(OperationResult<int>.SuccessResult(res));
			}
			return Ok(OperationResult<string>.FailureResult(""));
		}
	}
}
