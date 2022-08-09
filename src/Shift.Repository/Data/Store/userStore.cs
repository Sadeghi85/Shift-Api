using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Repository {

	public partial class UserStore : StoreBase<User>, IUserStore {

		public bool HasUserPermission(int userId, string permissionKey) {
			var results = _ctx.SpShiftCheckShiftTimeOverlap(id, portalId, shiftType, startTime, endTime).FirstOrDefault()?.checkOverlap ?? false;
		}
	}
}
