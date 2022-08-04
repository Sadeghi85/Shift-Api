using System.Threading.Tasks;

namespace Leopard.Bussiness {
	public interface IServiceBase {

		public int? CurrentUserId {
			get;
		}

		public int CurrentUserPortalId {
			get;
		}

	}
}
