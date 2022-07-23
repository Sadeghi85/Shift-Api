using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness {
	public class ScriptSupervisorDescriptionSearchModel: PagerViewModel {

		public int Id { get; set; } // Id (Primary key)
		public int? ShiftTabletId { get; set; } // ShiftTabletId
		
		public DateTime? CreateDateTime { get; set; } // CreateDateTime
		public DateTime? LastModifiedDateTime { get; set; } // LastModifiedDateTime
		public string Description { get; set; } // Description (length: 1000)
		public bool? IsDeleted { get; set; }
		
	}
}
