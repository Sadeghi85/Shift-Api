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
	public class ShiftTabletController : ControllerBase {

		

		readonly private IShiftTabletService _shiftTabletService;

		

		public ShiftTabletController(IShiftTabletService shiftTabletService) {
			_shiftTabletService = shiftTabletService;
		}



		// GET: api/<ShiftTabletController>
		[HttpPost("GetAll")]
		public async Task< IActionResult> GetAll(ShiftTabletSearchModel model) {



			//IQueryable<ShiftShiftTablet>? res = _shiftTabletService.GetAll();
			List<ShiftTabletResult>? res = await _shiftTabletService.GetAll(model);

			if (res.Count() > 0) {
				return Ok(OperationResult<List<ShiftTabletResult>?>.SuccessResult(res,_shiftTabletService.GetShiftTabletCount()));
			}
			return Ok(OperationResult<string>.FailureResult(""));

		}

		

		// GET api/<ShiftTabletController>/5
		[HttpPost("GetByPortalId/{portalId}")]
		public IActionResult GetByPortalId(int portalId) {
			List<ShiftShiftTablet>? res = _shiftTabletService.GetTabletShiftByPortalId(portalId);
			if (res.Count() > 0) {
				return Ok(OperationResult<List<ShiftShiftTablet>>.SuccessResult(res, res.Count()));
			}
			return Ok(OperationResult<string>.FailureResult(""));

		}

		// POST api/<ShiftTabletController>
		[HttpPost("Register")]
		public async Task<OkObjectResult> Register(ShiftTabletModel model) {
			
			var res = await _shiftTabletService.RegisterShiftTablet(model);
			if (res > 0) {
				return Ok(OperationResult<int>.SuccessResult(res));
			}
			return Ok(OperationResult<string>.FailureResult(""));

		}

		// PUT api/<ShiftTabletController>/5
		[HttpPost("Update")]
		public async Task<OkObjectResult> Update(ShiftTabletModel model) {
			var res = await _shiftTabletService.UpdateShifTablet(model);
			if (res > 0) {
				return Ok(OperationResult<int>.SuccessResult(res));
			}
			return Ok(OperationResult<string>.FailureResult(""));

		}

		// DELETE api/<ShiftTabletController>/5
		//[HttpDelete("{id}")]
		//public void Delete(int id) {
		//}
	}
}
