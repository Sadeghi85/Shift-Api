using Microsoft.AspNetCore.Hosting;
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
		private readonly IShiftShiftTabletStore _shiftShiftTabletStore;
		private readonly IShiftShiftTabletConductorChanxStore _shiftShiftTabletConductorChanxStore;
		private readonly IShiftShiftTabletReviewProblemStore _shiftShiftTabletReviewProblemStore;

		public ReportService(IPrincipal iPrincipal, IPortalStore portalStore, IShiftShiftTabletConductorChanxStore shiftShiftTabletConductorChanxStore, IShiftLogStore shiftLogStore, IShiftShiftTabletStore shiftShiftTabletStore, IShiftShiftTabletReviewProblemStore shiftShiftTabletReviewProblemStore) : base(iPrincipal, shiftLogStore) {
			_portalStore = portalStore;
			_shiftShiftTabletConductorChanxStore = shiftShiftTabletConductorChanxStore;
			_shiftShiftTabletStore = shiftShiftTabletStore;
			_shiftShiftTabletReviewProblemStore = shiftShiftTabletReviewProblemStore;
		}

		public async Task<MemoryStream?> GetSecretaryReport(int shiftTabletId) {
			var stream = new MemoryStream();

			try {

				var foundShiftTablet = await _shiftShiftTabletStore.FindByIdAsync(shiftTabletId);
				if (null == foundShiftTablet) {
					return null;
				}

				if (CurrentUserPortalId > 1 && CurrentUserPortalId != foundShiftTablet.PortalId) {
					return null;
				}

				var conductorChanges = await _shiftShiftTabletConductorChanxStore.GetAllAsync(x => x.IsDeleted == false && x.ShiftTabletId == shiftTabletId, x => new ShiftTabletConductorChangeViewModel { Id = x.Id, OldProgramTitle = x.OldProgramTitle, NewProgramTitle = x.NewProgramTitle, Description = x.Description }, x => x.Id);

				var reviewProblems = await _shiftShiftTabletReviewProblemStore.GetAllAsync(x => x.IsDeleted == false && x.ShiftTabletId == shiftTabletId, x => new ShiftTabletReviewProblemViewModel { Id = x.Id, Description = x.Description, ClacketNo = x.ClacketNo, FileNumber = x.FileNumber, ProblemDescription = x.ProblemDescription, ProgramTitle = x.ProgramTitle, ReviewerCode = x.ReviewerCode }, x => x.Id);


				StiOptions.Viewer.RightToLeft = StiRightToLeftType.Yes;
				//StiOptions.Engine.AllowSetCurrentDirectory = false;

				StiReport report = new StiReport();
				report.ReportCacheMode = StiReportCacheMode.Off;

				var reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SecretaryReport.mrt");

				if (File.Exists(reportPath)) {
					report.Load(reportPath);

					report.RegBusinessObject("ConductorChanges", conductorChanges.Result);
					report.RegBusinessObject("ReviewProblems", reviewProblems.Result);

					var settings = new Stimulsoft.Report.Export.StiPdfExportSettings() {
						UseUnicode = true,
						StandardPdfFonts = false,
						EmbeddedFonts = true

					};





					await report.RenderAsync();

					//_report.Render(false);

					await report.ExportDocumentAsync(StiExportFormat.Pdf, stream, settings);

					stream.Seek(0, SeekOrigin.Begin);

					//Stimulsoft.Report.Web.StiReportResponse.ResponseAsPdf(r);
					// Respond with generated PDF
					//Stimulsoft.Report.Web.StiReportResponse.ResponseAsPdf(_report);
				}




			} catch (Exception ex) {
				var i = 0;
			}

			return stream;





		}


	}
}
