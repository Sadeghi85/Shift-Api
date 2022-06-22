using Leopard.Bussiness.Model;
using Leopard.Bussiness.Model.ReturnModel;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Services.Interface {
	public interface IShiftLocationService {
		public Task<List<ShiftLocationReturnModel>> GetAll(ShiftLocationSearchModel model);
		public List<ShiftLocation> GetShiftLocationByPortalId(int portalId);

		public Task<BaseResult> RegisterShiftLocation(ShiftLocationModel model);

		public Task<BaseResult> Update(ShiftLocationModel model);
		public  Task<BaseResult> Delete(int id);

		public int GetAllTotal();


	}
}
