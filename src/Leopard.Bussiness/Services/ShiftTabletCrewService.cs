using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core.Exceptions;
using System.Linq.Dynamic.Core;
using System.Security.Principal;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Leopard.Bussiness {
	public class ShiftTabletCrewService : ServiceBase, IShiftTabletCrewService {

		private readonly IShiftShiftTabletCrewStore _shiftShiftTabletCrewStore;
		private readonly IShiftShiftTabletCrewReplacementStore _shiftShiftTabletCrewReplacementStore;
		private readonly ISamtResourceTypeStore _samtResourceTypeStore;
		private readonly ISamtAgentStore _agentStore;
		private readonly IShiftShiftTabletStore _shiftShiftTabletStore;
		private readonly IShiftShiftStore _shiftShiftStore;

		public ShiftTabletCrewService(IPrincipal iPrincipal, IShiftShiftTabletCrewStore shiftShiftTabletCrewStore, IShiftShiftTabletCrewReplacementStore shiftShiftTabletCrewReplacementStore, ISamtAgentStore samtAgentStore, ISamtResourceTypeStore samtResourceTypeStore, IShiftShiftTabletStore shiftShiftTabletStore, IShiftLogStore shiftLogStore, IShiftShiftStore shiftShiftStore) : base(iPrincipal, shiftLogStore) {
			_shiftShiftTabletCrewStore = shiftShiftTabletCrewStore;
			_shiftShiftTabletCrewReplacementStore = shiftShiftTabletCrewReplacementStore;
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
			if (model.ShifTabletId > 0) {
				getAllExpressions.Add(x => x.ShiftTabletId == model.ShifTabletId);
			}
			if (model.AgentId > 0) {
				getAllExpressions.Add(x => x.AgentId == model.AgentId);
			}
			if (model.JobId > 0) {
				getAllExpressions.Add(x => x.JobId == model.JobId);
			}
			if (model.EntranceTime != null) {
				getAllExpressions.Add(x => x.EntranceTime == model.EntranceTime);
			}
			if (model.ExitTime != null) {
				getAllExpressions.Add(x => x.ExitTime == model.ExitTime);
			}
			if (model.IsReplaced != null) {
				getAllExpressions.Add(x => x.IsReplaced == model.IsReplaced);
			}
			if (!string.IsNullOrWhiteSpace(model.AgentName)) {
				getAllExpressions.Add(x => model.AgentName.Contains(x.SamtAgent.FirstName) || model.AgentName.Contains(x.SamtAgent.LastName));
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

					EntranceTime = x.EntranceTime,
					ExitTime = x.ExitTime,
					DefaultEntranceTime = x.ShiftShiftTablet.ShiftShift.StartTime,
					DefaultExitTime = x.ShiftShiftTablet.ShiftShift.EndTime
				},
				model.OrderKey, model.Desc, model.PageSize, model.PageNo);


			return res;
		}

		//public List<ShiftShiftTabletCrew> GetByShiftId(int shifTabletId) {

		//	List<ShiftShiftTabletCrew>? res = _shiftShiftTabletCrewStore.GetAll().Where(pp => pp.ShiftTabletId == shifTabletId).ToList();

		//	return res;

		//}

		private bool HasOverLap(ShiftDateStartEnd a, ShiftDateStartEnd b) {

			bool overlap = a.StartDateTime < b.EndDateTime && b.StartDateTime < a.EndDateTime;
			return overlap;
		}

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


				found.JobId = model.JobId;
				found.AgentId = model.AgentId;
				found.ShiftTabletId = model.ShiftTabletId;
				found.EntranceTime = model.EntranceTime;
				found.ExitTime = model.ExitTime;

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

		public async Task<BaseResult> Delete(int id) {
			try {

				var found = await _shiftShiftTabletCrewStore.FindByIdAsync(id);

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

	}
}
