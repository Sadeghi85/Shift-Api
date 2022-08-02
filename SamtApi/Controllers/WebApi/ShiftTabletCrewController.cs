using Leopard.Bussiness;
using Leopard.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Packaging.Ionic.Zlib;
using PdfRpt.Core.Contracts;
using PdfRpt.FluentInterface;
using SamtApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SamtApi.Controllers.WebApi {

	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class ShiftTabletCrewController : YaldaController {

		private readonly IShiftTabletCrewService _shiftTabletCrewService;

		public ShiftTabletCrewController(IShiftTabletCrewService shiftTabletCrewService) {
			_shiftTabletCrewService = shiftTabletCrewService;
		}

		// GET: api/<ShiftTabletCrewController>
		[HttpPost("GetAll")]
		public async Task<IActionResult> GetAll(ShiftTabletCrewSearchModel model) {
			if (!ModelState.IsValid) {
				var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

				var errMsgs = string.Join(Environment.NewLine, allErrors);
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var res = await _shiftTabletCrewService.GetAll(model);

			return Ok(OperationResult<List<ShiftTabletCrewViewModel>>.SuccessResult(res.Result, res.TotalCount));

		}

		[HttpPost("GetExcel")]
		public async Task<IActionResult> GetExcel(ShiftTabletCrewSearchModel model) {
			if (!ModelState.IsValid) {
				var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

				var errMsgs = string.Join(Environment.NewLine, allErrors);
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var res = await _shiftTabletCrewService.GetAll(model);

			var dates = res.Result.Select(pp => new { pp.ShiftDatePersian, pp.PersianWeekDay }).Distinct().ToList();
			var shifts = res.Result.Select(pp => pp.ShiftTitle).Distinct().ToList();

			List<ReportTemplate> reportTemplates = new List<ReportTemplate>();

			foreach (var i in dates) {

				//var tmp = res.Where(pp => pp.PersianDate == i.PersianDate).Select(pp=> new PersonTemplate { Name=pp.firstName+" "+pp.lastName, ResourceName= pp.jobName, Shift= pp.shiftTitle  } ).ToList();
				//var tt = new ReportTemplate { PersianDate = i.PersianDate, DayName = i.PersianWeekDay, _personTemplates=tmp };

				//reportTemplates.Add(tt);
				var listOfshifts = new List<TheShift>();
				foreach (var j in shifts) {
					var thePersonsListTmp = res.Result.Where(pp => pp.ShiftDatePersian == i.ShiftDatePersian && pp.ShiftTitle == j).Select(pp => new ThePerson { Name = pp.FirstName + " " + pp.LastName, ResourceName = pp.JobTitle }).ToList();
					var tmpShift = new TheShift { ShiftName = j, ThePersonList = thePersonsListTmp };
					//
					listOfshifts.Add(tmpShift);

				}
				var tt = new ReportTemplate { DayName = i.PersianWeekDay, PersianDate = i.ShiftDatePersian, Shifts = listOfshifts };

				reportTemplates.Add(tt);
			}



			var stream = new MemoryStream();

			ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

			using (var package = new ExcelPackage(stream)) {

				var ws = package.Workbook.Worksheets.Add("Contracts Report");


				var row = 2;

				ws.Cells["A1"].Value = "تاریخ";
				ws.Cells["A1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

				ws.Cells["B1"].Value = "ایام هفته";
				ws.Cells["B1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

				ws.Cells["C1"].Value = "شیفت";
				ws.Cells["C1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
				//foreach (var i in res) {
				//	ws.Cells["A" + row].Value = i.shiftTitle;
				//	ws.Cells["B" + row].Value = i.firstName;
				//	ws.Cells["C" + row].Value = i.lastName;
				//	ws.Cells["D" + row].Value = i.PersianDate;
				//	ws.Cells["E" + row].Value = i.jobName;
				//	ws.Cells["F" + row].Value = i.PersianWeekDay;

				//	row++;
				//}
				ws.Cells["1:1"].Style.Font.Bold = true;


				foreach (var i in reportTemplates) {

					var shiftCount = i.Shifts.Count;

					string amerge = "A" + row + ":A" + (row + shiftCount - 1);
					ws.Cells[amerge].Merge = true;
					ws.Cells["A" + row].Value = i.PersianDate;
					ws.Cells["A" + row].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
					ws.Cells["A" + row].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

					string bmerge = "B" + row + ":B" + (row + shiftCount - 1);
					ws.Cells[bmerge].Merge = true;
					ws.Cells["B" + row].Value = i.DayName;
					ws.Cells["B" + row].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
					ws.Cells["B" + row].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

					var query4 =
						(from cell in ws.Cells["1:1"]
						 where cell.Value?.ToString() == "شیفت"
						 select cell).FirstOrDefault();

					var sss = ws.Cells["D7"].Value;

					var tmpshifCount = row;
					foreach (var shif in i.Shifts) {
						ws.Cells["C" + tmpshifCount].Value = shif.ShiftName;

						foreach (var k in shif.ThePersonList) {
							var resourceTmp = k.ResourceName;
							var query3 =
									(from cell in ws.Cells["1:1"]
									 where cell.Value?.ToString() == resourceTmp
									 select cell).FirstOrDefault();
							if (query3 != null) {
								var ss = OfficeOpenXml.ExcelCellAddress.GetColumnLetter(query3.Start.Column);
								ws.Cells[ss + tmpshifCount].Value = k.Name;

							} else {
								var qw = ws.Cells["1:1"].Where(pp => pp.Value != null).LastOrDefault();
								var newcol = qw.Start.Column + 1;
								var ss = OfficeOpenXml.ExcelCellAddress.GetColumnLetter(newcol);
								ws.Cells[ss + 1].Value = resourceTmp;
								ws.Cells[ss + tmpshifCount].Value = k.Name;
							}
						}
						tmpshifCount++;
					}
					row = row + shiftCount;
				}
				ws.View.RightToLeft = true;
				package.SaveAs(stream);
				stream.Position = 0;
			}

			return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"Report.xlsx");
		}


		[HttpPost("GetPdf")]
		public async Task<IActionResult> GetPdf(ShiftTabletCrewSearchModel model) {
			if (!ModelState.IsValid) {
				var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

				var errMsgs = string.Join(Environment.NewLine, allErrors);
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var res = await _shiftTabletCrewService.GetAll(model);


			var dates = res.Result.Select(pp => new { pp.ShiftDatePersian, pp.PersianWeekDay }).Distinct().ToList();
			var shifts = res.Result.Select(pp => pp.ShiftTitle).Distinct().ToList();

			List<ReportTemplate> reportTemplates = new List<ReportTemplate>();
			IPdfReportData pdfRes;
			foreach (var i in dates) {

				//var tmp = res.Where(pp => pp.PersianDate == i.PersianDate).Select(pp=> new PersonTemplate { Name=pp.firstName+" "+pp.lastName, ResourceName= pp.jobName, Shift= pp.shiftTitle  } ).ToList();
				//var tt = new ReportTemplate { PersianDate = i.PersianDate, DayName = i.PersianWeekDay, _personTemplates=tmp };

				//reportTemplates.Add(tt);
				var listOfshifts = new List<TheShift>();
				foreach (var j in shifts) {
					var thePersonsListTmp = res.Result.Where(pp => pp.ShiftDatePersian == i.ShiftDatePersian && pp.ShiftTitle == j).Select(pp => new ThePerson { Name = pp.FirstName + " " + pp.LastName, ResourceName = pp.JobTitle }).ToList();
					var tmpShift = new TheShift { ShiftName = j, ThePersonList = thePersonsListTmp };
					//
					listOfshifts.Add(tmpShift);

				}
				var tt = new ReportTemplate { DayName = i.PersianWeekDay, PersianDate = i.ShiftDatePersian, Shifts = listOfshifts };

				reportTemplates.Add(tt);
			}



			var stream = new MemoryStream();
			var pdfStream = new MemoryStream();
			var pdfResStream = new MemoryStream();

			ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

			using (var package = new ExcelPackage(stream)) {

				var ws = package.Workbook.Worksheets.Add("Contracts Report");


				var row = 2;

				ws.Cells["A1"].Value = "تاریخ";
				ws.Cells["A1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

				ws.Cells["B1"].Value = "ایام هفته";
				ws.Cells["B1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

				ws.Cells["C1"].Value = "شیفت";
				ws.Cells["C1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
				//foreach (var i in res) {
				//	ws.Cells["A" + row].Value = i.shiftTitle;
				//	ws.Cells["B" + row].Value = i.firstName;
				//	ws.Cells["C" + row].Value = i.lastName;
				//	ws.Cells["D" + row].Value = i.PersianDate;
				//	ws.Cells["E" + row].Value = i.jobName;
				//	ws.Cells["F" + row].Value = i.PersianWeekDay;

				//	row++;
				//}
				ws.Cells["1:1"].Style.Font.Bold = true;


				foreach (var i in reportTemplates) {

					var shiftCount = i.Shifts.Count;

					string amerge = "A" + row + ":A" + (row + shiftCount - 1);
					ws.Cells[amerge].Merge = true;
					ws.Cells["A" + row].Value = i.PersianDate;
					ws.Cells["A" + row].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
					ws.Cells["A" + row].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

					string bmerge = "B" + row + ":B" + (row + shiftCount - 1);
					ws.Cells[bmerge].Merge = true;
					ws.Cells["B" + row].Value = i.DayName;
					ws.Cells["B" + row].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
					ws.Cells["B" + row].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

					var query4 =
	(from cell in ws.Cells["1:1"]
	 where cell.Value?.ToString() == "شیفت"
	 select cell).FirstOrDefault();

					var sss = ws.Cells["D7"].Value;

					var tmpshifCount = row;
					foreach (var shif in i.Shifts) {
						ws.Cells["C" + tmpshifCount].Value = shif.ShiftName;

						foreach (var k in shif.ThePersonList) {
							var resourceTmp = k.ResourceName;
							var query3 =
									(from cell in ws.Cells["1:1"]
									 where cell.Value?.ToString() == resourceTmp
									 select cell).FirstOrDefault();
							if (query3 != null) {
								var ss = OfficeOpenXml.ExcelCellAddress.GetColumnLetter(query3.Start.Column);
								ws.Cells[ss + tmpshifCount].Value = k.Name;

							} else {
								var qw = ws.Cells["1:1"].Where(pp => pp.Value != null).LastOrDefault();
								var newcol = qw.Start.Column + 1;
								var ss = OfficeOpenXml.ExcelCellAddress.GetColumnLetter(newcol);
								ws.Cells[ss + 1].Value = resourceTmp;
								ws.Cells[ss + tmpshifCount].Value = k.Name;
							}
						}
						tmpshifCount++;
					}
					row = row + shiftCount;
				}
				ws.View.RightToLeft = true;


				package.SaveAs(stream);



				stream.Position = 0;
				ReportActions ReportActions = new ReportActions();

				pdfRes = ReportActions.CreateExcelToPdfReport(package, "", "Contracts Report", "", new MemoryStream());


			}



			//InMemoryPdfReport.CreateInMemoryPdfReport(null);
			return File(pdfRes.PdfStreamOutput, "application/pdf", $"Report.pdf");
			//return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"Report.xlsx");
		}

		//GET api/<ShiftTabletCrewController>/5
		//[HttpPost("GetByShiftId/{id}")]
		//public IActionResult GetByShiftId(int id) {
		//	List<ShiftShiftTabletCrew>? res = _shiftTabletCrewService.GetByShiftId(id);

		//	return Ok(OperationResult<List<ShiftShiftTabletCrew>>.SuccessResult(res, res.Count()));

		//}

		// POST api/<ShiftTabletCrewController>
		[HttpPost("Register")]
		public async Task<IActionResult> Register(ShiftTabletCrewInputModel model) {

			if (!ModelState.IsValid) {
				var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

				var errMsgs = string.Join(Environment.NewLine, allErrors);
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var res = await _shiftTabletCrewService.Register(model);

			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));

		}

		[HttpPost("Update")]
		public async Task<IActionResult> Update(ShiftTabletCrewInputModel model) {
			if (!ModelState.IsValid) {
				var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

				var errMsgs = string.Join(Environment.NewLine, allErrors);
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var res = await _shiftTabletCrewService.Update(model);

			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));
		}

		//[HttpPost("Replace/{replaced}/{replacedBy}")]
		//public async Task<IActionResult> Replace(int replaced, int replacedBy) {
		//	var res = await _shiftTabletCrewService.Replace(replaced, replacedBy);
		//	if (res > 0) {
		//		return Ok(OperationResult<int>.SuccessResult(res));
		//	}
		//	return Ok(OperationResult<string>.FailureResult(""));
		//}

		[HttpPost("Delete")]
		public async Task<IActionResult> Delete(int id) {
			if (!ModelState.IsValid) {
				var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

				var errMsgs = string.Join(Environment.NewLine, allErrors);
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var res = await _shiftTabletCrewService.Delete(id);

			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));
		}
	}
}
