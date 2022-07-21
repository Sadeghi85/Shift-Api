using Leopard.Bussiness.Model;
using Leopard.Bussiness.Model.ReturnModel;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness {
	public interface ILocationService {
		public Task<List<LocationViewModel>> GetAll(LocationSearchModel model);

		public Task<BaseResult> RegisterShiftLocation(LocationInputModel model);

		public Task<BaseResult> Update(LocationInputModel model);
		public  Task<BaseResult> Delete(LocationInputModel model);

		public int GetAllTotal();


	}
}
