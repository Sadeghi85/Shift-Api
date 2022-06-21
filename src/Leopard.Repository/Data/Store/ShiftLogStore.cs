using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Repository {
	public partial class ShiftLogStore : StoreBase<ShiftLog>, IShiftLogStore {


		//public void ResetContext() {

		//	_ctx.Instance.ChangeTracker.Entries()
		//								.Where(e => e.Entity != null).ToList()
		//								.ForEach(e => e.State = EntityState.Detached);

		//}

		
	}
}
