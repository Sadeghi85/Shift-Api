using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leopard.Repository;
using System.Linq.Expressions;
using System.Security.Principal;

namespace Leopard.Bussiness {
	public class JobService : ServiceBase, IJobService {

		private readonly ISamtResourceTypeStore _samtResourceTypeStore;

		public JobService(IPrincipal iPrincipal, ISamtResourceTypeStore samtResourceTypeStore, IShiftLogStore shiftLogStore) : base(iPrincipal, shiftLogStore) {
			_samtResourceTypeStore = samtResourceTypeStore;
		}

		public async Task<StoreViewModel<JobViewModel>> GetAll(JobSearchModel model) {

			var getAllExpressions = new List<Expression<Func<SamtResourceType, bool>>>();

			if (model.Id > 0) {
				getAllExpressions.Add(x => x.Id == model.Id);
			}
			if (!string.IsNullOrWhiteSpace(model.Title)) {
				getAllExpressions.Add(x => x.Title.Contains(model.Title));
			}
			if (model.IsDeleted != null) {
				getAllExpressions.Add(x => x.IsDeleted == model.IsDeleted);
			}

			getAllExpressions.Add(x => x.ParentId == 20);

			var res = await _samtResourceTypeStore.GetAllWithPagingAsync(getAllExpressions, x => new JobViewModel { Id = x.Id, Title = x.Title }, model.OrderKey, model.Desc, model.PageSize, model.PageNo);

			return res;

		}

	}
}
