using Leopard.Bussiness.Model;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Services.Interface {
	public interface IShiftTabletCrewService {
		public Task<OperationResult> Register(ShiftTabletCrewModel model);
		public Task<OperationResult> Update(ShiftTabletCrewModel model);

		public Task<OperationResult> Delete(int id);

		public Task<OperationResult> Replace(int replaced, int replacedBy);

		public OperationResult GetAll();

		public OperationResult GetByShiftId(int shifTabletId);


	}
}
