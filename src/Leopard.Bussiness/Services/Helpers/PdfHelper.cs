using OfficeOpenXml;
using OfficeOpenXml.Packaging.Ionic.Zlib;
using PdfRpt.Core.Contracts;
using PdfRpt.FluentInterface;

namespace Leopard.Bussiness {
	public class PdfHelper {
		public IPdfReportData CreateExcelToPdfReport(ExcelPackage package, string filePath, string excelWorksheet, string filename, MemoryStream stream) {

			ExcelDataReaderDataSource excelDataReaderDataSource;

			if (null != package) {
				excelDataReaderDataSource = new ExcelDataReaderDataSource(package, excelWorksheet);
			} else {
				excelDataReaderDataSource = new ExcelDataReaderDataSource(filePath, excelWorksheet);
			}

			//var bytes = new 

			return new PdfReport().DocumentPreferences(doc => {
				doc.RunDirection(PdfRunDirection.RightToLeft);
				doc.Orientation(PageOrientation.Landscape);
				doc.PageSize(PdfPageSize.A4);
				doc.DocumentMetadata(new DocumentMetadata { Author = "YSP24.ir", Application = "PdfRpt", Keywords = "Report", Subject = "", Title = "Report" });
				doc.Compression(new CompressionSettings {
					EnableCompression = true,
					EnableFullCompression = true
				});
			})
				.DefaultFonts(fonts => {
					//fonts.Path(B_NAZANIN_FONT, ARIAL_FONT);
					fonts.Size(9);
					fonts.Color(System.Drawing.Color.Black);
				})
				.PagesFooter(footer => {
					footer.DefaultFooter(PersianDateTime.Now.ToString(PersianDateTimeFormat.DateTime));
				})
				//.PagesHeader(header => {
				//	header.CacheHeader(cache: true); // It's a default setting to improve the performance.
				//header.DefaultHeader(defaultHeader => {
				//	defaultHeader.RunDirection(PdfRunDirection.RightToLeft);
				//	defaultHeader.ImagePath(TestUtils.GetImagePath("01.png"));
				//	defaultHeader.Message("Excel To Pdf Report");
				//});
				//})

				.MainTableTemplate(template => {
					template.BasicTemplate(BasicTemplate.SilverTemplate);
				})
			.MainTablePreferences(table => {
				table.ColumnsWidthsType(TableColumnWidthType.Relative);
				table.GroupsPreferences(new GroupsPreferences {
					GroupType = GroupType.HideGroupingColumns,
					RepeatHeaderRowPerGroup = true,
					ShowOneGroupPerPage = false,
					SpacingBeforeAllGroupsSummary = 5f,
					NewGroupAvailableSpacingThreshold = 150
				});
			})




				//.MainTableTemplate(template => {
				//	template.BasicTemplate(BasicTemplate.ClassicTemplate);
				//})
				//.MainTablePreferences(table => {
				//	table.ColumnsWidthsType(TableColumnWidthType.Relative);
				//	table.MultipleColumnsPerPage(new MultipleColumnsPerPage {
				//		ColumnsGap = 7,
				//		ColumnsPerPage = 3,
				//		ColumnsWidth = 170,
				//		IsRightToLeft = false,
				//		TopMargin = 7
				//	});
				//})
				.MainTableDataSource(dataSource => {
					dataSource.CustomDataSource(() => excelDataReaderDataSource);
				})
				.MainTableColumns(columns => {
					//columns.AddColumn(column => {
					//	column.PropertyName("rowNo");
					//	column.IsRowNumber(true);
					//	column.CellsHorizontalAlignment(HorizontalAlignment.Center);
					//	column.IsVisible(true);
					//	column.Order(0);
					//	column.Width(1);
					//	column.HeaderCell("#");
					//});

					var order = 1;
					foreach (var columnInfo in this.GetColumns(package, filePath, excelWorksheet)) {
						columns.AddColumn(column => {
							column.PropertyName(columnInfo);
							column.CellsHorizontalAlignment(HorizontalAlignment.Center);
							column.IsVisible(true);
							column.Order(order++);
							column.Width(1);
							column.HeaderCell(columnInfo);
						});
					}
				})
				.MainTableEvents(events => {
					events.DataSourceIsEmpty(message: "There is no data available to display.");
				})
				.Generate(pp=> pp.AsPdfStream(stream , false));
				//.Generate(data => data.FlushInBrowser(filename, FlushType.Attachment));

		}

		public IList<string> GetColumns(ExcelPackage _package, string _filePath, string _excelWorksheet) {

			FileInfo fileInfo;
			ExcelPackage package;

			if (!string.IsNullOrEmpty(_filePath)) {
				fileInfo = new FileInfo(_filePath);
				if (!fileInfo.Exists) {
					throw new FileNotFoundException($"{_filePath} file not found.");
				}

				package = new ExcelPackage(fileInfo);
			} else if (null != _package) {
				package = _package;
			} else {
				throw new Exception($"Excel package is not set.");
			}

			var columns = new List<string>();

			var worksheet = package.Workbook.Worksheets[_excelWorksheet];
			var startCell = worksheet.Dimension.Start;
			var endCell = worksheet.Dimension.End;

			for (int col = startCell.Column; col <= endCell.Column; col++) {
				var colHeader = worksheet.Cells[1, col].Value.ToString();
				columns.Add(colHeader);
			}

			return columns;
		}
	}
}
