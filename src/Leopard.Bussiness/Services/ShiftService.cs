using Leopard.Bussiness.Model;
using Leopard.Bussiness.Model.ReturnModel;
using Leopard.Bussiness.Services.Interface;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Services {
	public class ShiftService : IShiftService {

		private readonly IShiftShiftStore _shiftShiftStore;
		private readonly IPortalStore _portalStore;

		private List<Expression<Func<ShiftShift, bool>>> Expressions { get; set; } = new List<Expression<Func<ShiftShift, bool>>>();


		public ShiftService(IShiftShiftStore shiftShiftStore, IPortalStore portalStore) {
			_shiftShiftStore = shiftShiftStore;
			_portalStore = portalStore;

		}


		public async Task<int> Delete(int id) {

			var found = _shiftShiftStore.FindById(id);
			found.IsDeleted = true;
			var res = await _shiftShiftStore.Update(found);

			return res;

		}

		public List<ShiftShift> FindByPortalId(int portalId) {

			List<ShiftShift>? res = _shiftShiftStore.GetAll().Where(pp => pp.PortalId == portalId).ToList();

			return res;

		}

		public Task<List<ShiftResultModel>> GetAll(ShiftSearchModel model) {


			if (string.IsNullOrWhiteSpace(model.Title) && model.PortalId == 0) {
				Expressions.Add(pp => true);
			} else {
				if (model.PortalId != 0) {
					Expressions.Add(pp => pp.PortalId == model.PortalId);
				}
				if (!string.IsNullOrWhiteSpace(model.Title)) {
					Expressions.Add(pp => model.Title.Contains(pp.Title));
				}
			}

			Task<List<ShiftResultModel>>? res = _shiftShiftStore.GetAllWithPagingAsync(Expressions, pp => new ShiftResultModel { Id = pp.Id, Title = pp.Title, PortalTitle = pp.Portal.Title, PortalId = pp.PortalId, EndTime = pp.EndTime, StartTime = pp.StartTime, ShiftTypeId = pp.ShiftType.Value, ShiftTypeTitle = GetShiftTypeTitleByShiftTypeId(pp.ShiftType) }, pp => pp.Id, model.PageSize, model.PageNo, "desc");



			//IQueryable<ShiftShift>? res = _shiftShiftStore.GetAll().Where(pp => pp.Title.Contains(model.Title) && pp.PortalId == model.PortalId).Skip(model.PageNo*model.PageSize).Take(model.PageSize);
			//if (model.desc == false) {

			//	res = res.OrderBy(pp => pp.Title);
			//} else {
			//	res = res.OrderByDescending(pp => pp.Title);
			//}

			return res;
		}

		private static string GetShiftTypeTitleByShiftTypeId(int? ShiftTypeId) {
			switch (ShiftTypeId) {
				case 1:
					return "رژی";
					break;
				case 2:
					return "هماهنگی";
					break;
				default: return "نامشخص";

			}
		}

		public int GetAllCount() {
			var res = _shiftShiftStore.TotalCount(Expressions);
			return res;
		}


		public IQueryable<ShiftShift> GetByPortalId(int portalId) {
			//throw new NotImplementedException();
			IQueryable<ShiftShift>? res = _shiftShiftStore.GetAll().Where(pp => pp.PortalId == portalId);
			return res;

		}

		public async Task<BaseResult> Register(ShiftModel model) {

			BaseResult baseResult = new BaseResult();

			var foundPortal = _portalStore.FindById(model.PortalId);

			try {
				var found = _shiftShiftStore.GetAll().Any(pp => pp.Title == model.Title);

				if (found) {
					baseResult.Success = false;
					baseResult.Message = "نام انتخاب شده برای شیفت تکراری است.";

				} 
				//else if (foundPortal==null) {
				//	baseResult.Success = false;
				//	baseResult.Message = "شناسه پورتال شناسایی نشد.";
				//} 
				else if (model.StartTime > model.EndTime) {
					baseResult.Success = false;
					baseResult.Message = "ساعت شروع باید کوچتر از زمان پایان باشد.";
				}

				

				else {



					ShiftShift shiftShift = new ShiftShift { Title = model.Title, PortalId = model.PortalId, ShiftType = model.ShiftType, StartTime = model.StartTime, EndTime = model.EndTime, IsDeleted = false };

					var res = await _shiftShiftStore.InsertAsync(shiftShift);

				}
			} catch (Exception ex) {

				baseResult.Success = false;
				baseResult.Message = "خطای سیستمی!";
				baseResult.SystemMessage = ex.Message + "\r\n"+ ex.InnerException != null ? ex.InnerException.Message : "";
			}
			return baseResult;

		}

		private bool IsInShiftType(int shiftType) {
			List<int> shiftTypes = new List<int>() { 1, 2 };
			var res = shiftTypes.Contains(shiftType);
			return res;
		}

		public async Task<int> Update(ShiftModel model) {

			var found = _shiftShiftStore.FindById(model.Id);
			var res = 0;
			if (found != null) {

				found.Title = model.Title;
				found.StartTime = model.StartTime;
				found.EndTime = model.EndTime;
				found.ShiftType = model.ShiftType;
				found.PortalId = model.PortalId;
				res = await _shiftShiftStore.Update(found);

			}
			return res;
		}
	}
}
