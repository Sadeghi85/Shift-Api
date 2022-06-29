using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Model.ReturnModel {
	public class ShiftNeededResourcesResult {
		public int ShiftId { get; set; }
		public int ResourceId { get; set; }
		public string ShiftName { get; set; }
		public string ResourceTypeName { get; set; }
	}
}
