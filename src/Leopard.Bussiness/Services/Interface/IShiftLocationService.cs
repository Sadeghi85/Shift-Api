using Leopard.Bussiness.Model;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Services.Interface {
	public interface IShiftLocationService {
		public IQueryable<ShiftLocation> GetAll();
		public List<ShiftLocation> GetShiftLocationByPortalId(int portalId);

		public Task<int> RegisterShiftLocation(ShiftLocationModel model);

		public Task<int> Update(ShiftLocationModel model);


	}
}
