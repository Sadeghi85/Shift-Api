using Leopard.Bussiness.Model;
using Leopard.Bussiness.Model.ReturnModel;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Services {
	public class ServiceBase : IServiceBase {


		protected readonly IPrincipal _iPrincipal;
		public ServiceBase(IPrincipal iPrincipal) {
			_iPrincipal = iPrincipal;
		}

		public int? CurrentUserId {
			get {
				var ident = _iPrincipal as ClaimsPrincipal;
				var uId = ident?.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
				if (string.IsNullOrWhiteSpace(uId)) {
					return null;
				}
				return int.Parse(uId);
			}
		}


		public int? CurrentUserPortalId {
			get {
				//TODO: find difference between ClaimsIdentity & ClaimsPrincipal
				var ident = _iPrincipal as ClaimsIdentity;
				var uId = ident?.Claims.FirstOrDefault(c => c.Type == "PortalId")?.Value;
				if (string.IsNullOrWhiteSpace(uId)) {
					return null;
				}
				return int.Parse(uId);
			}
		}



		protected BaseResult BaseResult { get; set; } = new BaseResult();
	}
}
