using Leopard.Bussiness.Model;
using Leopard.Bussiness.Services.Interface;
using Leopard.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SamtApi.Controllers.WebApi {
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class ShiftTabletLocationController : YaldaController {

		readonly private IShiftTabletLocationService _shiftTabletLocationService;

		public ShiftTabletLocationController(IShiftTabletLocationService shiftTabletLocationService) {
			_shiftTabletLocationService = shiftTabletLocationService;
		}



		// GET: api/<ShiftTabletLocationController>
		[HttpPost("GetAll")]
		public IActionResult GetAll() {
			IQueryable<ShiftShiftTabletLocation>? res = _shiftTabletLocationService.GetAll();

			return Ok(OperationResult<IQueryable<ShiftShiftTabletLocation>>.SuccessResult(res, res.Count()));

		}

		// GET api/<ShiftTabletLocationController>/5
		[HttpPost("GetByTabletId/{shiftTabletId}")]
		public IActionResult GetByTabletId(int shiftTabletId) {
			List<ShiftShiftTabletLocation>? res = _shiftTabletLocationService.GetShiftLocattionsByshiftTabletId(shiftTabletId);

			return Ok(OperationResult<List<ShiftShiftTabletLocation>>.SuccessResult(res, res.Count()));

		}

		// POST api/<ShiftTabletLocationController>
		[HttpPost("Register")]
		public async Task<IActionResult> Register(ShiftTabletLocationModel model) {
			if (!ModelState.IsValid) {


				var errors = ModelState.Select(x => x.Value.Errors)
						   .Where(y => y.Count > 0)
						   .ToList();


				var errMsgs = string.Join(",", errors[0].Select(pp => pp.ErrorMessage));
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}
			var res = await _shiftTabletLocationService.RegisterShiftTabletLocation(model);
			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));
		}

		// PUT api/<ShiftTabletLocationController>/5
		[HttpPost("Update")]
		public async Task<IActionResult> Update(ShiftTabletLocationModel model) {
			var res = await _shiftTabletLocationService.Update(model);
			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));

		}

		// DELETE api/<ShiftTabletLocationController>/5
		//[HttpDelete("{id}")]
		//public void Delete(int id) {
		//}
	}
}
