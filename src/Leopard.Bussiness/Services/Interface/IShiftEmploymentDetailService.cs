using Leopard.Bussiness.Model;
using Leopard.Bussiness.Model.ReturnModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Services.Interface {
	public interface IShiftEmploymentDetailService {
		public Task<BaseResult> Register(ShiftEmploymentDetailModel model);
		public Task<BaseResult> Update(ShiftEmploymentDetailModel model);
		public Task<BaseResult> Delete(ShiftEmploymentDetailModel model);
		public int GetAllCount();
		public  Task<List<ShiftEmploymentDetailResult>> GetAll(ShiftEmploymentDetailSearchModel model);

	}
}
