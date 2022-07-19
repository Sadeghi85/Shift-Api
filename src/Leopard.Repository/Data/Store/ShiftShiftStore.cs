using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Repository {
	public partial class ShiftShiftStore : StoreBase<ShiftShift>, IShiftShiftStore {

		public bool CheckTimeOverlap(int id, int portalId, int shiftType, TimeSpan startTime, TimeSpan endTime) {
			return _ctx.SpShiftCheckShiftTimeOverlap(id, portalId, shiftType, startTime, endTime).FirstOrDefault()?.checkOverlap ?? false;
		}


	}
}
