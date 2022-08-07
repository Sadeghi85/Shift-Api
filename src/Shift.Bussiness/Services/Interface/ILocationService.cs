using Shift.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Bussiness {
	public interface ILocationService {
		public Task<StoreViewModel<LocationViewModel>> GetAll(LocationSearchModel model);

		public Task<BaseResult> Register(LocationInputModel model);
		public Task<BaseResult> Update(LocationInputModel model);
		public Task<BaseResult> Delete(int id);



	}
}
