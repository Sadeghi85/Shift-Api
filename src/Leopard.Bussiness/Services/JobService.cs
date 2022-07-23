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

		public JobService(IPrincipal iPrincipal, ISamtResourceTypeStore samtResourceTypeStore) : base(iPrincipal) {
			_samtResourceTypeStore = samtResourceTypeStore;
		}

		private List<Expression<Func<SamtResourceType, bool>>> GetAllExpressions { get; set; } = new List<Expression<Func<SamtResourceType, bool>>>();


		public Task<List<JobViewModel>>? GetAll(JobSearchModel model, out Task<int> totalCount) {

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

			Task<List<JobViewModel>>? res = _samtResourceTypeStore.GetAllWithPagingAsync(GetAllExpressions, pp => new JobViewModel { Id = pp.Id, Title = pp.Title }, pp => pp.Id, model.PageSize, model.PageNo, "desc", out totalCount);
			return res;

		}

		//public int GetAllCount() {
		//	var res = _samtResourceTypeStore.TotalCount(GetAllExpressions);
		//	return res;
		//}


	}
}
