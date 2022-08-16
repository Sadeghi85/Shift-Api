using Shift.Repository;
using Stimulsoft.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Bussiness {
	public class ReportService : ServiceBase, IReportService {

		private readonly IPortalStore _portalStore;
		private readonly IShiftShiftTabletConductorChanxStore  _shiftShiftTabletConductorChanxStore;

		public ReportService(IPrincipal iPrincipal, IPortalStore portalStore, IShiftShiftTabletConductorChanxStore shiftShiftTabletConductorChanxStore, IShiftLogStore shiftLogStore) : base(iPrincipal, shiftLogStore) {
			_portalStore = portalStore;
			_shiftShiftTabletConductorChanxStore = shiftShiftTabletConductorChanxStore;
		}

		public async Task<MemoryStream> GetReport(PortalSearchModel model) {
			var stream = new MemoryStream();

			try {
				if (CurrentUserPortalId > 1) {
				model.Id = CurrentUserPortalId;
			}

			var getAllExpressions = new List<Expression<Func<ShiftShiftTabletConductorChanx, bool>>>();

			getAllExpressions.Add(x => x.IsDeleted == false);

			var conductorChanges = await _shiftShiftTabletConductorChanxStore.GetAllWithPagingAsync(getAllExpressions, x => new ShiftTabletConductorChangeViewModel { Id = x.Id, OldProgramTitle = x.OldProgramTitle, NewProgramTitle = x.NewProgramTitle }, model.OrderKey, model.Desc, model.PageSize, model.PageNo);


				StiOptions.Viewer.RightToLeft = StiRightToLeftType.Yes;
				//StiOptions.Engine.AllowSetCurrentDirectory = false;

				StiReport _report = new StiReport();
				_report.ReportCacheMode = StiReportCacheMode.Off;

				if (File.Exists(@"C:\Users\Sadeghi\Documents\Report.mrt")) {
					_report.Load(@"C:\Users\Sadeghi\Documents\Report.mrt");
				}
				

				_report.RegBusinessObject("ConductorChanges", conductorChanges.Result);

				var settings = new Stimulsoft.Report.Export.StiPdfExportSettings() {
					UseUnicode = true,
					StandardPdfFonts = false,
					EmbeddedFonts = true

				};


				


				var r = await _report.RenderAsync();

				//_report.Render(false);

				await r.ExportDocumentAsync(StiExportFormat.Pdf, stream, settings);

				stream.Seek(0, SeekOrigin.Begin);

				//Stimulsoft.Report.Web.StiReportResponse.ResponseAsPdf(r);
				// Respond with generated PDF
				//Stimulsoft.Report.Web.StiReportResponse.ResponseAsPdf(_report);

			} catch (Exception ex) {
				var i = 0;
			}

			return stream;





		}


	}
}
