using System.Threading.Tasks;

namespace Shift.Bussiness {
	public interface IServiceBase {

		public int? CurrentUserId {
			get;
		}

		public int CurrentUserPortalId {
			get;
		}

	}
}
