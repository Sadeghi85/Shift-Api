using Leopard.Bussiness.Model;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Services.Interface {
	public interface IShiftTabletService {
		public Task<OperationResult> RegisterShiftTablet(ShiftTabletModel model);
		public OperationResult GetTabletShiftByPortalId(int portalId);
		public OperationResult GetAll();

		public Task<OperationResult> UpdateShifTablet(ShiftTabletModel model);
	}
}
