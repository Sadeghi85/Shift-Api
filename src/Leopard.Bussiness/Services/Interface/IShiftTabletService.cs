using Leopard.Bussiness.Model;
using Leopard.Bussiness.Model.ReturnModel;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness {
	public interface IShiftTabletService {
		public  Task<BaseResult> RegisterShiftTablet(ShiftTabletModel model);
		public List<ShiftShiftTablet> GetTabletShiftByPortalId(int portalId);
		public IQueryable<ShiftShiftTablet> GetAll();

		public Task<BaseResult> UpdateShifTablet(ShiftTabletModel model);
		public Task<List<ShiftTabletResult>>? GetAll(ShiftTabletSearchModel model);
		public int GetShiftTabletCount();
		public Task<BaseResult> Delete(ShiftTabletModel model);
	}
}
