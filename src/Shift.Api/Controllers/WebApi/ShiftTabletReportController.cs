
using Shift.Bussiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cheetah.Utilities;

namespace Shift.Api.Controllers.WebApi {

	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class ShiftTabletReportController : YaldaController {

		private readonly IShiftTabletReportService _shiftTabletReportService;

		public ShiftTabletReportController(IShiftTabletReportService shiftTabletReportService) {
			_shiftTabletReportService = shiftTabletReportService;
		}

		[HttpPost("GetAll")]
		public async Task<IActionResult> GetAll(ShiftTabletReportSearchModel model) {
			if (!ModelState.IsValid) {
				var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

				var errMsgs = string.Join(Environment.NewLine, allErrors);
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var res = await _shiftTabletReportService.GetAll(model);

			return Ok(OperationResult<List<ShiftTabletReportViewModel>>.SuccessResult(res.Result, res.TotalCount));

		}

		[HttpPost("CreateOrUpdate")]
		public async Task<IActionResult> CreateOrUpdate(ShiftTabletReportInputModel model) {

			if (!ModelState.IsValid) {
				var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

				var errMsgs = string.Join(Environment.NewLine, allErrors);
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var res = await _shiftTabletReportService.CreateOrUpdate(model);

			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));

		}

	}
}
