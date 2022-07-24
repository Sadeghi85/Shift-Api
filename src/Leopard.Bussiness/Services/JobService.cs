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

		private List<Expression<Func<SamtResourceType, bool>>> GetAllExpressions { get; set; } = new();

		public JobService(IPrincipal iPrincipal, ISamtResourceTypeStore samtResourceTypeStore) : base(iPrincipal) {
			_samtResourceTypeStore = samtResourceTypeStore;
		}

		public async Task<StoreViewModel<JobViewModel>>? GetAll(JobSearchModel model) {

			GetAllExpressions.Clear();

			if (string.IsNullOrWhiteSpace(model.Title) && model.Id == 0) {
				GetAllExpressions.Add(pp => true);
			} else {
				if (!string.IsNullOrWhiteSpace(model.Title)) {
					GetAllExpressions.Add(pp => pp.Title.Contains(model.Title));
				}
				if (model.Id != 0) {
					GetAllExpressions.Add(pp => pp.Id == model.Id);
				}

			}
			GetAllExpressions.Add(pp => pp.ParentId == 20 && pp.IsDeleted != true);

			var res = await _samtResourceTypeStore.GetAllWithPagingAsync(GetAllExpressions, pp => new JobViewModel { Id = pp.Id, Title = pp.Title }, pp => pp.Id, model.Desc, model.PageSize, model.PageNo);

			return res;

		}

	}
}
