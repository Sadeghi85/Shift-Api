using Leopard.Bussiness.Model;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Services.Interface {
	public interface IShiftProductionTypeService {

		
		public IQueryable<ShiftProductionType> GetAll();
		public ShiftProductionType FindById(int id);
		public Task<int> Register(ShiftProductionTypeModel model);
		public Task<int> Update(ShiftProductionTypeModel model);
	}
}
