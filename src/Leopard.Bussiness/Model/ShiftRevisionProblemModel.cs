using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Model {
	internal class ShiftRevisionProblemModel {
		public int Id { get; set; } // Id (Primary key)
		[Required(ErrorMessage ="شناسه لوح شیفت مورد نیاز است.")]
		public int? ShiftTabletId { get; set; } // ShiftTabletId

		[Required(ErrorMessage ="شماره فایل اجباری است.")]
		public string FileNumber { get; set; } // FileNumber (length: 50)

		[Required(ErrorMessage ="نام فایل اجباری است.")]
		public string FileName { get; set; } // FileName (length: 500)

		[Required(ErrorMessage ="کلاکت اجباری است.")]
		public int? ClacketNo { get; set; } // ClacketNo

		[Required(ErrorMessage ="مورد اشکال اجباری است.")]
		public string ProblemDescription { get; set; } // ProblemDescription (length: 500)
		
		[Required(ErrorMessage ="کد بازبین اجباری است.")]
		public string RevisorCode { get; set; } // RevisorCode (length: 50)
		
		[Required(ErrorMessage ="توضیحات اجباری است.")]
		public string Description { get; set; } // Description (length: 500)
	}
}
