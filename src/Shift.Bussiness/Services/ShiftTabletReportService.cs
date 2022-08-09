using Shift.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text.Json;
using System.Text.Json.Serialization;
using OfficeOpenXml;
using PdfRpt.Core.Contracts;

namespace Shift.Bussiness {
	public class ShiftTabletReportService : ServiceBase, IShiftTabletReportService {

		private readonly IShiftShiftTabletStore _shiftShiftTabletStore;
		private readonly IShiftShiftTabletReportStore _shiftShiftTabletReportStore;

		public ShiftTabletReportService(IPrincipal iPrincipal, IShiftShiftTabletStore shiftShiftTabletStore, IShiftLogStore shiftLogStore, IShiftShiftTabletReportStore shiftShiftTabletReportStore) : base(iPrincipal, shiftLogStore) {

			_shiftShiftTabletStore = shiftShiftTabletStore;
			_shiftShiftTabletReportStore = shiftShiftTabletReportStore;
		}


		public async Task<StoreViewModel<ShiftTabletReportViewModel>> GetAll(ShiftTabletReportSearchModel model) {

			var getAllExpressions = new List<Expression<Func<ShiftShiftTabletReport, bool>>>();

			getAllExpressions.Add(pp => pp.ShiftShiftTablet.IsDeleted == false);

			if (CurrentUserPortalId == 1) {
				//if (model.PortalId > 0) {
				//	getAllShiftShiftJobTemplateExpressions.Add(x => x.PortalId == model.PortalId);
				//}
			} else {
				getAllExpressions.Add(x => x.ShiftShiftTablet.ShiftShift.PortalId == CurrentUserPortalId);
			}

			if (model.Id > 0) {
				getAllExpressions.Add(x => x.Id == model.Id);
			}
			if (model.ShifTabletId > 0) {
				getAllExpressions.Add(x => x.ShiftTabletId == model.ShifTabletId);
			}
			if (model.RoleTypeId > 0) {
				getAllExpressions.Add(x => x.RoleTypeId == model.RoleTypeId);
			}
			if (model.IsDeleted != null) {
				getAllExpressions.Add(x => x.IsDeleted == model.IsDeleted);
			}

			var res = await _shiftShiftTabletReportStore.GetAllWithPagingAsync(getAllExpressions,
				x => new ShiftTabletReportViewModel {
					Id = x.Id,
					ShiftTabletId = x.ShiftTabletId,
					RoleTypeId = x.RoleTypeId,
					ReportDescription = x.ReportDescription
					
				},
				model.OrderKey, model.Desc, model.PageSize, model.PageNo);

			return res;
		}
		public async Task<BaseResult> CreateOrUpdate(ShiftTabletReportInputModel model) {

			try {

				var foundShiftTablet = await _shiftShiftTabletStore.FindByIdAsync(x => x.Id == model.ShiftTabletId && x.IsDeleted == false);
				if (null == foundShiftTablet) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه لوح شیفت یافت نشد";

					return BaseResult;
				}

				if (CurrentUserPortalId > 1 && CurrentUserPortalId != foundShiftTablet.ShiftShift.PortalId) {
					BaseResult.Success = false;
					BaseResult.Message = "شما به این قسمت دسترسی ندارید";
					return BaseResult;
				}

				var shiftShiftTabletReport = await _shiftShiftTabletReportStore.FindByIdAsync(x => x.IsDeleted == false && x.RoleTypeId == model.RoleTypeId && x.ShiftTabletId == model.ShiftTabletId);

				var res = -1;

				if (null != shiftShiftTabletReport) {
					shiftShiftTabletReport.ReportDescription = model.ReportDescription;
					res = await _shiftShiftTabletReportStore.UpdateAsync(shiftShiftTabletReport);
				} else {
					shiftShiftTabletReport = new ShiftShiftTabletReport {
						RoleTypeId = model.RoleTypeId,
						ShiftTabletId = model.ShiftTabletId,
						ReportDescription = model.ReportDescription,
						IsDeleted = false
					};

					res = await _shiftShiftTabletReportStore.InsertAsync(shiftShiftTabletReport);
				}

				if (res < 0) {
					BaseResult = await LogError(new Exception("Failed to insert/update shiftShiftTabletReport\r\n\r\n" + JsonSerializer.Serialize(shiftShiftTabletReport, new JsonSerializerOptions() {
						ReferenceHandler = ReferenceHandler.IgnoreCycles,
						WriteIndented = true
					})));
					return BaseResult;
				}

			} catch (Exception ex) {

				BaseResult = await LogError(ex);
			}

			return BaseResult;
		}


	}
}
