
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Repository {
	public partial interface IShiftShiftStore : IStoreBase<ShiftShift> {
		public bool CheckTimeOverlap(int id, int portalId, int shiftType, TimeSpan startTime, TimeSpan endTime);
	}
}
