
using Shift.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Bussiness {
	public interface IShiftTabletReportService {
		
		public Task<StoreViewModel<ShiftTabletReportViewModel>> GetAll(ShiftTabletReportSearchModel model);
		public Task<BaseResult> Create(ShiftTabletReportInputModel model);



	}
}
