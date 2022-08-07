using Shift.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Bussiness {
	public interface IShiftTabletCrewService {
		public Task<BaseResult> HamahangiUpdate(ShiftTabletCrewInputModel model);
		public Task<BaseResult> Update(ShiftTabletCrewInputModel model);
		public Task<BaseResult> Delete(int id);
		//public Task<int> Replace(int replaced, int replacedBy);
		//public List<ShiftShiftTabletCrew> GetByShiftId(int shifTabletId);
		//public Task<StoreViewModel<ShiftTabletCrewViewModel>> ShfitTabletReport(DateTime fromDate, DateTime toDate, int PortalId, int take = 10, int skip = 10);
		public Task<StoreViewModel<ShiftTabletCrewViewModel>> GetAll(ShiftTabletCrewSearchModel model);
		public Task<BaseResult> Register(ShiftTabletCrewInputModel model);

		public Task<MemoryStream> GetExcelReport(ShiftTabletCrewSearchModel model);
		public Task<MemoryStream> GetPdfReport(ShiftTabletCrewSearchModel model);


	}
}
