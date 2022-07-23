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




		// GET: api/<ShiftLocationController>
		[HttpPost("GetAll")]
		public async Task<IActionResult> GetAll(LocationSearchModel model) {

			var portalId = GetUserPortalId() ?? 0;


			var res = await _locationService.GetAll(model, out var resCount);


			return Ok(OperationResult<List<LocationViewModel>>.SuccessResult(res, resCount));
		}

		// GET api/<ShiftLocationController>/5
		//[HttpPost("{portalId}")]
		//public IActionResult Get(int portalId) {

		//	List<ShiftLocation>? res = _locationService.GetShiftLocationByPortalId(portalId);
		//	return Ok(OperationResult<List<ShiftLocation>>.SuccessResult(res, res.Count()));
		//}


		// POST api/<ShiftLocationController>
		[HttpPost("Register")]
		public async Task<OkObjectResult> Register(LocationInputModel model) {
			if (!ModelState.IsValid) {


				var errors = ModelState.Select(x => x.Value.Errors)
						   .Where(y => y.Count > 0)
						   .ToList();


				var errMsgs = string.Join(",", errors[0].Select(pp => pp.ErrorMessage));
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var res = await _locationService.Register(model);
			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));

		}

		// PUT api/<ShiftLocationController>/5
		[HttpPost("Update")]
		public async Task<OkObjectResult> Update(LocationInputModel model) {
			var res = await _locationService.Update(model);
			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));


		}

		[HttpPost("Delete")]
		public async Task<OkObjectResult> Delete(LocationInputModel model) {
			var res = await _locationService.Delete(model);
			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));


		}
	}
}
