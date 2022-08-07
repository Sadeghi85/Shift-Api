using OfficeOpenXml;
using PdfRpt.Core.Contracts;

namespace Shift.Bussiness {
	public class ExcelDataReaderDataSource : IDataSource {
		private readonly string _filePath;
		private readonly string _worksheet;
		private readonly ExcelPackage _package;

		public ExcelDataReaderDataSource(string filePath, string worksheet) {
			_filePath = filePath;
			_worksheet = worksheet;
		}
		public ExcelDataReaderDataSource(ExcelPackage package, string worksheet) {
			_package = package;
			_worksheet = worksheet;
		}

		public IEnumerable<IList<CellData>> Rows() {
			//var fileInfo = new FileInfo(_filePath);
			//if (!fileInfo.Exists) {
			//	throw new FileNotFoundException($"{_filePath} file not found.");
			//}

			//using (var package = new ExcelPackage(fileInfo)) {
			//	var worksheet = package.Workbook.Worksheets[_worksheet];
			//	var startCell = worksheet.Dimension.Start;
			//	var endCell = worksheet.Dimension.End;

			//	for (var row = startCell.Row + 1; row < endCell.Row + 1; row++) {
			//		var i = 0;
			//		var result = new List<CellData>();
			//		for (var col = startCell.Column; col <= endCell.Column; col++) {
			//			var pdfCellData = new CellData {
			//				PropertyName = worksheet.Cells[1, col].Value.ToString(),
			//				PropertyValue = worksheet.Cells[row, col].Value,
			//				PropertyIndex = i++
			//			};
			//			result.Add(pdfCellData);
			//		}
			//		yield return result;
			//	}
			//}

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


			var worksheet = package.Workbook.Worksheets[_worksheet];
			var startCell = worksheet.Dimension.Start;
			var endCell = worksheet.Dimension.End;

			for (var row = startCell.Row + 1; row < endCell.Row + 1; row++) {
				var i = 0;
				var result = new List<CellData>();
				for (var col = startCell.Column; col <= endCell.Column; col++) {
					var pdfCellData = new CellData {
						PropertyName = worksheet.Cells[1, col].Value.ToString(),
						PropertyValue = worksheet.Cells[row, col].Value,
						PropertyIndex = i++
					};
					result.Add(pdfCellData);
				}
				yield return result;
			}

		}
	}
}
