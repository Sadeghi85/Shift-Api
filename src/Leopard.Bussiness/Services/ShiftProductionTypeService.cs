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
	public class ShiftProductionTypeService :BaseService, IShiftProductionTypeService {

		readonly private ShiftProductionTypeStore _shiftProductionTypeStore;
		private List<Expression<Func<ShiftProductionType, bool>>> GetAllExpressions { get; set; } = new List<Expression<Func<ShiftProductionType, bool>>>();

		private IShiftLogStore _shiftLogStore;

		public ShiftProductionTypeService(ShiftProductionTypeStore shiftProductionTypeStore, IShiftLogStore shiftLogStore) {
			_shiftProductionTypeStore = shiftProductionTypeStore;
			_shiftLogStore = shiftLogStore;
		}


		public ShiftProductionType FindById(int id) {



			var res = _shiftProductionTypeStore.FindById(id);

			return res;

		}

		public Task<List<ShiftProductionResult>>? GetAll(ShiftProductionSearchModel model) {

			if (string.IsNullOrWhiteSpace(model.Title ) && model.Id == 0) {
				GetAllExpressions.Add(pp=> true);
			} else {
				if (!string.IsNullOrWhiteSpace(model.Title)) {
					GetAllExpressions.Add(pp => model.Title.Contains(pp.Title));
				}
				if (model.Id != 0) {
					GetAllExpressions.Add(pp => pp.Id == model.Id);
				}
			}

			Task<List<ShiftProductionResult>>? res = _shiftProductionTypeStore.GetAllWithPagingAsync(GetAllExpressions, pp => new ShiftProductionResult { Id = pp.Id, Title = pp.Title }, pp=> pp.Id , model.PageSize , model.PageNo , "desc");


			//IQueryable<ShiftProductionType>? res = _shiftProductionTypeStore.GetAll();

			return res;
		}

		public int GetAllCount() {
			var res = _shiftProductionTypeStore.TotalCount(GetAllExpressions);
			return res;
		}

		public async Task<BaseResult> Register(ShiftProductionTypeModel model) {



			try {
				ShiftProductionType shiftProductionType = new ShiftProductionType { Title = model.Title };
				int res = await _shiftProductionTypeStore.InsertAsync(shiftProductionType);
			} catch (Exception ex) {

				BaseResult.Success = false;

				ShiftLog shiftLog = new ShiftLog { Message = ex.Message + " " + ex.InnerException != null ? ex.InnerException.Message : "" };

				//_shiftLogStore.ResetContext();

				var ss = await _shiftLogStore.InsertAsync(shiftLog);

				BaseResult.Message = $"خطای سیستمی شماره {shiftLog.Id} لطفای به مدیر سیستم اطلاع دهید.";

			}

			return BaseResult;

		}

		public async Task<BaseResult> Update(ShiftProductionTypeModel model) {

			try {
				var found = _shiftProductionTypeStore.FindById(model.Id);
				if (found == null) { 
					BaseResult.Success=false;
					BaseResult.Message = "شناسه مورد نظر جستجو نشد.";
				} else {
					found.Title = model.Title;

					var res = await _shiftProductionTypeStore.Update(found);
				}
			} catch (Exception ex) {

				BaseResult.Success = false;

				ShiftLog shiftLog = new ShiftLog { Message = ex.Message + " " + ex.InnerException != null ? ex.InnerException.Message : "" };

				//_shiftLogStore.ResetContext();

				var ss = await _shiftLogStore.InsertAsync(shiftLog);

				BaseResult.Message = $"خطای سیستمی شماره {shiftLog.Id} لطفای به مدیر سیستم اطلاع دهید.";
			}

			return BaseResult;

		}

	}
}
