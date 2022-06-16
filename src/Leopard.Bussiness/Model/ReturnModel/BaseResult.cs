using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Model.ReturnModel {
	public class BaseResult {
		public string Message { get; set; } = "عملیات با موفقیت انجام شد.";
		public bool Success { get; set; } = true;

		
	}
}
