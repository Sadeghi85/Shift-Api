using Shift.Bussiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cheetah.Utilities;

namespace Shift.Api.Controllers.WebApi {
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class ShiftEmploymentDetailController : YaldaController {

		private IShiftEmploymentDetailService _shiftEmploymentDetail;


		public ShiftEmploymentDetailController(IShiftEmploymentDetailService shiftEmploymentDetail) {
			_shiftEmploymentDetail = shiftEmploymentDetail;
		}


		[HttpPost("GetAll")]
		public async Task<IActionResult> GetAll(ShiftEmploymentDetailSearchModel model) {

			var portalId = GetUserPortalId() ?? 0;
			if (portalId > 1) {
				model.PortalId = portalId;
			}


			var res = await _shiftEmploymentDetail.GetAll(model);

			return Ok(OperationResult<List<ShiftEmploymentDetailViewModel>>.SuccessResult(res.Result, res.TotalCount));

		}
		[HttpPost("Register")]
		public async Task<IActionResult> Register(ShiftEmploymentDetailInputModel model) {

			if (!ModelState.IsValid) {
				var errors = ModelState.Select(x => x.Value.Errors)
						   .Where(y => y.Count > 0)
						   .ToList();


				var errMsgs = string.Join(",", errors[0].Select(pp => pp.ErrorMessage));
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var res = await _shiftEmploymentDetail.Register(model);
			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));

		}

		[HttpPost("Update")]
		public async Task<IActionResult> Update(ShiftEmploymentDetailInputModel model) {
			if (!ModelState.IsValid) {
				var errors = ModelState.Select(x => x.Value.Errors)
						   .Where(y => y.Count > 0)
						   .ToList();


				var errMsgs = string.Join(",", errors[0].Select(pp => pp.ErrorMessage));
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var res = await _shiftEmploymentDetail.Update(model);
			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));

		}

		[HttpPost("Delete")]
		public async Task<IActionResult> Delete(ShiftEmploymentDetailInputModel model) {

			var res = await _shiftEmploymentDetail.Delete(model);
			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));
		}
	}
}
