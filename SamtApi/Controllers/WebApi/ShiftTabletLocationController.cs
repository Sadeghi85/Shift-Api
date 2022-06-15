using Leopard.Bussiness.Model;
using Leopard.Bussiness.Services.Interface;
using Leopard.Repository;
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
		[HttpPost("GetAll")]
		public IActionResult GetAll() {
			IQueryable<ShiftShiftTabletLocation>? res = _shiftTabletLocationService.GetAll();
			if (res.Count() > 0) {
				return Ok(OperationResult<IQueryable<ShiftShiftTabletLocation>>.SuccessResult(res, res.Count()));
			}
			return Ok(OperationResult<string>.FailureResult(""));
		}

		// GET api/<ShiftTabletLocationController>/5
		[HttpPost("GetByTabletId/{shiftTabletId}")]
		public IActionResult GetByTabletId(int shiftTabletId) {
			List<ShiftShiftTabletLocation>? res = _shiftTabletLocationService.GetShiftLocattionsByshiftTabletId(shiftTabletId);
			if (res.Count() > 0) {
				return Ok(OperationResult<List<ShiftShiftTabletLocation>>.SuccessResult(res, res.Count()));
			}
			return Ok(OperationResult<string>.FailureResult(""));
		}

		// POST api/<ShiftTabletLocationController>
		[HttpPost("Register")]
		public async Task<IActionResult> Register(ShiftTabletLocationModel model) {
			var res = await _shiftTabletLocationService.RegisterShiftTabletLocation(model);
			if (res > 0) {
				return Ok(OperationResult<int>.SuccessResult(res));
			}
			return Ok(OperationResult<string>.FailureResult(""));
		}

		// PUT api/<ShiftTabletLocationController>/5
		[HttpPost("Update")]
		public async Task<IActionResult> Update(ShiftTabletLocationModel model) {
			var res = await _shiftTabletLocationService.Update(model);
			if (res > 0) {
				return Ok(OperationResult<int>.SuccessResult(res));
			}
			return Ok(OperationResult<string>.FailureResult(""));

		}

		// DELETE api/<ShiftTabletLocationController>/5
		//[HttpDelete("{id}")]
		//public void Delete(int id) {
		//}
	}
}
