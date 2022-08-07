using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Repository {
	public partial interface IShiftLogStore : IStoreBase<ShiftLog> {
		public void ResetContext();
	}
}
