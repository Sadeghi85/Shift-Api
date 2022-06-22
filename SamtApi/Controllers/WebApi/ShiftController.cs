
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
	public class ShiftController : YaldaController {

		private readonly IShiftService _shiftService;
		public ShiftController(IShiftService shiftService) {
			_shiftService = shiftService;
		}


		// GET: api/<ShiftController>
		[HttpPost("GetAll")]
		[ProducesDefaultResponseType]
		public async Task<IActionResult> GetAll(ShiftSearchModel model) {

			var res = await _shiftService.GetAll(model);

			return Ok(OperationResult<List<ShiftResultModel>?>.SuccessResult(res, _shiftService.GetAllCount()));

		}

		// GET api/<ShiftController>/5
		[HttpPost("FindByPortalId/{portalId}")]
		public IActionResult Get(int portalId) {

			List<ShiftShift>? res = _shiftService.FindByPortalId(portalId);


			return Ok(OperationResult<List<ShiftShift>>.SuccessResult(res, res.Count()));



		}



		// POST api/<ShiftController>
		[HttpPost("Register")]
		public async Task<IActionResult> Register(ShiftModel model) {
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
		public async Task<IActionResult> Update(ShiftModel model) {

			var res = await _shiftService.Update(model);
			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));
		}

		// DELETE api/<ShiftController>/5
		[HttpPost("Delete")]
		public async Task<IActionResult> Delete(ShiftModel model) {

			var res = await _shiftService.Delete(model);
			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));
		}
	}
}
