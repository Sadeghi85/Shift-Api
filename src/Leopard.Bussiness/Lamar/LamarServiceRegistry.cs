using Lamar;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness {

	public class LamarServiceRegistry : ServiceRegistry {

		public LamarServiceRegistry() {

			IncludeRegistry<LamarStoreRegistry>();

			Scan(_ => {
				_.AssemblyContainingType(typeof(IServiceBase));
				_.WithDefaultConventions();

			});
		}
	}
}
