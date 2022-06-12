using Leopard.Bussiness.Model;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Services.Interface {
	public interface IShiftTabletLocationService {
		public Task<OperationResult> RegisterShiftTabletLocation(ShiftTabletLocationModel model);
		public Task<OperationResult> Update(ShiftTabletLocationModel model);

		public OperationResult GetAll();

		public OperationResult GetShiftLocattionsByshiftTabletId(int shiftTablettId);


	}
}
