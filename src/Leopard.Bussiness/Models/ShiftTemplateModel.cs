using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness {
	public class ShiftTemplateInputModel {
		[Required(ErrorMessage = ValidationConstants.IdRequired)]
		public int Id { get; set; } // Id (Primary key)
		[Required(ErrorMessage =ValidationConstants.JobIdRquired)]
		public int JobId { get; set; } // JobId
		[Required(ErrorMessage =ValidationConstants.ShiftIdRequired)]
		public int ShiftId { get; set; } // ShiftId
		
	}

	public class ShiftTemplateSearchModel : PagerViewModel {
		public int? Id { get; set; }
		public int? ShiftId { get; set; }
		public int? JobId { get; set; }

		public bool? IsDeleted { get; set; }

	}

	public class ShiftTemplateViewModel {
		public int Id { get; set; }
		public int ShiftId { get; set; }
		public int JobId { get; set; }
		public string? ShiftTitle { get; set; }
		public string? JobTitle { get; set; }
	}
}
