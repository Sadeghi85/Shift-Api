using Leopard.Bussiness.Model;
using Leopard.Bussiness.Model.ReturnModel;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Services.Interface {
	public interface IShiftTabletLocationService {
		public Task<int> RegisterShiftTabletLocation(ShiftTabletLocationModel model);
		public Task<int> Update(ShiftTabletLocationModel model);

		public IQueryable<ShiftShiftTabletLocation> GetAll();

		public List<ShiftShiftTabletLocation> GetShiftLocattionsByshiftTabletId(int shiftTablettId);
		public Task<List<ShiftTabletLocationResult>>? GetAll(ShiftTabletLocationSearchModel model);

	}
}
