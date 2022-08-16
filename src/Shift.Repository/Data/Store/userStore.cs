using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Repository {

	public partial class UserStore : StoreBase<User>, IUserStore {

		const int ModuleId = 37;
		const string ModuleTitle = "ShiftTablet";


		public async Task<bool> HasUserPermission(int userId, string permissionKey) {
			var results = await _ctx.SpShiftPermissionsAsync(userId, ModuleId, ModuleTitle, permissionKey.Contains(ModuleTitle) ? permissionKey : ModuleTitle+"."+permissionKey);
			return (results?.Any()) ?? false;
		}


		public async Task<List<SpShiftPermissionsReturnModel>> GetUserPermissions(int userId) {
			return  await _ctx.SpShiftPermissionsAsync(userId, ModuleId, ModuleTitle, "");
		}


	}
}
