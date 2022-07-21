using Leopard.Bussiness.Model;
using Leopard.Bussiness.Model.ReturnModel;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness {
	public interface IShiftTabletCrewService {
		public  Task<BaseResult> Update(ShiftTabletCrewInputModel model);
		public Task<BaseResult> Delete(ShiftTabletCrewInputModel model);
		public Task<int> Replace(int replaced, int replacedBy);
		public List<ShiftShiftTabletCrew> GetByShiftId(int shifTabletId);
		public List<ShiftTabletCrewViewModel> ShfitTabletReport(DateTime fromDate, DateTime toDate, int PortalId, int take = 10, int skip = 10);
		public Task<List<ShiftTabletCrewViewModel>>? GetAll(ShiftTabletCrewSearchModel model);
		public int GetAllCount();
		public  Task<BaseResult> Register(ShiftTabletCrewInputModel model);


	}
}
