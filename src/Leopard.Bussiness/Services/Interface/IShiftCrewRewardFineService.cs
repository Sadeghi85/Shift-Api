using Leopard.Bussiness.Model;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Services.Interface {
	public interface IShiftCrewRewardFineService {
		public  Task <int> Register(ShiftCrewRewardFineModel model);
		public Task<int> Update(ShiftCrewRewardFineModel model);

		public IQueryable<ShiftCrewRewardFine> GetAll();

		public Task<int> Delete(int id);
	}
}
