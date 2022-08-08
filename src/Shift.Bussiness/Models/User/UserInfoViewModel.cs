using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Bussiness {
	public class UserInfoViewModel {

		public UserInfoViewModel() {

		}

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string UserName { get; set; }
		public string FullName { get; set; }
		public int PortalId { get; set; }
		public int UserId { get; set; }

		public ApiToken Token { get; set; }
		public List<string> Permissions { get; set; }

	}
}