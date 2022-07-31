using Leopard.Bussiness;
using Leopard.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SamtApi.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SamtApi.Controllers.WebApi {
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class ShiftController : YaldaController {

		private readonly IShiftService _shiftService;
		public ShiftController(IShiftService shiftService) {
			_shiftService = shiftService;
		}

		// GET: api/<ShiftController>
		[HttpPost("GetAll")]
		public async Task<IActionResult> GetAll(ShiftSearchModel model) {

			if (!ModelState.IsValid) {
				var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

				var errMsgs = string.Join(Environment.NewLine, allErrors);
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var res = await _shiftService.GetAll(model);

			return Ok(OperationResult<List<ShiftViewModel>>.SuccessResult(res.Result, res.TotalCount));

		}

		// GET api/<ShiftController>/5
		//[HttpPost("FindByPortalId/{portalId}")]
		//public IActionResult Get(int portalId) {

		//	List<ShiftShift>? res = _shiftService.FindByPortalId(portalId);


		//	return Ok(OperationResult<List<ShiftShift>>.SuccessResult(res, res.Count()));

		//}

		// POST api/<ShiftController>
		[HttpPost("Register")]
		public async Task<IActionResult> Register(ShiftInputModel model) {
			if (!ModelState.IsValid) {
				var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

				var errMsgs = string.Join(Environment.NewLine, allErrors);
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var res = await _shiftService.Register(model);

			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));
		}


		// PUT api/<ShiftController>/5
		[HttpPost("Update")]
		public async Task<IActionResult> Update(ShiftInputModel model) {
			if (!ModelState.IsValid) {
				var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

				var errMsgs = string.Join(Environment.NewLine, allErrors);
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var res = await _shiftService.Update(model);

			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));
		}

		// DELETE api/<ShiftController>/5
		[HttpPost("Delete")]
		public async Task<IActionResult> Delete(int id) {
			if (!ModelState.IsValid) {
				var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

				var errMsgs = string.Join(Environment.NewLine, allErrors);
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var res = await _shiftService.Delete(id);

			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));
		}

		[HttpPost("ShiftJobTemplate/GetAll")]
		public async Task<IActionResult> GetAllShiftJobTemplates(ShiftShiftJobTemplateSearchModel model) {
			if (!ModelState.IsValid) {
				var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

				var errMsgs = string.Join(Environment.NewLine, allErrors);
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var res = await _shiftService.GetAllShiftJobTemplates(model);

			return Ok(OperationResult<List<ShiftShiftJobTemplateViewModel>>.SuccessResult(res.Result, res.TotalCount));
		}


		[HttpPost("ShiftJobTemplate/Register")]
		public async Task<IActionResult> RegisterShiftJobTemplate(ShiftShiftJobTemplateInputModel model) {
			if (!ModelState.IsValid) {
				var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

				var errMsgs = string.Join(Environment.NewLine, allErrors);
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var res = await _shiftService.RegisterShiftJobTemplate(model);

			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));

		}

		[HttpPost("ShiftJobTemplate/Delete")]
		public async Task<IActionResult> DeleteShiftJobTemplate(int id) {
			if (!ModelState.IsValid) {
				var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

				var errMsgs = string.Join(Environment.NewLine, allErrors);
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var res = await _shiftService.DeleteShiftJobTemplate(id);

			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));
		}

		[HttpPost("ShiftJobTemplate/Update")]
		public async Task<IActionResult> UpdateShiftJobTemplate(ShiftShiftJobTemplateInputModel model) {
			if (!ModelState.IsValid) {
				var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

				var errMsgs = string.Join(Environment.NewLine, allErrors);
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var res = await _shiftService.UpdateShiftJobTemplate(model);

			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));

		}

	}
}
