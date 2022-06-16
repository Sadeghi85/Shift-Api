using Leopard.Bussiness.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leopard.Repository;
using Leopard.Bussiness.Model;
using System.Linq.Expressions;

namespace Leopard.Bussiness.Services {
	public class ResourceTypeService : IResourceTypeService {

		private readonly ISamtResourceTypeStore _samtResourceTypeStore;

		public ResourceTypeService(ISamtResourceTypeStore samtResourceTypeStore) {
			_samtResourceTypeStore = samtResourceTypeStore;
		}

		private List<Expression<Func<SamtResourceType, bool>>> GetAllExpressions { get; set; } = new List<Expression<Func<SamtResourceType, bool>>>();


		public Task<List<SamtResourceType>>? GetAll(ResourceTypeSearchModel model) {

			if (string.IsNullOrWhiteSpace(model.ResourceName) && model.Id==0) {
				GetAllExpressions.Add(pp => true);
			} else {
				if (!string.IsNullOrWhiteSpace(model.ResourceName)) {
					GetAllExpressions.Add(pp => model.ResourceName.Contains(pp.Title));
				}
				if (model.Id != 0) {
					GetAllExpressions.Add(pp=> pp.Id==model.Id);
				}

			}
			GetAllExpressions.Add(pp => pp.ParentId == 20 && pp.IsDeleted == false);

			Task<List<SamtResourceType>>? res = _samtResourceTypeStore.GetAllWithPagingAsync(GetAllExpressions, pp => pp, pp => pp.Id, model.PageSize, model.PageNo, "desc");
			return res;

		}

		public int GetAllCount() {
			var res= _samtResourceTypeStore.TotalCount(GetAllExpressions);
			return res;
		}


		}
	}
