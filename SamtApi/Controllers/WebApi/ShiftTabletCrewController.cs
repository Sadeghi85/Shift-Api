using Leopard.Bussiness.Model;
using Leopard.Bussiness.Model.ReturnModel;
using Leopard.Bussiness.Services.Interface;
using Leopard.Repository;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using SamtApi.Models;

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
			List<ShfitTabletReportResult>? res = await _shiftTabletCrewService.GetAll(model);
			if (res.Count() > 0) {
				return Ok(OperationResult<List<ShfitTabletReportResult>?>.SuccessResult(res, _shiftTabletCrewService.GetAllCount()));
			}
			return Ok(OperationResult<string>.FailureResult(""));
		}

		[HttpPost("GetGeExcel")]
		public async Task<IActionResult> GetGeExcel(ShiftTabletCrewSearchModel model) {

			List<ShfitTabletReportResult>? res = await _shiftTabletCrewService.GetAll(model);

			var dates = res.Select(pp => new { pp.PersianDate, pp.PersianWeekDay }).Distinct().ToList();

			List<ReportTemplate> reportTemplates = new List<ReportTemplate>();
			
			foreach (var i in dates) {

				var tmp = res.Where(pp => pp.PersianDate == i.PersianDate).Select(pp=> new PersonTemplate { Name=pp.firstName+" "+pp.lastName, ResourceName= pp.jobName, Shift= pp.shiftTitle  } ).ToList();
				var tt = new ReportTemplate { PersianDate = i.PersianDate, DayName = i.PersianWeekDay, _personTemplates=tmp };

				reportTemplates.Add(tt);



			}



			var stream = new MemoryStream();

			ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

			using (var package = new ExcelPackage(stream)) {

				var ws = package.Workbook.Worksheets.Add("Contracts Report");


				var row = 1;
				//foreach (var i in res) {
				//	ws.Cells["A" + row].Value = i.shiftTitle;
				//	ws.Cells["B" + row].Value = i.firstName;
				//	ws.Cells["C" + row].Value = i.lastName;
				//	ws.Cells["D" + row].Value = i.PersianDate;
				//	ws.Cells["E" + row].Value = i.jobName;
				//	ws.Cells["F" + row].Value = i.PersianWeekDay;

				//	row++;
				//}

				foreach(var i in reportTemplates) {

					ws.Cells["A" + row].Value = i.PersianDate;
					ws.Cells["B" + row].Value = i.DayName;

					row++;
				}







				ws.View.RightToLeft = true;
				package.SaveAs(stream);
				stream.Position = 0;


			}
			return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"Report.xlsx");


			//return Ok();
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
		public async Task<IActionResult> Register(ShiftTabletCrewModel model) {
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
		public async Task<IActionResult> Replace(int replaced, int replacedBy) {
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
