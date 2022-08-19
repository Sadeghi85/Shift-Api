using Shift.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Bussiness {
	public interface ICooperationTypeService {
		public Task<StoreViewModel<CooperationTypeViewModel>> GetAll(CooperationTypeSearchModel model);
		//public ValueTask<Portal?> GetById(int id);
	}
}
