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

			if (GetUserId() == 0) {

			}


		}


		// GET: api/<ShiftController>
		[HttpPost("GetAll")]
		[ProducesDefaultResponseType]
		public async Task<IActionResult> GetAll(ShiftSearchModel model) {

			var portalId = GetUserPortalId() ?? 0;
			if (portalId > 1) {
				model.PortalId = portalId;
			}

			Task<int> totalCount;


			var res = await _shiftService.GetAll(model, out totalCount);
			var resCount = await totalCount;

			return Ok(OperationResult<List<ShiftViewModel>?>.SuccessResult(res, resCount));

		}

		// GET api/<ShiftController>/5
		[HttpPost("FindByPortalId/{portalId}")]
		public IActionResult Get(int portalId) {

			List<ShiftShift>? res = _shiftService.FindByPortalId(portalId);


			return Ok(OperationResult<List<ShiftShift>>.SuccessResult(res, res.Count()));



		}



		// POST api/<ShiftController>
		[HttpPost("Register")]
		public async Task<IActionResult> Register(ShiftInputModel model) {
			if (!ModelState.IsValid) {


				var errors = ModelState.Select(x => x.Value.Errors)
						   .Where(y => y.Count > 0)
						   .ToList();


				var errMsgs = string.Join(",", errors[0].Select(pp => pp.ErrorMessage));
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}
			BaseResult? res = await _shiftService.Register(model);
			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));
		}


		// PUT api/<ShiftController>/5
		[HttpPost("Update")]
		public async Task<IActionResult> Update(ShiftInputModel model) {

			var res = await _shiftService.Update(model);
			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));
		}

		// DELETE api/<ShiftController>/5
		[HttpPost("Delete")]
		public async Task<IActionResult> Delete(ShiftInputModel model) {

			var res = await _shiftService.Delete(model);
			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));
		}


		[HttpPost("ShiftJobTemplate/GetAll")]
		public async Task<IActionResult> GetAllShiftJobTemplates(ShiftShiftJobTemplateSearchModel model) {

			Task<int> totalCount;

			List<ShiftShiftJobTemplateViewModel>? res = await _shiftService.GetAllShiftJobTemplates(model, out totalCount);
			var resCount = await totalCount;

			return Ok(OperationResult<List<ShiftShiftJobTemplateViewModel>?>.SuccessResult(res, resCount));
		}


		[HttpPost("ShiftJobTemplate/Register")]
		public async Task<IActionResult> RegisterShiftJobTemplate(ShiftShiftJobTemplateInputModel model) {

			var res = await _shiftService.RegisterShiftJobTemplate(model);
			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));

		}

		[HttpPost("ShiftJobTemplate/Delete")]
		public async Task<IActionResult> DeleteShiftJobTemplate(ShiftShiftJobTemplateInputModel model) {
			var res = await _shiftService.DeleteShiftJobTemplate(model);
			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));
		}

		[HttpPost("ShiftJobTemplate/Update")]
		public async Task<IActionResult> UpdateShiftJobTemplate(ShiftShiftJobTemplateInputModel model) {

			var res = await _shiftService.UpdateShiftJobTemplate(model);
			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));

		}

	}
}
