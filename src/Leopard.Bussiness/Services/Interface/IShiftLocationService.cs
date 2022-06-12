using Leopard.Bussiness.Model;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Services.Interface {
	public interface IShiftLocationService {
		public OperationResult GetAll();
		public OperationResult GetShiftLocationByPortalId(int portalId);

		public Task<OperationResult> RegisterShiftLocation(ShiftLocationModel model);

		public Task<OperationResult> Update(ShiftLocationModel model);


	}
}
