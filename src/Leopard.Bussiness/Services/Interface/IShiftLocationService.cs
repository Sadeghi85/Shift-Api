using Leopard.Bussiness.Model;
using Leopard.Bussiness.Model.ReturnModel;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Services.Interface {
	public interface IShiftLocationService : IServiceBase {
		public Task<List<ShiftLocationReturnModel>> GetAll(LocationSearchModel model);

		public Task<BaseResult> RegisterShiftLocation(LocationModel model);

		public Task<BaseResult> Update(LocationModel model);
		public  Task<BaseResult> Delete(LocationModel model);

		public int GetAllTotal();


	}
}
