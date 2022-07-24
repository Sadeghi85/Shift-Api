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

		readonly private IPortalLocationService _portalLocationService;

		public PortalLocationController(IPortalLocationService portalLocationService) {
			_portalLocationService = portalLocationService;
		}



		// GET: api/<ShiftTabletLocationController>
		[HttpPost("GetAll")]
		public async Task<IActionResult> GetAll(PortalLocationSearchModel model) {


			var res = await _portalLocationService.GetAll(model);

			return Ok(OperationResult<List<PortalLocationViewModel>>.SuccessResult(res.Result, res.TotalCount));

		}

		// GET api/<ShiftTabletLocationController>/5
		//[HttpPost("GetByTabletId/{shiftTabletId}")]
		//public IActionResult GetByTabletId(int shiftTabletId) {
		//	var res = _portalLocationService.GetShiftLocattionsByshiftTabletId(shiftTabletId);

		//	return Ok(OperationResult<List<PortalLocationViewModel>>.SuccessResult(res, res.Count()));

		//}

		// POST api/<ShiftTabletLocationController>
		[HttpPost("Register")]
		public async Task<IActionResult> Register(PortalLocationInputModel model) {
			if (!ModelState.IsValid) {


				var errors = ModelState.Select(x => x.Value.Errors)
						   .Where(y => y.Count > 0)
						   .ToList();


				var errMsgs = string.Join(",", errors[0].Select(pp => pp.ErrorMessage));
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}
			var res = await _portalLocationService.Register(model);
			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));
		}

		// PUT api/<ShiftTabletLocationController>/5
		[HttpPost("Update")]
		public async Task<IActionResult> Update(PortalLocationInputModel model) {
			var res = await _portalLocationService.Update(model);
			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));

		}

		// DELETE api/<ShiftTabletLocationController>/5
		//[HttpDelete("{id}")]
		//public void Delete(int id) {
		//}
	}
}
