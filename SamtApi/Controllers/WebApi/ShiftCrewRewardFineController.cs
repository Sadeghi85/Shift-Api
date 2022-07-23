

using Leopard.Bussiness;
using Leopard.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SamtApi.Controllers.WebApi {
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class ShiftCrewRewardFineController : YaldaController {

		private readonly IShiftCrewRewardFineService _shiftCrewRewardFineService;

		public ShiftCrewRewardFineController(IShiftCrewRewardFineService shiftCrewRewardFineService) {
			_shiftCrewRewardFineService = shiftCrewRewardFineService;
		}




		// GET: api/<ShiftCrewRewardFineController>
		[HttpPost("GetAll")]
		public async Task<IActionResult> GetAll(ShiftCrewRewardFineSearchModel model) {

			Task<int> totalCount;


			var res = await _shiftCrewRewardFineService.GetAll(model, out totalCount);
			var resCount = await totalCount;

			return Ok(OperationResult<List<ShiftCrewRewardFine>>.SuccessResult(res, resCount));

		}

		// GET api/<ShiftCrewRewardFineController>/5
		//[HttpGet("{id}")]
		//public string Get(int id) {
		//	return "value";
		//}

		// POST api/<ShiftCrewRewardFineController>
		[HttpPost("Register")]
		public async Task<IActionResult> Register(ShiftCrewRewardFineInputModel model) {

			if (!ModelState.IsValid) {


				var errors = ModelState.Select(x => x.Value.Errors)
						   .Where(y => y.Count > 0)
						   .ToList();


				var errMsgs = string.Join(",", errors[0].Select(pp => pp.ErrorMessage));
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var res = await _shiftCrewRewardFineService.Register(model);
			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));
		}

		// PUT api/<ShiftCrewRewardFineController>/5
		[HttpPost("Update")]
		public async Task<IActionResult> Update(ShiftCrewRewardFineInputModel model) {

			var res = await _shiftCrewRewardFineService.Update(model);
			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));
		}

		// DELETE api/<ShiftCrewRewardFineController>/5
		[HttpPost("Delete")]
		public async Task<IActionResult> Delete(ShiftCrewRewardFineInputModel model) {

			var res = await _shiftCrewRewardFineService.Delete(model);
			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));
		}
	}
}
