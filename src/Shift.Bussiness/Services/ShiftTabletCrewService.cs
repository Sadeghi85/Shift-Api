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
	public class ShiftTabletCrewService : ServiceBase, IShiftTabletCrewService {

		private readonly IShiftShiftTabletCrewStore _shiftShiftTabletCrewStore;
		private readonly IShiftShiftTabletCrewReplacementStore _shiftShiftTabletCrewReplacementStore;
		private readonly IShiftShiftTabletCrewAttendanceStore _shiftShiftTabletCrewAttendanceStore;
		private readonly ISamtResourceTypeStore _samtResourceTypeStore;
		private readonly ISamtAgentStore _agentStore;
		private readonly IShiftShiftTabletStore _shiftShiftTabletStore;
		private readonly IShiftShiftStore _shiftShiftStore;

		public ShiftTabletCrewService(IPrincipal iPrincipal, IShiftShiftTabletCrewStore shiftShiftTabletCrewStore, IShiftShiftTabletCrewReplacementStore shiftShiftTabletCrewReplacementStore, ISamtAgentStore samtAgentStore, ISamtResourceTypeStore samtResourceTypeStore, IShiftShiftTabletStore shiftShiftTabletStore, IShiftLogStore shiftLogStore, IShiftShiftStore shiftShiftStore, IShiftShiftTabletCrewAttendanceStore shiftShiftTabletCrewAttendanceStore) : base(iPrincipal, shiftLogStore) {
			_shiftShiftTabletCrewStore = shiftShiftTabletCrewStore;
			_shiftShiftTabletCrewReplacementStore = shiftShiftTabletCrewReplacementStore;
			_shiftShiftTabletCrewAttendanceStore = shiftShiftTabletCrewAttendanceStore;
			_agentStore = samtAgentStore;
			_samtResourceTypeStore = samtResourceTypeStore;
			_shiftShiftTabletStore = shiftShiftTabletStore;
			_shiftShiftStore = shiftShiftStore;
		}

		//public async Task<StoreViewModel<ShiftTabletCrewViewModel>> ShfitTabletReport(DateTime fromDate, DateTime toDate, int PortalId, int take = 10, int skip = 10) {

		//	GetAllExpressions.Clear();

		//	GetAllExpressions.Add(pp => (pp.ShiftShiftTablet.ShiftDate >= fromDate && pp.ShiftShiftTablet.ShiftDate <= toDate));


		//	var res = await _shiftShiftTabletCrewStore.GetAllWithPagingAsync(GetAllExpressions, pp => new ShiftTabletCrewViewModel { Id = pp.Id, ShiftTitle = pp.ShiftShiftTablet.ShiftShift.Title, FirstName = pp.SamtAgent.FirstName, LastName = pp.SamtAgent.LastName, JobTitle = pp.SamtResourceType.Title, ShiftDate = pp.ShiftShiftTablet.ShiftDate, }, "id", orderDirectionDesc: true, take, skip / take);


		//	return res;
		//}

		public async Task<StoreViewModel<ShiftTabletCrewViewModel>> GetAll(ShiftTabletCrewSearchModel model) {

			var getAllExpressions = new List<Expression<Func<ShiftShiftTabletCrew, bool>>>();

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
			if (model.ShiftTabletId > 0) {
				getAllExpressions.Add(x => x.ShiftTabletId == model.ShiftTabletId);
			}
			if (model.AgentId > 0) {
				getAllExpressions.Add(x => x.AgentId == model.AgentId);
			}
			if (model.JobId > 0) {
				getAllExpressions.Add(x => x.JobId == model.JobId);
			}
			if (model.IsReplaced != null) {
				getAllExpressions.Add(x => x.IsReplaced == model.IsReplaced);
			}
			if (!string.IsNullOrWhiteSpace(model.AgentName)) {
				getAllExpressions.Add(x => (x.SamtAgent.FirstName + " " + x.SamtAgent.LastName).Contains(model.AgentName));
			}
			if (!string.IsNullOrWhiteSpace(model.ShiftTitle)) {
				getAllExpressions.Add(x => x.ShiftShiftTablet.ShiftShift.Title.Contains(model.ShiftTitle));
			}
			if (model.FromDate != null) {
				getAllExpressions.Add(x => x.ShiftShiftTablet.ShiftDate >= model.FromDate);
			}
			if (model.ToDate != null) {
				getAllExpressions.Add(x => x.ShiftShiftTablet.ShiftDate <= model.ToDate);
			}
			if (model.IsDeleted != null) {
				getAllExpressions.Add(x => x.IsDeleted == model.IsDeleted);
			}

			var res = await _shiftShiftTabletCrewStore.GetAllWithPagingAsync(getAllExpressions,
				x => new ShiftTabletCrewViewModel {
					Id = x.Id,
					AgentId = x.AgentId,
					JobId = x.JobId,
					ShiftTabletId = x.ShiftTabletId,
					ShiftTitle = x.ShiftShiftTablet.ShiftShift.Title,
					FirstName = x.SamtAgent.FirstName,
					LastName = x.SamtAgent.LastName,
					JobTitle = x.SamtResourceType.Title,
					ShiftDate = x.ShiftShiftTablet.ShiftDate,
					PortalTitle = x.ShiftShiftTablet.ShiftShift.Portal.Title,

					EntranceTime = x.ShiftShiftTabletCrewAttendances.FirstOrDefault(y => y.RoleTypeId == model.RoleTypeId) != null ? x.ShiftShiftTabletCrewAttendances.First(y => y.RoleTypeId == model.RoleTypeId).EntranceTime : null,
					ExitTime = x.ShiftShiftTabletCrewAttendances.FirstOrDefault(y => y.RoleTypeId == model.RoleTypeId) != null ? x.ShiftShiftTabletCrewAttendances.First(y => y.RoleTypeId == model.RoleTypeId).ExitTime : null,

					DefaultEntranceTime = x.ShiftShiftTablet.ShiftShift.StartTime,
					DefaultExitTime = x.ShiftShiftTablet.ShiftShift.EndTime
				},
				model.OrderKey, model.Desc, model.PageSize, model.PageNo);


			return res;
		}

		//public List<ShiftShiftTabletCrew> GetByShiftId(int ShiftTabletId) {

		//	List<ShiftShiftTabletCrew>? res = _shiftShiftTabletCrewStore.GetAll().Where(pp => pp.ShiftTabletId == ShiftTabletId).ToList();

		//	return res;

		//}

		//private bool HasOverLap(ShiftDateStartEnd a, ShiftDateStartEnd b) {

		//	bool overlap = a.StartDateTime < b.EndDateTime && b.StartDateTime < a.EndDateTime;
		//	return overlap;
		//}

		public async Task<BaseResult> Register(ShiftTabletCrewInputModel model) {

			List<string> overLapMessage = new List<string>();

			try {

				var foundAgent = await _agentStore.FindByIdAsync(x => x.Id == model.AgentId && x.IsDeleted == false);
				if (null == foundAgent) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه کارمند یافت نشد";

					return BaseResult;
				}

				var foundJob = await _samtResourceTypeStore.FindByIdAsync(x => x.Id == model.JobId && x.IsDeleted == false);
				if (null == foundJob) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه عنوان شغلی یافت نشد";

					return BaseResult;
				}

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

				var isFound = await _shiftShiftTabletCrewStore.AnyAsync(x => x.IsDeleted == false && x.AgentId == model.AgentId && x.ShiftTabletId == model.ShiftTabletId);

				if (isFound) {
					BaseResult.Success = false;
					BaseResult.Message = "این آیتم قبلا ثبت شده است";
					return BaseResult;
				}

				///
				// TODO: sp: check that agent is not already in another shift that overlaps this shift
				///

				//isFound = await _shiftShiftTabletCrewStore.AnyAsync(x => x.IsDeleted == false && x.AgentId == model.AgentId && (foundShiftTablet.ShiftShift.StartTime > x.ShiftShiftTablet.ShiftShift.StartTime));

				//var shiftTabletDate = foundShiftTablet.ShiftDate;
				//	var lstShiftDateStartEnds = new List<ShiftDateStartEnd>();
				//	var shiftDateStartEnd = new ShiftDateStartEnd();

				//	var foundShift = await _shiftShiftStore.FindByIdAsync(foundShiftTablet.ShiftId);

				//	shiftDateStartEnd.StartDateTime = foundShiftTablet.ShiftDate.Add(foundShift.StartTime);
				//	shiftDateStartEnd.EndDateTime = foundShiftTablet.ShiftDate.Add(foundShift.EndTime);
				//	lstShiftDateStartEnds.Add(shiftDateStartEnd);

				//	var listOfAgentWorkingShifts = await _shiftShiftTabletCrewStore.GetAllAsync(pp => pp.ShiftShiftTablet.ShiftDate == shiftTabletDate && pp.AgentId == model.AgentId, pp =>
				//	new { pp.ShiftShiftTablet.ShiftDate, pp.ShiftShiftTablet.ShiftShift.StartTime, pp.ShiftShiftTablet.ShiftShift.EndTime }, x => x.Id);


				//	if (listOfAgentWorkingShifts.TotalCount != 0) {

				//		foreach (var i in listOfAgentWorkingShifts.Result) {
				//			var sdse = new ShiftDateStartEnd();
				//			sdse.StartDateTime = i.ShiftDate.Add(i.StartTime);
				//			sdse.EndDateTime = i.ShiftDate.Add(i.EndTime);
				//			lstShiftDateStartEnds.Add(sdse);
				//		}

				//		if (lstShiftDateStartEnds.Count > 1) {

				//			lstShiftDateStartEnds = lstShiftDateStartEnds.OrderBy(pp => pp.StartDateTime).ToList();

				//			for (var i = 0; i < lstShiftDateStartEnds.Count - 1; i++) {
				//				if (HasOverLap(lstShiftDateStartEnds[i], lstShiftDateStartEnds[i + 1])) {
				//					overLapMessage.Add("کاربر در یک شیفت هم زمان دیگر ثبت شده است.");
				//				}
				//			}

				//		}


				//	}


				//else if (overLapMessage.Count > 0) {
				//		BaseResult.Success = false;
				//		BaseResult.Message = String.Join(",", overLapMessage);
				//		return BaseResult;
				//	} else 



				var shiftShiftTabletCrew = new ShiftShiftTabletCrew {
					AgentId = model.AgentId,
					JobId = model.JobId,
					ShiftTabletId = model.ShiftTabletId,

					IsReplaced = false,
					IsDeleted = false

				};

				var res = await _shiftShiftTabletCrewStore.InsertAsync(shiftShiftTabletCrew);

				if (res < 0) {
					BaseResult = await LogError(new Exception("Failed to insert shiftShiftTabletCrew\r\n\r\n" + JsonSerializer.Serialize(shiftShiftTabletCrew, new JsonSerializerOptions() {
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

		//public async Task<int> Replace(int replaced, int replacedBy) {

		//	var found = await _shiftShiftTabletCrewStore.FindByIdAsync(replaced);
		//	if (found != null) {
		//		found.IsReplaced = true;
		//		await _shiftShiftTabletCrewStore.UpdateAsync(found);
		//	}
		//	var res = await _shiftShiftTabletCrewReplacementStore.InsertAsync(new ShiftShiftTabletCrewReplacement {
		//		ShiftTabletCrewId = replaced,
		//		ShiftTabletCrewIdReplaceMent = replacedBy
		//	});

		//	return res;

		//}


		public async Task<BaseResult> Update(ShiftTabletCrewInputModel model) {
			try {

				var found = await _shiftShiftTabletCrewStore.FindByIdAsync(x => x.Id == model.Id && x.IsDeleted == false);
				var today = DateTime.Now.Date;

				if (found == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه مورد نظر یافت نشد";
					return BaseResult;
				}
				if (CurrentUserPortalId > 1 && CurrentUserPortalId != found.ShiftShiftTablet.ShiftShift.PortalId) {
					BaseResult.Success = false;
					BaseResult.Message = "شما به این قسمت دسترسی ندارید";
					return BaseResult;
				}

				if ((RoleType) model.RoleTypeId == RoleType.Coordinator && today >= found.ShiftShiftTablet.ShiftDate) {
					BaseResult.Success = false;
					BaseResult.Message = "ویرایش تا قبل از روز شیفت مجاز است";
					return BaseResult;
				}

				var foundAgent = await _agentStore.FindByIdAsync(x => x.Id == model.AgentId && x.IsDeleted == false);
				if (null == foundAgent) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه کارمند یافت نشد";

					return BaseResult;
				}

				var foundJob = await _samtResourceTypeStore.FindByIdAsync(x => x.Id == model.JobId && x.IsDeleted == false);
				if (null == foundJob) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه عنوان شغلی یافت نشد";

					return BaseResult;
				}

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

				var isFound = await _shiftShiftTabletCrewStore.AnyAsync(x => x.Id != model.Id && x.IsDeleted == false && x.AgentId == model.AgentId && x.ShiftTabletId == model.ShiftTabletId);

				if (isFound) {
					BaseResult.Success = false;
					BaseResult.Message = "این آیتم قبلا ثبت شده است";
					return BaseResult;
				}

				var foundShift = await _shiftShiftStore.FindByIdAsync(x => x.Id == foundShiftTablet.ShiftId && x.IsDeleted == false);
				if (null == foundShift) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه شیفت یافت نشد";

					return BaseResult;
				}

				if (model.ExitTime != null && model.EntranceTime != null) {
					TimeSpan diff;
					switch (TimeSpan.Compare((TimeSpan) model.ExitTime, (TimeSpan) model.EntranceTime)) {
						case -1:
							diff = (((TimeSpan) model.ExitTime).Add(TimeSpan.FromDays(1))) - (TimeSpan) model.EntranceTime;
							break;
						case 0:
							diff = TimeSpan.Zero;
							break;
						case 1:
							diff = ((TimeSpan) model.ExitTime) - ((TimeSpan) model.EntranceTime);
							break;
						default:
							diff = TimeSpan.Zero;
							break;
					}
					if (diff == TimeSpan.Zero) {
						BaseResult.Success = false;
						BaseResult.Message = "ساعت ورود و خروج را بدرستی وارد نمایید";
						return BaseResult;
					}
					if (TimeSpan.Compare(foundShift.EndTime, foundShift.StartTime) != TimeSpan.Compare((TimeSpan) model.ExitTime, (TimeSpan) model.EntranceTime)) {
						BaseResult.Success = false;
						BaseResult.Message = "ساعت ورود و خروج را بدرستی وارد نمایید";
						return BaseResult;
					}
				}

				///
				// TODO: sp: check that agent is not already in another shift that overlaps this shift
				///

				// جابجایی (هماهنگی و منشی صحنه)؛
				if (found.AgentId != model.AgentId) {
					var shiftCrewReplacement = new ShiftShiftTabletCrewReplacement() {
						ShiftTabletCrewId = found.Id,
						OldAgentId = found.AgentId,
						NewAgentId = model.AgentId,
						RoleTypeId = model.RoleTypeId,
					};

					var res1 = await _shiftShiftTabletCrewReplacementStore.InsertAsync(shiftCrewReplacement);

					if (res1 < 0) {
						BaseResult = await LogError(new Exception("Failed to insert shiftShiftTabletCrewReplacement\r\n\r\n" + JsonSerializer.Serialize(found, new JsonSerializerOptions() {
							ReferenceHandler = ReferenceHandler.IgnoreCycles,
							WriteIndented = true
						})));
						return BaseResult;
					}

					found.IsReplaced = true;
				}

				// حضور و غیاب (ناظر پخش و منشی صحنه)؛
				if (model.EntranceTime != null && model.ExitTime != null) {
					var shiftCrewAttendance = await _shiftShiftTabletCrewAttendanceStore.FindByIdAsync(x => x.ShiftTabletCrewId == found.Id && x.RoleTypeId == model.RoleTypeId);

					if (null != shiftCrewAttendance) {
						shiftCrewAttendance.EntranceTime = (TimeSpan) model.EntranceTime;
						shiftCrewAttendance.ExitTime = (TimeSpan) model.ExitTime;

						var res1 = await _shiftShiftTabletCrewAttendanceStore.UpdateAsync(shiftCrewAttendance);

						if (res1 < 0) {
							BaseResult = await LogError(new Exception("Failed to update shiftShiftTabletCrewAttendance\r\n\r\n" + JsonSerializer.Serialize(found, new JsonSerializerOptions() {
								ReferenceHandler = ReferenceHandler.IgnoreCycles,
								WriteIndented = true
							})));
							return BaseResult;
						}
					} else {
						shiftCrewAttendance = new ShiftShiftTabletCrewAttendance() {
							ShiftTabletCrewId = found.Id,
							RoleTypeId = model.RoleTypeId,
							EntranceTime = (TimeSpan) model.EntranceTime,
							ExitTime = (TimeSpan) model.ExitTime
						};

						var res1 = await _shiftShiftTabletCrewAttendanceStore.InsertAsync(shiftCrewAttendance);

						if (res1 < 0) {
							BaseResult = await LogError(new Exception("Failed to insert shiftShiftTabletCrewAttendance\r\n\r\n" + JsonSerializer.Serialize(found, new JsonSerializerOptions() {
								ReferenceHandler = ReferenceHandler.IgnoreCycles,
								WriteIndented = true
							})));
							return BaseResult;
						}
					}
					
				}

				found.JobId = model.JobId;
				found.AgentId = model.AgentId;
				found.ShiftTabletId = model.ShiftTabletId;

				var res = await _shiftShiftTabletCrewStore.UpdateAsync(found);

				if (res < 0) {
					BaseResult = await LogError(new Exception("Failed to update shiftShiftTabletCrew\r\n\r\n" + JsonSerializer.Serialize(found, new JsonSerializerOptions() {
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

		// Crew(Coordinator) update is different, in that, current row is logically deleted and new row will be inserted
		public async Task<BaseResult> CoordinatorUpdate(ShiftTabletCrewInputModel model) {
			try {

				model.RoleTypeId = (int) RoleType.Coordinator;

				var found = await _shiftShiftTabletCrewStore.FindByIdAsync(model.Id);
				var today = DateTime.Now.Date;

				if (found == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه مورد نظر یافت نشد";
					return BaseResult;
				}

				if ((RoleType) model.RoleTypeId == RoleType.Coordinator && today >= found.ShiftShiftTablet.ShiftDate) {
					BaseResult.Success = false;
					BaseResult.Message = "ویرایش تا قبل از روز شیفت مجاز است";
					return BaseResult;
				}

				var res = await Delete(model.Id);

				if (!res.Success) {
					return res;
				}

				res = await Register(model);

				if (!res.Success) {
					return res;
				}

			} catch (Exception ex) {

				BaseResult = await LogError(ex);
			}

			return BaseResult;
		}

		public async Task<BaseResult> Delete(int id) {
			try {

				var found = await _shiftShiftTabletCrewStore.FindByIdAsync(id);
				var today = DateTime.Now.Date;

				if (found == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه مورد نظر یافت نشد";
					return BaseResult;
				}

				if (CurrentUserPortalId > 1 && CurrentUserPortalId != found.ShiftShiftTablet.ShiftShift.PortalId) {
					BaseResult.Success = false;
					BaseResult.Message = "شما به این قسمت دسترسی ندارید";
					return BaseResult;
				}

				if (today >= found.ShiftShiftTablet.ShiftDate) {
					BaseResult.Success = false;
					BaseResult.Message = "حذف تا قبل از روز شیفت مجاز است";
					return BaseResult;
				}

				found.IsDeleted = true;

				var res = await _shiftShiftTabletCrewStore.UpdateAsync(found);

				if (res < 0) {
					BaseResult = await LogError(new Exception("Failed to delete shiftShiftTabletCrew\r\n\r\n" + JsonSerializer.Serialize(found, new JsonSerializerOptions() {
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

		public async Task<MemoryStream> GetExcelReport(ShiftTabletCrewSearchModel model) {

			var stream = new MemoryStream();

			try {

				var res = await GetAll(model);

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
									var ss = ExcelCellAddress.GetColumnLetter(query3.Start.Column);
									ws.Cells[ss + tmpshifCount].Value = k.Name;

								} else {
									var qw = ws.Cells["1:1"].Where(pp => pp.Value != null).LastOrDefault();
									var newcol = qw.Start.Column + 1;
									var ss = ExcelCellAddress.GetColumnLetter(newcol);
									ws.Cells[ss + 1].Value = resourceTmp;
									ws.Cells[ss + tmpshifCount].Value = k.Name;
								}
							}
							tmpshifCount++;
						}

						row += shiftCount;
					}
					ws.View.RightToLeft = true;
					package.SaveAs(stream);
					stream.Position = 0;
				}

			} catch (Exception ex) {
				BaseResult = await LogError(ex);
			}

			return stream;
		}

		public async Task<MemoryStream> GetPdfReport(ShiftTabletCrewSearchModel model) {

			var stream = new MemoryStream();
			var pdfStream = new MemoryStream();
			var pdfResStream = new MemoryStream();

			var pdfResStreamOutput = new MemoryStream();

			try {

				var res = await GetAll(model);


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
					PdfHelper ReportActions = new PdfHelper();

					pdfRes = ReportActions.CreateExcelToPdfReport(package, "", "Contracts Report", "", new MemoryStream());

					pdfResStreamOutput = (MemoryStream) pdfRes.PdfStreamOutput;
				}




			} catch (Exception ex) {
				BaseResult = await LogError(ex);
			}

			return pdfResStreamOutput;
		}
	}
}
