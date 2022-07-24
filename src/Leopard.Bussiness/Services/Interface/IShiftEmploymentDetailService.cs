using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness {
	public interface IShiftEmploymentDetailService {
		public Task<BaseResult> Register(ShiftEmploymentDetailInputModel model);
		public Task<BaseResult> Update(ShiftEmploymentDetailInputModel model);
		public Task<BaseResult> Delete(ShiftEmploymentDetailInputModel model);
		
		public Task<StoreViewModel<ShiftEmploymentDetailViewModel>> GetAll(ShiftEmploymentDetailSearchModel model);

	}
}
