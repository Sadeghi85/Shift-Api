
using Leopard.Bussiness.Model;
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
		[HttpGet]
		[ProducesDefaultResponseType]
		public IActionResult Get() {

			IQueryable<ShiftShift>? res = _shiftService.GetAll();

			if (res.Count() > 0) {
				return Ok(OperationResult<IQueryable<ShiftShift>>.SuccessResult(res, res.Count()));
			}
			return Ok(OperationResult<string>.FailureResult(""));
		}

		// GET api/<ShiftController>/5
		[HttpGet("{portalId}")]
		public IActionResult Get(int portalId) {

			List<ShiftShift>? res = _shiftService.FindByPortalId(portalId);

			if (res.Count() > 0) {
				return Ok(OperationResult<List<ShiftShift>>.SuccessResult(res, res.Count()));
			}
			return Ok(OperationResult<string>.FailureResult(""));

			
			

		}



		// POST api/<ShiftController>
		[HttpPost]
		public async Task<IActionResult> Post(ShiftModel model) {
			int res = await _shiftService.Register(model);

			if (res > 0) {
				return Ok(OperationResult<int>.SuccessResult(res));
			}
			return Ok(OperationResult<string>.FailureResult(""));

		}


		// PUT api/<ShiftController>/5
		[HttpPut]
		public async Task<IActionResult> PutAsync(ShiftModel model) {

			int res = await _shiftService.Update(model);
			if (res > 0) {
				return Ok(OperationResult<int>.SuccessResult(res));
			}
			return Ok(OperationResult<string>.FailureResult(""));
		}

		// DELETE api/<ShiftController>/5
		[HttpDelete]
		public async Task<IActionResult> Delete(int id) {

			int res = await _shiftService.Delete(id);
			if (res > 0) {
				return Ok(OperationResult<int>.SuccessResult(res));
			}
			return Ok(OperationResult<string>.FailureResult(""));
		}
	}
}
