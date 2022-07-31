using Leopard.Bussiness;
using Leopard.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SamtApi.Controllers.WebApi {
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class PortalLocationController : YaldaController {

		private readonly IPortalLocationService _portalLocationService;

		public PortalLocationController(IPortalLocationService portalLocationService) {
			_portalLocationService = portalLocationService;
		}

		[HttpPost("GetAll")]
		public async Task<IActionResult> GetAll(PortalLocationSearchModel model) {

			if (!ModelState.IsValid) {
				var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

				var errMsgs = string.Join(Environment.NewLine, allErrors);
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var res = await _portalLocationService.GetAll(model);

			return Ok(OperationResult<List<PortalLocationViewModel>>.SuccessResult(res.Result, res.TotalCount));

		}

		// GET api/<ShiftTabletLocationController>/5
		//[HttpPost("GetByTabletId/{shiftTabletId}")]
		//public IActionResult GetByTabletId(int shiftTabletId) {
		//	var res = _portalLocationService.GetShiftLocattionsByshiftTabletId(shiftTabletId);

		//	return Ok(OperationResult<List<PortalLocationViewModel>>.SuccessResult(res, res.Count()));

		//}

		[HttpPost("Register")]
		public async Task<IActionResult> Register(PortalLocationInputModel model) {

			if (!ModelState.IsValid) {
				var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

				var errMsgs = string.Join(Environment.NewLine, allErrors);
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var res = await _portalLocationService.Register(model);

			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));
		}

		[HttpPost("Update")]
		public async Task<IActionResult> Update(PortalLocationInputModel model) {

			if (!ModelState.IsValid) {
				var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

				var errMsgs = string.Join(Environment.NewLine, allErrors);
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var res = await _portalLocationService.Update(model);

			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));

		}

		[HttpPost("Delete")]
		public async Task<OkObjectResult> Delete(int id) {

			if (!ModelState.IsValid) {
				var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

				var errMsgs = string.Join(Environment.NewLine, allErrors);
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var res = await _portalLocationService.Delete(id);

			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));


		}
	}
}
