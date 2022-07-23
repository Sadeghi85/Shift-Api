using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness {
	public class ShiftRevisionProblemModel {
		public int Id { get; set; } // Id (Primary key)
		[Required(ErrorMessage =ValidationConstants.ShiftTabletIdRequred)]
		public int? ShiftTabletId { get; set; } // ShiftTabletId

		[Required(ErrorMessage =ValidationConstants.FileNumberRequired)]
		public string FileNumber { get; set; } // FileNumber (length: 50)

		[Required(ErrorMessage =ValidationConstants.FileNameRquired)]
		public string FileName { get; set; } // FileName (length: 500)

		[Required(ErrorMessage =ValidationConstants.ClacketNoRequired)]
		public int? ClacketNo { get; set; } // ClacketNo

		[Required(ErrorMessage =ValidationConstants.ProblemDescriptionRquired)]
		public string ProblemDescription { get; set; } // ProblemDescription (length: 500)
		
		[Required(ErrorMessage =ValidationConstants.RevisorCodeRequired)]
		public string RevisorCode { get; set; } // RevisorCode (length: 50)
		
		[Required(ErrorMessage =ValidationConstants.DescriptionRequired)]
		public string Description { get; set; } // Description (length: 500)
	}
}
