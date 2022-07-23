using Lamar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Repository {

	public class LamarStoreRegistry : ServiceRegistry {

		public LamarStoreRegistry() {
			
			//For(typeof(IDapper)).Use(typeof(DapperORM));
			For(typeof(ILeopardDbContext)).Use(typeof(LeopardDbContext)).Scoped();
			Scan(_ => {

				_.AssemblyContainingType(typeof(IStoreBase<BaseEntity>));
				_.WithDefaultConventions();

			});
		}
	}
}
