using Shift.Bussiness;
using Shift.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shift.Api.Models;
using Cheetah.Utilities;

namespace Shift.Api.Controllers.WebApi {
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class ShiftTabletController : YaldaController {

		private readonly IShiftTabletService _shiftTabletService;

		public ShiftTabletController(IShiftTabletService shiftTabletService) {
			_shiftTabletService = shiftTabletService;
		}

		// GET: api/<ShiftTabletController>
		[HttpPost("GetAll")]
		public async Task<IActionResult> GetAll(ShiftTabletSearchModel model) {
			if (!ModelState.IsValid) {
				var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

				var errMsgs = string.Join(Environment.NewLine, allErrors);
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var res = await _shiftTabletService.GetAll(model);

			return Ok(OperationResult<List<ShiftTabletViewModel>>.SuccessResult(res.Result, res.TotalCount));

		}

		// GET api/<ShiftTabletController>/5
		//[HttpPost("GetByPortalId/{portalId}")]
		//public IActionResult GetByPortalId(int portalId) {
		//	List<ShiftShiftTablet>? res = _shiftTabletService.GetTabletShiftByPortalId(portalId);

		//	return Ok(OperationResult<List<ShiftShiftTablet>>.SuccessResult(res, res.Count()));

		//}

		// POST api/<ShiftTabletController>
		[HttpPost("Register")]
		public async Task<OkObjectResult> Register(ShiftTabletInputModel model) {
			if (!ModelState.IsValid) {
				var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

				var errMsgs = string.Join(Environment.NewLine, allErrors);
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var res = await _shiftTabletService.Register(model);

			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));

		}

		// PUT api/<ShiftTabletController>/5
		[HttpPost("Update")]
		public async Task<OkObjectResult> Update(ShiftTabletInputModel model) {
			if (!ModelState.IsValid) {
				var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

				var errMsgs = string.Join(Environment.NewLine, allErrors);
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var res = await _shiftTabletService.Update(model);

			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));

		}

		[HttpPost("Delete")]
		public async Task<IActionResult> Delete(int id) {
			if (!ModelState.IsValid) {
				var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

				var errMsgs = string.Join(Environment.NewLine, allErrors);
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var res = await _shiftTabletService.Delete(id);

			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));
		}
	}
}
