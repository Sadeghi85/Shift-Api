using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Model {
	public class PortalSearchModel:PagerViewModel {
		

		private string _title;

		public string Title {
			get {
				_title = _title ?? "";
				return _title.Trim();
			}
			set {
				_title = value;
			}
		}
		public int? PortalId { get; set; }

	}
}