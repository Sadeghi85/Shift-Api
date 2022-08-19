using Shift.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Bussiness {
	public interface IMonetarySettingService {
		public Task<StoreViewModel<MonetarySettingViewModel>> GetAll(MonetarySettingSearchModel model);

		public Task<BaseResult> CreateOrUpdate(MonetarySettingInputModel model);


		public Task<BaseResult> Delete(int id);
		public Task<BaseResult> Delete(string ids);



	}
}
