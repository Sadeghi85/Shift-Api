using Lamar;
using Shift.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Bussiness {

	public class LamarStoreRegistry : ServiceRegistry {

		public LamarStoreRegistry() {
			
			//For(typeof(IDapper)).Use(typeof(DapperORM));
			For(typeof(IShiftDbContext)).Use(typeof(ShiftDbContext)).Scoped();
			Scan(_ => {

				_.AssemblyContainingType(typeof(IStoreBase<BaseEntity>));
				_.WithDefaultConventions();

			});
		}
	}
}
