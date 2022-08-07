using Shift.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Bussiness {
	public interface IJobService {
		public Task<StoreViewModel<JobViewModel>> GetAll(JobSearchModel model);

	}
}
