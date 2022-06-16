
using Leopard.Bussiness.Model;
using Leopard.Bussiness.Model.ReturnModel;
using Leopard.Bussiness.Services.Interface;
using Leopard.Repository;

using Microsoft.AspNetCore.Mvc;
using SamtApi.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SamtApi.Controllers.WebApi {
	[Route("api/[controller]")]
	[ApiController]
	public class ShiftController : ControllerBase {

		private readonly IShiftService _shiftService;
		public ShiftController(IShiftService shiftService) {
			_shiftService = shiftService;
		}


		// GET: api/<ShiftController>
		[HttpPost("GetAll")]
		[ProducesDefaultResponseType]
		public async Task< IActionResult> GetAll(ShiftSearchModel model) {

			var res =await _shiftService.GetAll(model);

			if (res.Count() > 0) {
				return Ok(OperationResult<List<ShiftResultModel>?>.SuccessResult(res, _shiftService.GetAllCount()));
			}
			return Ok(OperationResult<string>.FailureResult(""));
		}

		// GET api/<ShiftController>/5
		[HttpPost("FindByPortalId/{portalId}")]
		public IActionResult Get(int portalId) {

			List<ShiftShift>? res = _shiftService.FindByPortalId(portalId);

			if (res.Count() > 0) {
				return Ok(OperationResult<List<ShiftShift>>.SuccessResult(res, res.Count()));
			}
			return Ok(OperationResult<string>.FailureResult(""));

		}



		// POST api/<ShiftController>
		[HttpPost("Register")]
		public async Task<IActionResult> Register(ShiftModel model) {
			BaseResult? res = await _shiftService.Register(model);

			if (res.Success) {
				return Ok(OperationResult<BaseResult>.SuccessResult(res));
			}
			return Ok(OperationResult<BaseResult>.FailureResult(res.Message));

		}


		// PUT api/<ShiftController>/5
		[HttpPost("Update")]
		public async Task<IActionResult> Update(ShiftModel model) {

			int res = await _shiftService.Update(model);
			if (res > 0) {
				return Ok(OperationResult<int>.SuccessResult(res));
			}
			return Ok(OperationResult<string>.FailureResult(""));
		}

		// DELETE api/<ShiftController>/5
		[HttpPost("Delete/{id}")]
		public async Task<IActionResult> Delete(int id) {

			int res = await _shiftService.Delete(id);
			if (res > 0) {
				return Ok(OperationResult<int>.SuccessResult(res));
			}
			return Ok(OperationResult<string>.FailureResult(""));
		}
	}
}
