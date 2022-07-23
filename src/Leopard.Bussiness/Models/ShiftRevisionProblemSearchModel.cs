using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness {
	public class ShiftRevisionProblemSearchModel: PagerViewModel {

		public int Id { get; set; } // Id (Primary key)
		public int? ShiftTabletId { get; set; } // ShiftTabletId
		public string FileNumber { get; set; } // FileNumber (length: 50)
		public string FileName { get; set; } // FileName (length: 500)
		public int? ClacketNo { get; set; } // ClacketNo
		public string ProblemDescription { get; set; } // ProblemDescription (length: 500)
		public string RevisorCode { get; set; } // RevisorCode (length: 50)
		public string Description { get; set; } // Description (length: 500)
		public DateTime? CreateDateTime { get; set; } // CreateDateTime
		public bool? IsDeleted { get; set; }

	}
}
