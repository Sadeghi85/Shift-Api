using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness {
	public interface IJobService {
		public Task<List<JobViewModel>>? GetAll(JobSearchModel model, out Task<int> totalCount);
		//public int GetAllCount();
	}
}
