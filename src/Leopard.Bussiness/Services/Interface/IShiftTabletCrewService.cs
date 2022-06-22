using Leopard.Bussiness.Model;
using Leopard.Bussiness.Model.ReturnModel;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Services.Interface {
	public interface IShiftTabletCrewService {

		public  Task<BaseResult> Update(ShiftTabletCrewModel model);

		public Task<BaseResult> Delete(int id);

		public Task<int> Replace(int replaced, int replacedBy);

		//public IQueryable<ShiftShiftTabletCrew> GetAll();

		public List<ShiftShiftTabletCrew> GetByShiftId(int shifTabletId);

		public List<ShfitTabletReportResult> ShfitTabletReport(DateTime fromDate, DateTime toDate, int PortalId, int take = 10, int skip = 10);

		public Task<List<ShfitTabletReportResult>>? GetAll(ShiftTabletCrewSearchModel model);
		public int GetAllCount();
		public  Task<BaseResult> Register(ShiftTabletCrewModel model);


	}
}
