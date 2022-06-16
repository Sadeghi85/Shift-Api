using Leopard.Bussiness.Model;
using Leopard.Bussiness.Model.ReturnModel;
using Leopard.Bussiness.Services.Interface;
using Leopard.Repository;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Packaging.Ionic.Zlib;
using PdfRpt.Core.Contracts;
using PdfRpt.FluentInterface;
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
			var shifts = res.Select(pp => pp.shiftTitle).Distinct().ToList();

			List<ReportTemplate> reportTemplates = new List<ReportTemplate>();

			foreach (var i in dates) {

				//var tmp = res.Where(pp => pp.PersianDate == i.PersianDate).Select(pp=> new PersonTemplate { Name=pp.firstName+" "+pp.lastName, ResourceName= pp.jobName, Shift= pp.shiftTitle  } ).ToList();
				//var tt = new ReportTemplate { PersianDate = i.PersianDate, DayName = i.PersianWeekDay, _personTemplates=tmp };

				//reportTemplates.Add(tt);
				var listOfshifts = new List<TheShift>();
				foreach (var j in shifts) {
					var thePersonsListTmp = res.Where(pp => pp.PersianDate == i.PersianDate && pp.shiftTitle == j).Select(pp => new ThePerson { Name = pp.firstName + " " + pp.lastName, ResourceName = pp.jobName }).ToList();
					var tmpShift = new TheShift { ShiftName = j, ThePersonList = thePersonsListTmp };
					//
					listOfshifts.Add(tmpShift);

				}
				var tt = new ReportTemplate { DayName = i.PersianWeekDay, PersianDate = i.PersianDate, Shifts = listOfshifts };

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

		//public IPdfReportData CreateExcelToPdfReport(ExcelPackage package, string filePath, string excelWorksheet, string filename) {

		//	ExcelDataReaderDataSource excelDataReaderDataSource;

		//	if (null != package) {
		//		excelDataReaderDataSource = new ExcelDataReaderDataSource(package, excelWorksheet);
		//	} else {
		//		excelDataReaderDataSource = new ExcelDataReaderDataSource(filePath, excelWorksheet);
		//	}

		//	return new PdfReport().DocumentPreferences(doc => {
		//		doc.RunDirection(PdfRunDirection.RightToLeft);
		//		doc.Orientation(PageOrientation.Landscape);
		//		doc.PageSize(PdfPageSize.A4);
		//		doc.DocumentMetadata(new DocumentMetadata { Author = "YSP24.ir", Application = "PdfRpt", Keywords = "Report", Subject = "", Title = "Report" });
		//		doc.Compression(new CompressionSettings {
		//			EnableCompression = true,
		//			EnableFullCompression = true
		//		});
		//	})
		//		.DefaultFonts(fonts => {
		//			fonts.Path(B_NAZANIN_FONT, ARIAL_FONT);
		//			fonts.Size(9);
		//			fonts.Color(System.Drawing.Color.Black);
		//		})
		//		.PagesFooter(footer => {
		//			footer.DefaultFooter(PersianDateTime.Now.ToString(PersianDateTimeFormat.DateTime));
		//		})
		//		//.PagesHeader(header => {
		//		//	header.CacheHeader(cache: true); // It's a default setting to improve the performance.
		//		//header.DefaultHeader(defaultHeader => {
		//		//	defaultHeader.RunDirection(PdfRunDirection.RightToLeft);
		//		//	defaultHeader.ImagePath(TestUtils.GetImagePath("01.png"));
		//		//	defaultHeader.Message("Excel To Pdf Report");
		//		//});
		//		//})

		//		.MainTableTemplate(template => {
		//			template.BasicTemplate(BasicTemplate.SilverTemplate);
		//		})
		//	.MainTablePreferences(table => {
		//		table.ColumnsWidthsType(TableColumnWidthType.Relative);
		//		table.GroupsPreferences(new GroupsPreferences {
		//			GroupType = GroupType.HideGroupingColumns,
		//			RepeatHeaderRowPerGroup = true,
		//			ShowOneGroupPerPage = false,
		//			SpacingBeforeAllGroupsSummary = 5f,
		//			NewGroupAvailableSpacingThreshold = 150
		//		});
		//	})




		//		//.MainTableTemplate(template => {
		//		//	template.BasicTemplate(BasicTemplate.ClassicTemplate);
		//		//})
		//		//.MainTablePreferences(table => {
		//		//	table.ColumnsWidthsType(TableColumnWidthType.Relative);
		//		//	table.MultipleColumnsPerPage(new MultipleColumnsPerPage {
		//		//		ColumnsGap = 7,
		//		//		ColumnsPerPage = 3,
		//		//		ColumnsWidth = 170,
		//		//		IsRightToLeft = false,
		//		//		TopMargin = 7
		//		//	});
		//		//})
		//		.MainTableDataSource(dataSource => {
		//			dataSource.CustomDataSource(() => excelDataReaderDataSource);
		//		})
		//		.MainTableColumns(columns => {
		//			//columns.AddColumn(column => {
		//			//	column.PropertyName("rowNo");
		//			//	column.IsRowNumber(true);
		//			//	column.CellsHorizontalAlignment(HorizontalAlignment.Center);
		//			//	column.IsVisible(true);
		//			//	column.Order(0);
		//			//	column.Width(1);
		//			//	column.HeaderCell("#");
		//			//});

		//			var order = 1;
		//			foreach (var columnInfo in this.GetColumns(package, filePath, excelWorksheet)) {
		//				columns.AddColumn(column => {
		//					column.PropertyName(columnInfo);
		//					column.CellsHorizontalAlignment(HorizontalAlignment.Center);
		//					column.IsVisible(true);
		//					column.Order(order++);
		//					column.Width(1);
		//					column.HeaderCell(columnInfo);
		//				});
		//			}
		//		})
		//		.MainTableEvents(events => {
		//			events.DataSourceIsEmpty(message: "There is no data available to display.");
		//		})
		//		.Generate(data => data.FlushInBrowser(filename, FlushType.Attachment));
		//}

		//public IList<string> GetColumns(ExcelPackage _package, string _filePath, string _excelWorksheet) {

		//	FileInfo fileInfo;
		//	ExcelPackage package;

		//	if (!string.IsNullOrEmpty(_filePath)) {
		//		fileInfo = new FileInfo(_filePath);
		//		if (!fileInfo.Exists) {
		//			throw new FileNotFoundException($"{_filePath} file not found.");
		//		}

		//		package = new ExcelPackage(fileInfo);
		//	} else if (null != _package) {
		//		package = _package;
		//	} else {
		//		throw new Exception($"Excel package is not set.");
		//	}

		//	var columns = new List<string>();

		//	var worksheet = package.Workbook.Worksheets[_excelWorksheet];
		//	var startCell = worksheet.Dimension.Start;
		//	var endCell = worksheet.Dimension.End;

		//	for (int col = startCell.Column; col <= endCell.Column; col++) {
		//		var colHeader = worksheet.Cells[1, col].Value.ToString();
		//		columns.Add(colHeader);
		//	}

		//	return columns;
		//}


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
