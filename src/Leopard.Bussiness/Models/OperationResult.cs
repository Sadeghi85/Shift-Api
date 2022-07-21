using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Model {
	public class OperationResult1 {



		public bool Success { get; set; } = true;

		public string Message { get; set; } = "عملیات با موفقیت انجام شد.";

		public Object Data { get; set; }

		public int Count {
			get {
				IEnumerable<object> en = (Data as IEnumerable<object>);
				if (en != null) {
					return en.Count();
				} else {
					return 0;
				}
			}
		}

	}
}
