using Lamar;
using Shift.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Bussiness {

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
