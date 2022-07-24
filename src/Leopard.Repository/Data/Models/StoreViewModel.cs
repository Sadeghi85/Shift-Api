using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Repository {
	public class StoreViewModel<T> {

		public int TotalCount { get; set; } = 0;
		public List<T> Result { get; set; } = new List<T>();
	}
}
