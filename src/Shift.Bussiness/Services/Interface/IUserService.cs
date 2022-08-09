using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Bussiness {
	public interface IUserService {

		public Task<UserInfoViewModel> GetUserInfoAsync();
		public Task<bool> HasUserPermission(int userId, string permissionKey);
	}

}