using Shift.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Bussiness {
	public class CooperationTypeService : ServiceBase, ICooperationTypeService {

		private readonly ISamtHrCooperationTypeStore _samtHrCooperationTypeStore;

		public CooperationTypeService(IPrincipal iPrincipal, IShiftLogStore shiftLogStore, ISamtHrCooperationTypeStore samtHrCooperationTypeStore) : base(iPrincipal, shiftLogStore) {
			_samtHrCooperationTypeStore = samtHrCooperationTypeStore;
		}

		public async Task<StoreViewModel<CooperationTypeViewModel>> GetAll(CooperationTypeSearchModel model) {

			if (CurrentUserPortalId > 1) {
				model.Id = CurrentUserPortalId;
			}

			var getAllExpressions = new List<Expression<Func<SamtHrCooperationType, bool>>>();

			if (!string.IsNullOrWhiteSpace(model.Title)) {
				getAllExpressions.Add(x => x.HrCooperationTypeTitle.Contains(model.Title));
			}

			if (model.Id > 0) {
				getAllExpressions.Add(x => x.HrCooperationTypeId == model.Id);
			}

			var res = await _samtHrCooperationTypeStore.GetAllWithPagingAsync(getAllExpressions, x => new CooperationTypeViewModel { Id = x.HrCooperationTypeId, Title = x.HrCooperationTypeTitle }, model.OrderKey, model.Desc, model.PageSize, model.PageNo);

			return res;
		}

		//public async ValueTask<Portal?> GetById(int id) {
		//	var res = await _portalStore.FindByIdAsync(id);

		//	return res;

		//}
	}
}
