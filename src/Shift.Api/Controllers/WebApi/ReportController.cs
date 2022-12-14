using Shift.Bussiness;
using Shift.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cheetah.Utilities;

namespace Shift.Api.Controllers.WebApi {

	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class ReportController : YaldaController {

		private readonly IReportService _reportService;
		public ReportController(IReportService reportService) {
			_reportService = reportService;
		}

		[HttpPost("GetSecretaryReport")]
		public async Task<IActionResult> GetSecretaryReport(int shiftTabletId) {

			if (!ModelState.IsValid) {
				var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

				var errMsgs = string.Join(Environment.NewLine, allErrors);
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var stream = await _reportService.GetSecretaryReport(shiftTabletId);

			stream ??= new MemoryStream();

			return File(stream, "application/pdf", $"Report.pdf");
		}

	}
}
