using Leopard.Bussiness.Model;
using Leopard.Bussiness.Model.ReturnModel;
using Leopard.Bussiness.Services.Interface;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core.Exceptions;
using System.Linq.Dynamic.Core;


namespace Leopard.Bussiness.Services {
	public class ShiftTabletCrewService : BaseService, IShiftTabletCrewService {

		readonly private IShiftShiftTabletCrewStore _shiftShiftTabletCrewStore;
		readonly private IShiftShiftTabletCrewReplacementStore _shiftShiftTabletCrewReplacementStore;
		readonly private ISamtResourceTypeStore _samtResourceTypeStore;
		readonly private ISamtAgentStore _agentStore;
		readonly private IShiftShiftTabletStore _shiftShiftTabletStore;
		readonly private IShiftLogStore _shiftLogStore;
		private List<Expression<Func<ShiftShiftTabletCrew, bool>>> GetAllExpressions { get; set; } = new List<Expression<Func<ShiftShiftTabletCrew, bool>>>();

		public ShiftTabletCrewService(IShiftShiftTabletCrewStore shiftShiftTabletCrewStore, IShiftShiftTabletCrewReplacementStore shiftShiftTabletCrewReplacementStore, ISamtAgentStore samtAgentStore, ISamtResourceTypeStore samtResourceTypeStore, IShiftShiftTabletStore shiftShiftTabletStore, IShiftLogStore shiftLogStore) {
			_shiftShiftTabletCrewStore = shiftShiftTabletCrewStore;
			_shiftShiftTabletCrewReplacementStore = shiftShiftTabletCrewReplacementStore;
			_agentStore = samtAgentStore;
			_samtResourceTypeStore = samtResourceTypeStore;
			_shiftShiftTabletStore = shiftShiftTabletStore;
			_shiftLogStore = shiftLogStore;
			
		}

		public async Task<BaseResult> Delete(int id) {


			try {
				var found = _shiftShiftTabletCrewStore.FindById(id);
				if (found == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه مورد نظر شناسایی نشد.";
				} else {
					found.IsDeleted = true;
					var res = await _shiftShiftTabletCrewStore.Update(found);
				}
			} catch (Exception ex) {

				BaseResult.Success = false;

				ShiftLog shiftLog = new ShiftLog { Message = ex.Message + " " + ex.InnerException?.Message ?? ex.Message };

				//_shiftLogStore.ResetContext();

				var ss = await _shiftLogStore.InsertAsync(shiftLog);

				BaseResult.Message = $"خطای سیستمی شماره {shiftLog.Id} لطفای به مدیر سیستم اطلاع دهید.";
			}

			return BaseResult;

		}

		public List<ShfitTabletReportResult> ShfitTabletReport(DateTime fromDate, DateTime toDate, int PortalId, int take = 10, int skip = 10) {
			var res = _shiftShiftTabletCrewStore.GetAll().Where(pp => (pp.ShiftShiftTablet.ShiftDate >= fromDate && pp.ShiftShiftTablet.ShiftDate <= toDate)).Skip(skip).Take(take).Select(pp => new ShfitTabletReportResult { id = pp.Id, shiftTitle = pp.ShiftShiftTablet.ShiftShift.Title, firstName = pp.SamtAgent.FirstName, lastName = pp.SamtAgent.LastName, jobName = pp.SamtResourceType.Title, shiftDate = pp.ShiftShiftTablet.ShiftDate.Value, }).ToList();
			//var list = new List<int>() { 1, 2, 3, 4, 5 };

			//list.OrderBy()
			//var list2 = list.Where(x => "x > 2");
			//var list3 = list.Where(x => "x > X", new { X = 2 }); // with parameter


			return res;
		}

		public Task<List<ShfitTabletReportResult>>? GetAll(ShiftTabletCrewSearchModel model) {


			if(model.ShifTabletId==0 && model.AgentId==0 && model.EntranceTime==null && model.ExitTime == null && model.IsReplaced==null && string.IsNullOrWhiteSpace(model.AgentName) && string.IsNullOrWhiteSpace(model.ShiftTitle) && model.FromDate==null && model.ToDate == null) {
				GetAllExpressions.Add(pp => true);

			} else {
				if (model.ShifTabletId != 0) {
					GetAllExpressions.Add(pp => pp.ShiftTabletId == model.ShifTabletId);
				}
				if (model.AgentId!=0) {
					GetAllExpressions.Add(pp => pp.AgentId == model.AgentId);
				}
				if (model.EntranceTime!=null) {
					GetAllExpressions.Add(pp=> pp.EntranceTime==model.EntranceTime);
				}
				if (model.IsReplaced != null) {
					GetAllExpressions.Add(pp => pp.IsReplaced == model.IsReplaced);
				}
				if(!string.IsNullOrWhiteSpace( model.AgentName))
				{	
					GetAllExpressions.Add(PP =>  model.AgentName.Contains(PP.SamtAgent.FirstName) || model.AgentName.Contains(PP.SamtAgent.LastName));

				}
				if (string.IsNullOrWhiteSpace(model.ShiftTitle)) {
					GetAllExpressions.Add(pp => pp.ShiftShiftTablet.ShiftShift.Title.Contains(model.ShiftTitle));
				}

				if(model.FromDate!=null && model.ToDate != null) {
					GetAllExpressions.Add(pp => pp.ShiftShiftTablet.ShiftDate >= model.FromDate && pp.ShiftShiftTablet.ShiftDate <= model.ToDate);
				}

			}

			//Task<List<ShiftTabletCrewSearchResult>>? res = _shiftShiftTabletCrewStore.GetAllWithPagingAsync(GetAllExpressions, pp => new ShiftTabletCrewSearchResult {ShifTabletId=pp.ShifTabletId , EntranceTime= pp.EntranceTime , ExitTime= pp.ExitTime , FisrtName= pp.SamtAgent.FirstName, LastName=pp.SamtAgent.LastName, AgentId=pp.AgentId, ShiftTitle= pp.ShiftShiftTablet.ShiftShift.Title , ResourceTitle= pp.SamtResourceType.Title} , pp => pp.Id, model.PageSize, model.PageNo, "desc");

			Task<List<ShfitTabletReportResult>>? res = _shiftShiftTabletCrewStore.GetAllWithPagingAsync(GetAllExpressions, pp => new ShfitTabletReportResult  { id = pp.Id, shiftTitle = pp.ShiftShiftTablet.ShiftShift.Title, firstName = pp.SamtAgent.FirstName, lastName = pp.SamtAgent.LastName, jobName = pp.SamtResourceType.Title, shiftDate = pp.ShiftShiftTablet.ShiftDate.Value, PortalName= pp.ShiftShiftTablet.ShiftShift.Portal.Title , EntranceTime= pp.EntranceTime , ExitTime = pp.ExitTime }, pp => pp.ShiftShiftTablet.ShiftDate, model.PageSize, model.PageNo);

			//IQueryable<ShiftShiftTabletCrew>? res = _shiftShiftTabletCrewStore.GetAll();

			return res;
		}

		public int GetAllCount() {
			var res = _shiftShiftTabletCrewStore.TotalCount(GetAllExpressions);
			return res;
		}

		//public IQueryable<ShiftShiftTabletCrew> GetAll() {
		//	IQueryable<ShiftShiftTabletCrew>? res = _shiftShiftTabletCrewStore.GetAll();

		//	return res;
		//}

		public List<ShiftShiftTabletCrew> GetByShiftId(int shifTabletId) {

			List<ShiftShiftTabletCrew>? res = _shiftShiftTabletCrewStore.GetAll().Where(pp => pp.ShiftTabletId == shifTabletId).ToList();

			return res;

		}



		public async Task<BaseResult> Register(ShiftTabletCrewModel model) {

			try {

				var foundAgent= _agentStore.FindById(model.AgentId);
				var foundResourceType = _samtResourceTypeStore.FindById(model.ResourceTypeId);
				var foundShiftTablet = _shiftShiftTabletStore.FindById(model.ShiftTabletId);
				if (foundAgent == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه کارمند یافت نشد.";

				} else if (foundResourceType == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه سمت مورد نظر یافت نشد.";

				} 
				else if (foundShiftTablet==null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه لوح مورد نظر یافت نشد.";

				}
				else if (model.EntranceTime > model.ExitTime) {

					BaseResult.Success = false;
					BaseResult.Message = "زمان خروج باید بزرگتر از زمان ورود کارمند باشد.";

				}
				else {
					ShiftShiftTabletCrew shiftShiftTabletCrew = new ShiftShiftTabletCrew { AgentId = model.AgentId, EntranceTime = model.EntranceTime, ExitTime = model.ExitTime, IsReplaced = false, ResourceId = model.ResourceTypeId, ShiftTabletId = model.ShiftTabletId };
					
					var res = await _shiftShiftTabletCrewStore.InsertAsync(shiftShiftTabletCrew);
				}
			} catch (Exception ex) {

				BaseResult.Success = false;

				ShiftLog shiftLog = new ShiftLog { Message = ex.Message + " " + ex.InnerException?.Message ?? ex.Message };

				//_shiftLogStore.ResetContext();

				var ss = await _shiftLogStore.InsertAsync(shiftLog);

				BaseResult.Message = $"خطای سیستمی شماره {shiftLog.Id} لطفای به مدیر سیستم اطلاع دهید.";

			}


			return BaseResult;
		}

		public async Task<int> Replace(int replaced, int replacedBy) {

			var found = _shiftShiftTabletCrewStore.FindById(replaced);
			if (found != null) {
				found.IsReplaced = true;
				_shiftShiftTabletCrewStore.Update(found).Wait();
			}
			var res = await _shiftShiftTabletCrewReplacementStore.InsertAsync(new ShiftShiftTabletCrewReplacement { ShiftTabletCrewId = replaced, ShiftTabletCrewIdReplaceMent = replacedBy });
			return res;

		}

		

		

		public async Task<BaseResult> Update(ShiftTabletCrewModel model) {

			try {
				var found = _shiftShiftTabletCrewStore.FindById(model.Id);
				if (found == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه مورد نظر شناسایی نشد.";
				} else {
					found.ShiftTabletId = model.ShiftTabletId;
					found.EntranceTime = model.EntranceTime;
					found.ExitTime = model.ExitTime;
					found.ResourceId = model.ResourceTypeId;
					found.AgentId = model.AgentId;

					var res = await _shiftShiftTabletCrewStore.Update(found);
				}
			} catch (Exception ex) {

				BaseResult.Success = false;

				ShiftLog shiftLog = new ShiftLog { Message = ex.Message + " " + ex.InnerException?.Message ?? ex.Message };

				//_shiftLogStore.ResetContext();

				var ss = await _shiftLogStore.InsertAsync(shiftLog);

				BaseResult.Message = $"خطای سیستمی شماره {shiftLog.Id} لطفای به مدیر سیستم اطلاع دهید.";
			}

			return BaseResult;


		}


	}



}
