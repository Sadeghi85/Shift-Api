using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Model {
	public class ShiftModel {
		public int Id { get; set; } // ID (Primary key)
		[Required(ErrorMessage ="عنوان شیفت اجباری است")]
		public string Title { get; set; } // Title (length: 250)

		[Required(ErrorMessage ="شناسه پورتال اجباری است.")]
		public int? PortalId { get; set; } // ProtalId
		[Range(1,2 , ErrorMessage ="شناسه نوع شیفت باید 1-رژی و 2-هماهنگی باشد.") ]
		public int? ShiftType { get; set; } // ShiftType

		[Required(ErrorMessage ="زمان شروع شیفت اجباری است.")]
		public TimeSpan? StartTime { get; set; } // StartTime
		[Required(ErrorMessage ="زمان پایان شیفت اجباری است.")]
		public TimeSpan? EndTime { get; set; } // EndTime
	}
}
