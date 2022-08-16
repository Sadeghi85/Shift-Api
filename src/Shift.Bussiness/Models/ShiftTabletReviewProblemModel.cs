using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Bussiness {
	public class ShiftTabletReviewProblemInputModel {
		[Required(ErrorMessage = ValidationConstants.IdRequired)]
		public int Id { get; set; } // ID (Primary key)
		[Required(ErrorMessage = ValidationConstants.ShiftTabletIdRequired)]
		public int ShiftTabletId { get; set; } // ShiftTabletId
		[Required(ErrorMessage = ValidationConstants.RoleTypeIdRequired)]
		public int RoleTypeId { get; set; }
		[Required(ErrorMessage = ValidationConstants.FileNumberRequired)]
		public string FileNumber { get; set; }
		[Required(ErrorMessage = ValidationConstants.TitleRequired)]
		public string ProgramTitle { get; set; }
		[Required(ErrorMessage = ValidationConstants.ClacketNoRequired)]
		public int ClacketNo { get; set; }
		[Required(ErrorMessage = ValidationConstants.DescriptionRequired)]
		public string ProblemDescription { get; set; }
		[Required(ErrorMessage = ValidationConstants.ReviewerCodeRequired)]
		public string ReviewerCode { get; set; }
		public string? Description { get; set; }
	}

	public class ShiftTabletReviewProblemSearchModel : PagerViewModel {
		public int? Id { get; set; }
		public int? ShiftTabletId { get; set; } // ShiftTabletId
		public int? RoleTypeId { get; set; }
		public bool? IsDeleted { get; set; }
	}

	public class ShiftTabletReviewProblemViewModel {

		public int Id { get; set; }
		public int ShiftTabletId { get; set; }
		public int RoleTypeId { get; set; }
		public string? Description { get; set; }
		public string? ReviewerCode { get; set; }
		public string? ProblemDescription { get; set; }
		public int ClacketNo { get; set; }
		public string? ProgramTitle { get; set; }
		public string? FileNumber { get; set; }

	}

}
