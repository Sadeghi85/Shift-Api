using Leopard.Bussiness.Model;
using Leopard.Bussiness.Model.ReturnModel;
using Leopard.Bussiness.Services.Interface;
using Leopard.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SamtApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SamtApi.Controllers.WebApi {
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class ShiftLocationController : YaldaController {

		readonly private IShiftLocationService _shiftLocationService;

		public ShiftLocationController(IShiftLocationService shiftLocationService) {
			_shiftLocationService = shiftLocationService;
		}




		// GET: api/<ShiftLocationController>
		[HttpPost("GetAll")]
		public async Task<IActionResult> GetAll(ShiftLocationSearchModel model) {

			var portalId = GetUserPortalId() ?? 0;
			if (portalId > 1) {
				model.PortalId = portalId;
			}
			//List<ShiftLocationReturnModel>? res = null;
			//try {
			List<ShiftLocationReturnModel>? res = await _shiftLocationService.GetAll(model);
			//} catch (Exception ex) {

				
			//}

			return Ok(OperationResult<List<ShiftLocationReturnModel>>.SuccessResult(res, _shiftLocationService.GetAllTotal()));
		}

		// GET api/<ShiftLocationController>/5
		[HttpPost("{portalId}")]
		public IActionResult Get(int portalId) {

			List<ShiftLocation>? res = _shiftLocationService.GetShiftLocationByPortalId(portalId);
			return Ok(OperationResult<List<ShiftLocation>>.SuccessResult(res, res.Count()));
		}


		// POST api/<ShiftLocationController>
		[HttpPost("Register")]
		public async Task<OkObjectResult> Register(ShiftLocationModel model) {
			if (!ModelState.IsValid) {


				var errors = ModelState.Select(x => x.Value.Errors)
						   .Where(y => y.Count > 0)
						   .ToList();


				var errMsgs = string.Join(",", errors[0].Select(pp => pp.ErrorMessage));
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			ShiftLocation shiftLocation = new ShiftLocation { Title = model.Title, PortalId = model.PortalId.Value };
			var res = await _shiftLocationService.RegisterShiftLocation(model);
			if ( res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));

		}

		// PUT api/<ShiftLocationController>/5
		[HttpPost("Update")]
		public async Task<OkObjectResult> Update(ShiftLocationModel model) {
			var res = await _shiftLocationService.Update(model);
			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));


		}

		[HttpPost("Delete")]
		public async Task<OkObjectResult> Delete(ShiftLocationModel model) {
			var res = await _shiftLocationService.Delete(model);
			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));


		}
	}
}
