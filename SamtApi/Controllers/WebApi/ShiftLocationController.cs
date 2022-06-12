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
	public class ShiftLocationController : ControllerBase {

		readonly private IShiftLocationService _shiftLocationService;

		public ShiftLocationController(IShiftLocationService shiftLocationService) {
			_shiftLocationService = shiftLocationService;
		}
	



		// GET: api/<ShiftLocationController>
		[HttpGet]
		public IActionResult Get() {
			List<ShiftLocationReturnModel> res = _shiftLocationService.GetAll();

			if (res.Count() > 0) {
				return Ok(OperationResult<List<ShiftLocationReturnModel>>.SuccessResult(res, res.Count()));
			}
			return Ok(OperationResult<string>.FailureResult(""));

		}

		// GET api/<ShiftLocationController>/5
		[HttpGet("{id}")]
		public IActionResult Get(int portalId) {

			List<ShiftLocation>? res = _shiftLocationService.GetShiftLocationByPortalId(portalId);

			if (res.Count() > 0) {
				return Ok(OperationResult<List<ShiftLocation>>.SuccessResult(res, res.Count()));
			}
			return Ok(OperationResult<string>.FailureResult(""));
		}


		// POST api/<ShiftLocationController>
		[HttpPost]
		public async Task<OkObjectResult> PostAsync(ShiftLocationModel model) {

			ShiftLocation shiftLocation = new ShiftLocation { Title = model.Title, PortalId = model.PortalId };
			var res = await _shiftLocationService.RegisterShiftLocation(model);
			if (res > 0) {
				return Ok(OperationResult<int>.SuccessResult(res));
			}
			return Ok(OperationResult<string>.FailureResult(""));

		}

		// PUT api/<ShiftLocationController>/5
		[HttpPut]
		public async Task<OkObjectResult> Put( ShiftLocationModel model) {
			var res = await _shiftLocationService.Update(model);
			if (res > 0) {
				return Ok(OperationResult<int>.SuccessResult(res));
			}
			return Ok(OperationResult<string>.FailureResult(""));


		}

		// DELETE api/<ShiftLocationController>/5
		[HttpDelete("{id}")]
		public void Delete(int id) {
		}
	}
}
