using Leopard.Bussiness.Model;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Services.Interface {
	public interface IShiftTabletService {
		public Task<int> RegisterShiftTablet(ShiftTabletModel model);
		public List<ShiftShiftTablet> GetTabletShiftByPortalId(int portalId);
		public IQueryable<ShiftShiftTablet> GetAll();

		public Task<int> UpdateShifTablet(ShiftTabletModel model);
	}
}
