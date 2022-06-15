using Leopard.Bussiness.Model;
using Leopard.Bussiness.Model.ReturnModel;
using Leopard.Bussiness.Services.Interface;
using Leopard.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SamtApi.Controllers.WebApi {
	[Route("api/[controller]")]
	[ApiController]
	public class ShiftTabletCrewController : ControllerBase {

		private readonly IShiftTabletCrewService _shiftTabletCrewService;

		public ShiftTabletCrewController(IShiftTabletCrewService shiftTabletCrewService) {
			_shiftTabletCrewService = shiftTabletCrewService;
		}

		//[HttpGet("GetReport")]
		//public IActionResult GetReport(int take , int skip) {

		//	var fromDate = DateTime.Parse("2022-06-12 00:00:00.000");
		//	var toDate = DateTime.Parse("2022-07-12 00:00:00.00");

		//	//var res = _shiftTabletCrewService.GetAll().Where(pp=> (pp.ShiftShiftTablet.ShiftDate>=fromDate && pp.ShiftShiftTablet.ShiftDate<= toDate)   ).Skip(5).Take(5).Select(pp=> new {pp.Id,  shiftTitle= pp.ShiftShiftTablet.ShiftShift.Title, firstName= pp.SamtAgent.FirstName , lastName = pp.SamtAgent.LastName, jobName = pp.SamtResourceType.Title , pp.ShiftShiftTablet.ShiftDate , WeekDay= pp.ShiftShiftTablet.ShiftDate.Value.DayOfWeek.ToString()  }).OrderBy(pp=> pp.ShiftDate) ;
		//	var res=	_shiftTabletCrewService.ShfitTabletReport(DateTime.Parse("2022-06-12 00:00:00.000"), DateTime.Parse("2022-07-12 00:00:00.000"), 3,take,skip);

		//	return Ok(res);

		//}



		// GET: api/<ShiftTabletCrewController>
		[HttpPost("GetAll")]
		public async Task<IActionResult> GetAll(ShiftTabletCrewSearchModel model) {
			List<ShiftTabletCrewSearchResult>? res = await _shiftTabletCrewService.GetAll(model);
			if (res.Count() > 0) {
				return Ok(OperationResult<List<ShiftTabletCrewSearchResult>?>.SuccessResult(res, _shiftTabletCrewService.GetAllCount()));
			}
			return Ok(OperationResult<string>.FailureResult(""));
		}

		// GET api/<ShiftTabletCrewController>/5
		[HttpPost("GetByShiftId/{id}")]
		public IActionResult GetByShiftId(int id) {
			List<ShiftShiftTabletCrew>? res = _shiftTabletCrewService.GetByShiftId(id);
			if (res.Count() > 0) {
				return Ok(OperationResult<List<ShiftShiftTabletCrew>>.SuccessResult(res, res.Count()));
			}
			return Ok(OperationResult<string>.FailureResult(""));
		}

		// POST api/<ShiftTabletCrewController>
		[HttpPost("Register")]
		public async Task<IActionResult> Register( ShiftTabletCrewModel model) {
			var res = await _shiftTabletCrewService.Register(model);

			if (res > 0) {
				return Ok(OperationResult<int>.SuccessResult(res));
			}
			return Ok(OperationResult<string>.FailureResult(""));

		}

		// PUT api/<ShiftTabletCrewController>/5
		[HttpPost("Update")]
		public async Task<IActionResult> Update(ShiftTabletCrewModel model) {
			var res = await _shiftTabletCrewService.Update(model);
			if (res > 0) {
				return Ok(OperationResult<int>.SuccessResult(res));
			}
			return Ok(OperationResult<string>.FailureResult(""));
		}

		[HttpPost("Replace/{replaced}/{replacedBy}")]
		public async Task<IActionResult> Replace(int replaced , int replacedBy) {
			var res = await _shiftTabletCrewService.Replace(replaced, replacedBy);
			if (res > 0) {
				return Ok(OperationResult<int>.SuccessResult(res));
			}
			return Ok(OperationResult<string>.FailureResult(""));
		}

		// DELETE api/<ShiftTabletCrewController>/5
		[HttpPost("Delete/{id}")]
		public async Task<IActionResult> Delete(int id) {
			var res = await _shiftTabletCrewService.Delete(id);
			if (res > 0) {
				return Ok(OperationResult<int>.SuccessResult(res));
			}
			return Ok(OperationResult<string>.FailureResult(""));
		}
	}
}
