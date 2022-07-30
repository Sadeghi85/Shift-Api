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

namespace Leopard.Bussiness {
	public class ShiftTabletCrewService : ServiceBase, IShiftTabletCrewService {

		readonly private IShiftShiftTabletCrewStore _shiftShiftTabletCrewStore;
		readonly private IShiftShiftTabletCrewReplacementStore _shiftShiftTabletCrewReplacementStore;
		readonly private ISamtResourceTypeStore _samtResourceTypeStore;
		readonly private ISamtAgentStore _agentStore;
		readonly private IShiftShiftTabletStore _shiftShiftTabletStore;
		readonly private IShiftLogStore _shiftLogStore;
		readonly private IShiftShiftStore _shiftShiftStore;

		private List<Expression<Func<ShiftShiftTabletCrew, bool>>> GetAllExpressions { get; set; } = new();

		public ShiftTabletCrewService(IPrincipal iPrincipal, IShiftShiftTabletCrewStore shiftShiftTabletCrewStore, IShiftShiftTabletCrewReplacementStore shiftShiftTabletCrewReplacementStore, ISamtAgentStore samtAgentStore, ISamtResourceTypeStore samtResourceTypeStore, IShiftShiftTabletStore shiftShiftTabletStore, IShiftLogStore shiftLogStore, IShiftShiftStore shiftShiftStore) : base(iPrincipal, shiftLogStore) {
			_shiftShiftTabletCrewStore = shiftShiftTabletCrewStore;
			_shiftShiftTabletCrewReplacementStore = shiftShiftTabletCrewReplacementStore;
			_agentStore = samtAgentStore;
			_samtResourceTypeStore = samtResourceTypeStore;
			_shiftShiftTabletStore = shiftShiftTabletStore;
			_shiftLogStore = shiftLogStore;
			_shiftShiftStore = shiftShiftStore;
		}

		public async Task<StoreViewModel<ShiftTabletCrewViewModel>> ShfitTabletReport(DateTime fromDate, DateTime toDate, int PortalId, int take = 10, int skip = 10) {

			GetAllExpressions.Clear();

			GetAllExpressions.Add(pp => (pp.ShiftShiftTablet.ShiftDate >= fromDate && pp.ShiftShiftTablet.ShiftDate <= toDate));


			var res = await _shiftShiftTabletCrewStore.GetAllWithPagingAsync(GetAllExpressions, pp => new ShiftTabletCrewViewModel { Id = pp.Id, ShiftTitle = pp.ShiftShiftTablet.ShiftShift.Title, FirstName = pp.SamtAgent.FirstName, LastName = pp.SamtAgent.LastName, JobTitle = pp.SamtResourceType.Title, ShiftDate = pp.ShiftShiftTablet.ShiftDate, }, "id", orderDirectionDesc: true, take, skip / take);


			return res;
		}

		public async Task<StoreViewModel<ShiftTabletCrewViewModel>> GetAll(ShiftTabletCrewSearchModel model) {
			GetAllExpressions.Clear();

			GetAllExpressions.Add(pp => pp.ShiftShiftTablet.IsDeleted == false);

			if (model.Id != 0) {
				GetAllExpressions.Add(pp => pp.Id == model.Id);
			}

			if (model.ShifTabletId != 0) {
				GetAllExpressions.Add(pp => pp.ShiftTabletId == model.ShifTabletId);
			}
			if (model.AgentId != 0) {
				GetAllExpressions.Add(pp => pp.AgentId == model.AgentId);
			}
			if (model.EntranceTime != null) {
				GetAllExpressions.Add(pp => pp.EntranceTime == model.EntranceTime);
			}
			if (model.IsReplaced != null) {
				GetAllExpressions.Add(pp => pp.IsReplaced == model.IsReplaced);
			}
			if (!string.IsNullOrWhiteSpace(model.AgentName)) {
				GetAllExpressions.Add(PP => model.AgentName.Contains(PP.SamtAgent.FirstName) || model.AgentName.Contains(PP.SamtAgent.LastName));
			}

			if (!string.IsNullOrWhiteSpace(model.ShiftTitle)) {
				GetAllExpressions.Add(pp => pp.ShiftShiftTablet.ShiftShift.Title.Contains(model.ShiftTitle));
			}

			if (model.FromDate != null) {
				GetAllExpressions.Add(pp => pp.ShiftShiftTablet.ShiftDate >= model.FromDate);
			}

			if (model.JobId != 0) {
				GetAllExpressions.Add(pp => pp.JobId == model.JobId);
			}

			if (model.ToDate != null) {
				GetAllExpressions.Add(pp => pp.ShiftShiftTablet.ShiftDate <= model.ToDate);
			}
			if (model.IsDeleted != null) {
				GetAllExpressions.Add(pp => pp.IsDeleted == model.IsDeleted);
			}

			var res = await _shiftShiftTabletCrewStore.GetAllWithPagingAsync(GetAllExpressions,
				pp => new ShiftTabletCrewViewModel {
					Id = pp.Id,
					ShiftTitle = pp.ShiftShiftTablet.ShiftShift.Title,
					FirstName = pp.SamtAgent.FirstName,
					LastName = pp.SamtAgent.LastName,
					JobTitle = pp.SamtResourceType.Title,
					ShiftDate = pp.ShiftShiftTablet.ShiftDate,
					PortalTitle = pp.ShiftShiftTablet.ShiftShift.Portal.Title,
					AgentId = pp.AgentId,
					JobId = pp.JobId,
					ShiftTabletId = pp.ShiftTabletId,
					EntranceTime = pp.EntranceTime,
					ExitTime = pp.ExitTime,
					DefaultEntranceTime = pp.ShiftShiftTablet.ShiftShift.StartTime,
					DefaultExitTime = pp.ShiftShiftTablet.ShiftShift.EndTime
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
				var foundAgent = await _agentStore.FindByIdAsync(model.AgentId);
				var foundResourceType = await _samtResourceTypeStore.FindByIdAsync(model.JobId);
				var foundShiftTablet = await _shiftShiftTabletStore.FindByIdAsync(model.ShiftTabletId);
				var foundAgentInShiftTablet = await _shiftShiftTabletCrewStore.AnyAsync(pp => pp.AgentId == model.AgentId && pp.ShiftTabletId == model.ShiftTabletId && pp.IsDeleted != true);

				if (foundShiftTablet != null && foundAgent != null && foundAgentInShiftTablet == false) {

					var shiftTabletDate = foundShiftTablet.ShiftDate;
					var lstShiftDateStartEnds = new List<ShiftDateStartEnd>();
					var shiftDateStartEnd = new ShiftDateStartEnd();

					var foundShift = await _shiftShiftStore.FindByIdAsync(foundShiftTablet.ShiftId);

					shiftDateStartEnd.StartDateTime = foundShiftTablet.ShiftDate.Add(foundShift.StartTime);
					shiftDateStartEnd.EndDateTime = foundShiftTablet.ShiftDate.Add(foundShift.EndTime);
					lstShiftDateStartEnds.Add(shiftDateStartEnd);

					var listOfAgentWorkingShifts = await _shiftShiftTabletCrewStore.GetAllAsync(pp => pp.ShiftShiftTablet.ShiftDate == shiftTabletDate && pp.AgentId == model.AgentId, pp =>
					new { pp.ShiftShiftTablet.ShiftDate, pp.ShiftShiftTablet.ShiftShift.StartTime, pp.ShiftShiftTablet.ShiftShift.EndTime }, x => x.Id);


					if (listOfAgentWorkingShifts.TotalCount != 0) {


						foreach (var i in listOfAgentWorkingShifts.Result) {
							var sdse = new ShiftDateStartEnd();
							sdse.StartDateTime = i.ShiftDate.Add(i.StartTime);
							sdse.EndDateTime = i.ShiftDate.Add(i.EndTime);
							lstShiftDateStartEnds.Add(sdse);
						}

						if (lstShiftDateStartEnds.Count > 1) {

							lstShiftDateStartEnds = lstShiftDateStartEnds.OrderBy(pp => pp.StartDateTime).ToList();

							for (var i = 0; i < lstShiftDateStartEnds.Count - 1; i++) {
								if (HasOverLap(lstShiftDateStartEnds[i], lstShiftDateStartEnds[i + 1])) {
									overLapMessage.Add("کاربر در یک شیفت هم زمان دیگر ثبت شده است.");
								}
							}

						}


					}
				}

				if (foundAgent == null) {
					BaseResult.Success = false;
					BaseResult.Message = "کارمندی با این مشخصات یافت نشد";
					return BaseResult;
				} else if (foundResourceType == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه سمت مورد نظر یافت نشد.";
					return BaseResult;
				} else if (foundShiftTablet == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه لوح مورد نظر یافت نشد.";
					return BaseResult;
				} else if (foundAgentInShiftTablet) {
					BaseResult.Success = false;
					BaseResult.Message = "کارمند مورد نظر در این لوح شیفت قبلا ثبت نام شده است.";
					return BaseResult;
				} else if (overLapMessage.Count > 0) {
					BaseResult.Success = false;
					BaseResult.Message = String.Join(",", overLapMessage);
					return BaseResult;
				} else if (model.EntranceTime > model.ExitTime) {

					BaseResult.Success = false;
					BaseResult.Message = "زمان خروج باید بزرگتر از زمان ورود کارمند باشد.";
					return BaseResult;
				} else {
					ShiftShiftTabletCrew shiftShiftTabletCrew = new ShiftShiftTabletCrew {
						AgentId = model.AgentId,

						//EntranceTime = model.EntranceTime,
						//ExitTime = model.ExitTime,

						IsReplaced = false,
						JobId = model.JobId,
						ShiftTabletId = model.ShiftTabletId
					};

					var res = await _shiftShiftTabletCrewStore.InsertAsync(shiftShiftTabletCrew);
				}
			} catch (Exception ex) {

				BaseResult.Success = false;
				var shiftLog = new ShiftLog { Message = ex.Message + " " + ex.InnerException?.Message ?? ex.Message };
				//_shiftLogStore.ResetContext();
				var ss = await _shiftLogStore.InsertAsync(shiftLog);
				BaseResult.Message = $"خطای سیستمی شماره {shiftLog.Id} لطفا به مدیر سیستم اطلاع دهید.";
			}


			return BaseResult;
		}

		public async Task<int> Replace(int replaced, int replacedBy) {

			var found = await _shiftShiftTabletCrewStore.FindByIdAsync(replaced);
			if (found != null) {
				found.IsReplaced = true;
				await _shiftShiftTabletCrewStore.UpdateAsync(found);
			}
			var res = await _shiftShiftTabletCrewReplacementStore.InsertAsync(new ShiftShiftTabletCrewReplacement {
				ShiftTabletCrewId = replaced,
				ShiftTabletCrewIdReplaceMent = replacedBy
			});

			return res;

		}


		public async Task<BaseResult> Update(ShiftTabletCrewInputModel model) {

			try {
				var found = await _shiftShiftTabletCrewStore.FindByIdAsync(model.Id);
				if (found == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه مورد نظر شناسایی نشد.";
					return BaseResult;
				} else {
					found.ShiftTabletId = model.ShiftTabletId;
					found.EntranceTime = model.EntranceTime;
					found.ExitTime = model.ExitTime;
					found.JobId = model.JobId;
					found.AgentId = model.AgentId;

					var res = await _shiftShiftTabletCrewStore.UpdateAsync(found);
				}
			} catch (Exception ex) {

				BaseResult.Success = false;

				ShiftLog shiftLog = new ShiftLog { Message = ex.Message + " " + ex.InnerException?.Message ?? ex.Message };

				//_shiftLogStore.ResetContext();

				var ss = await _shiftLogStore.InsertAsync(shiftLog);

				BaseResult.Message = $"خطای سیستمی شماره {shiftLog.Id} لطفا به مدیر سیستم اطلاع دهید.";
			}

			return BaseResult;


		}

		public async Task<BaseResult> Delete(ShiftTabletCrewInputModel model) {
			try {
				var found = await _shiftShiftTabletCrewStore.FindByIdAsync(model.Id);
				if (found == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه مورد نظر شناسایی نشد.";
					return BaseResult;
				} else {
					found.IsDeleted = true;
					var res = await _shiftShiftTabletCrewStore.UpdateAsync(found);
				}
			} catch (Exception ex) {

				BaseResult.Success = false;

				ShiftLog shiftLog = new ShiftLog { Message = ex.Message + " " + ex.InnerException?.Message ?? ex.Message };

				//_shiftLogStore.ResetContext();

				var ss = await _shiftLogStore.InsertAsync(shiftLog);

				BaseResult.Message = $"خطای سیستمی شماره {shiftLog.Id} لطفا به مدیر سیستم اطلاع دهید.";
			}

			return BaseResult;

		}

	}
}
