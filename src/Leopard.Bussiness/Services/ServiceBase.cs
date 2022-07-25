using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness {
	public class ServiceBase : IServiceBase {


		private readonly IPrincipal _iPrincipal;
		private readonly IShiftLogStore _shiftLogStore;

		public ServiceBase(IPrincipal iPrincipal, IShiftLogStore shiftLogStore) {
			_iPrincipal = iPrincipal;
			_shiftLogStore = shiftLogStore;
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
				var ident = _iPrincipal as ClaimsPrincipal;
				var uId = ident?.Claims.FirstOrDefault(c => c.Type == "PortalId")?.Value;
				if (string.IsNullOrWhiteSpace(uId)) {
					return null;
				}
				return int.Parse(uId);
			}
		}
		protected BaseResult BaseResult { get; set; } = new BaseResult();

		public async Task<BaseResult> LogError(Exception ex) {

			var shiftLog = new ShiftLog { Message = ex.Message + Environment.NewLine + ex.InnerException?.Message + Environment.NewLine + ex.StackTrace ?? "" };

			await _shiftLogStore.InsertAsync(shiftLog);

			var res = new BaseResult();

			res.Success = false;
			res.Message = $"خطای سیستمی شماره '{shiftLog.Id}'؛ لطفا به مدیر سیستم اطلاع دهید";

			return res;
		}
	}
}
