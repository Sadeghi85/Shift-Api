using Leopard.Bussiness.Model;
using Leopard.Bussiness.Model.ReturnModel;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness {
	public interface IShiftTabletLocationService {
		public  Task<BaseResult> RegisterShiftTabletLocation(ShiftTabletLocationModel model);
		public Task<BaseResult> Update(ShiftTabletLocationModel model);

		public IQueryable<ShiftShiftTabletLocation> GetAll();

		public List<ShiftShiftTabletLocation> GetShiftLocattionsByshiftTabletId(int shiftTablettId);
		public Task<List<ShiftTabletLocationResult>>? GetAll(ShiftTabletLocationSearchModel model);

	}
}
