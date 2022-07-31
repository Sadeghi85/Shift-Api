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
	public class LocationController : YaldaController {

		readonly private ILocationService _locationService;

		public LocationController(ILocationService locationService) {
			_locationService = locationService;
		}

		[HttpPost("GetAll")]
		public async Task<IActionResult> GetAll(LocationSearchModel model) {

			if (!ModelState.IsValid) {
				var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

				var errMsgs = string.Join(Environment.NewLine, allErrors);
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var res = await _locationService.GetAll(model);

			return Ok(OperationResult<List<LocationViewModel>>.SuccessResult(res.Result, res.TotalCount));
		}

		// GET api/<ShiftLocationController>/5
		//[HttpPost("{portalId}")]
		//public IActionResult Get(int portalId) {

		//	List<ShiftLocation>? res = _locationService.GetShiftLocationByPortalId(portalId);
		//	return Ok(OperationResult<List<ShiftLocation>>.SuccessResult(res, res.Count()));
		//}

		[HttpPost("Register")]
		public async Task<OkObjectResult> Register(LocationInputModel model) {

			if (!ModelState.IsValid) {
				var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

				var errMsgs = string.Join(Environment.NewLine, allErrors);
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var res = await _locationService.Register(model);

			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));

		}


		[HttpPost("Update")]
		public async Task<OkObjectResult> Update(LocationInputModel model) {

			if (!ModelState.IsValid) {
				var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

				var errMsgs = string.Join(Environment.NewLine, allErrors);
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var res = await _locationService.Update(model);

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

			var res = await _locationService.Delete(id);

			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));


		}
	}
}
