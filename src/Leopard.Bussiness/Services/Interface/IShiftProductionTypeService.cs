using Leopard.Bussiness.Model;
using Leopard.Bussiness.Model.ReturnModel;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Services.Interface {
	public interface IShiftProductionTypeService {


		public Task<List<ShiftProductionResult>>? GetAll(ShiftProductionSearchModel model);
		public ShiftProductionType FindById(int id);
		public Task<BaseResult> Register(ShiftProductionTypeModel model);
		public Task<BaseResult> Update(ShiftProductionTypeModel model);
		public int GetAllCount();
	}
}
