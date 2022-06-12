using Leopard.Bussiness.Model;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Services.Interface {
	public interface IShiftProductionTypeService {

		

		public OperationResult GetAll();
		public OperationResult FindById(int id);
		public Task<OperationResult> Register(ShiftProductionTypeModel model);

		public Task<OperationResult> Update(ShiftProductionTypeModel model);
	}
}
