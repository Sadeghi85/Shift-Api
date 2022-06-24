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
	public class ShiftTabletController : YaldaController {



		readonly private IShiftTabletService _shiftTabletService;



		public ShiftTabletController(IShiftTabletService shiftTabletService) {
			_shiftTabletService = shiftTabletService;
		}



		// GET: api/<ShiftTabletController>
		[HttpPost("GetAll")]
		public async Task<IActionResult> GetAll(ShiftTabletSearchModel model) {



			//IQueryable<ShiftShiftTablet>? res = _shiftTabletService.GetAll();
			List<ShiftTabletResult>? res = await _shiftTabletService.GetAll(model);
			return Ok(OperationResult<List<ShiftTabletResult>?>.SuccessResult(res, _shiftTabletService.GetShiftTabletCount()));

		}



		// GET api/<ShiftTabletController>/5
		[HttpPost("GetByPortalId/{portalId}")]
		public IActionResult GetByPortalId(int portalId) {
			List<ShiftShiftTablet>? res = _shiftTabletService.GetTabletShiftByPortalId(portalId);

			return Ok(OperationResult<List<ShiftShiftTablet>>.SuccessResult(res, res.Count()));

		}

		// POST api/<ShiftTabletController>
		[HttpPost("Register")]
		public async Task<OkObjectResult> Register(ShiftTabletModel model) {
			if (!ModelState.IsValid) {
				var errors = ModelState.Select(x => x.Value.Errors)
						   .Where(y => y.Count > 0)
						   .ToList();


				var errMsgs = string.Join(",", errors[0].Select(pp => pp.ErrorMessage));
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var res = await _shiftTabletService.RegisterShiftTablet(model);
			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));

		}

		// PUT api/<ShiftTabletController>/5
		[HttpPost("Update")]
		public async Task<OkObjectResult> Update(ShiftTabletModel model) {
			if (!ModelState.IsValid) {
				var errors = ModelState.Select(x => x.Value.Errors)
						   .Where(y => y.Count > 0)
						   .ToList();
				var errMsgs = string.Join(",", errors[0].Select(pp => pp.ErrorMessage));
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}



			var res = await _shiftTabletService.UpdateShifTablet(model);
			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));

		}

		
		[HttpPost("Delete")]
		public async Task<IActionResult> Delete(ShiftTabletModel model) {
			var res = await _shiftTabletService.Delete(model);
			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));
		}
	}
}
