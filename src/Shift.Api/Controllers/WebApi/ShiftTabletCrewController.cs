using Shift.Bussiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cheetah.Utilities;

namespace Shift.Api.Controllers.WebApi {

	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class ShiftTabletCrewController : YaldaController {

		private readonly IShiftTabletCrewService _shiftTabletCrewService;

		public ShiftTabletCrewController(IShiftTabletCrewService shiftTabletCrewService) {
			_shiftTabletCrewService = shiftTabletCrewService;
		}

		// GET: api/<ShiftTabletCrewController>
		[HttpPost("GetAll")]
		public async Task<IActionResult> GetAll(ShiftTabletCrewSearchModel model) {
			if (!ModelState.IsValid) {
				var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

				var errMsgs = string.Join(Environment.NewLine, allErrors);
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var res = await _shiftTabletCrewService.GetAll(model);

			return Ok(OperationResult<List<ShiftTabletCrewViewModel>>.SuccessResult(res.Result, res.TotalCount));

		}

		[HttpPost("GetExcel")]
		public async Task<IActionResult> GetExcel(ShiftTabletCrewSearchModel model) {
			if (!ModelState.IsValid) {
				var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

				var errMsgs = string.Join(Environment.NewLine, allErrors);
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var stream = await _shiftTabletCrewService.GetExcelReport(model);

			return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"Report.xlsx");
		}


		[HttpPost("GetPdf")]
		public async Task<IActionResult> GetPdf(ShiftTabletCrewSearchModel model) {
			if (!ModelState.IsValid) {
				var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

				var errMsgs = string.Join(Environment.NewLine, allErrors);
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}


			var stream = await _shiftTabletCrewService.GetPdfReport(model);


			//InMemoryPdfReport.CreateInMemoryPdfReport(null);
			//return File(pdfRes.PdfStreamOutput, "application/pdf", $"Report.pdf");
			return File(stream, "application/pdf", $"Report.pdf");
			//return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"Report.xlsx");
		}

		//GET api/<ShiftTabletCrewController>/5
		//[HttpPost("GetByShiftId/{id}")]
		//public IActionResult GetByShiftId(int id) {
		//	List<ShiftShiftTabletCrew>? res = _shiftTabletCrewService.GetByShiftId(id);

		//	return Ok(OperationResult<List<ShiftShiftTabletCrew>>.SuccessResult(res, res.Count()));

		//}

		// POST api/<ShiftTabletCrewController>
		[HttpPost("Register")]
		public async Task<IActionResult> Register(ShiftTabletCrewInputModel model) {

			if (!ModelState.IsValid) {
				var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

				var errMsgs = string.Join(Environment.NewLine, allErrors);
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var res = await _shiftTabletCrewService.Register(model);

			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));

		}

		[HttpPost("Update")]
		public async Task<IActionResult> Update(ShiftTabletCrewInputModel model) {
			if (!ModelState.IsValid) {
				var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

				var errMsgs = string.Join(Environment.NewLine, allErrors);
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var res = await _shiftTabletCrewService.Update(model);

			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));
		}

		//[HttpPost("Replace/{replaced}/{replacedBy}")]
		//public async Task<IActionResult> Replace(int replaced, int replacedBy) {
		//	var res = await _shiftTabletCrewService.Replace(replaced, replacedBy);
		//	if (res > 0) {
		//		return Ok(OperationResult<int>.SuccessResult(res));
		//	}
		//	return Ok(OperationResult<string>.FailureResult(""));
		//}

		[HttpPost("Delete")]
		public async Task<IActionResult> Delete(int id) {
			if (!ModelState.IsValid) {
				var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

				var errMsgs = string.Join(Environment.NewLine, allErrors);
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var res = await _shiftTabletCrewService.Delete(id);

			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));
		}
	}
}
