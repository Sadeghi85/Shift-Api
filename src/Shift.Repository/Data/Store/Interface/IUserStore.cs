using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Repository {

	public partial interface IUserStore : IStoreBase<User> {

		public bool HasUserPermission(int userId, string permissionKey);

	}
}
