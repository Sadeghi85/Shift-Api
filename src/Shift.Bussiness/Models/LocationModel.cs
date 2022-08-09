using FluentValidation;
using Shift.Bussiness;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Bussiness {
	public class LocationInputModel {

		[Required(ErrorMessage = ValidationConstants.IdRequired)]
		public int Id { get; set; }
		[Required(ErrorMessage = ValidationConstants.TitleRequired)]
		public string? Title { get; set; }// Title (length: 250)
	}


	public class LocationInputModelValidator : AbstractValidator<LocationInputModel> {
		public LocationInputModelValidator() {
			RuleFor(x => x.Id).NotEmpty().WithMessage(ValidationConstants.IdRequired);
			RuleFor(x => x.Title).NotEmpty().NotNull().MinimumLength(1).WithMessage(ValidationConstants.TitleRequired);
		}
	}



	public class LocationSearchModel : PagerViewModel {

		public int? Id { get; set; }
		public string? Title { get; set; }
		public bool? IsDeleted { get; set; }
	}

	public class LocationViewModel {
		public int Id { get; set; }
		public string? Title { get; set; }
		public bool? IsDeleted { get; set; }
	}
}
