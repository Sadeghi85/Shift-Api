using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Model {
	public class ShiftTabletModel {

		public int Id { get; set; } // ID (Primary key)

		[Required(ErrorMessage ="شناسه شیفت اجباری است.")]
		public int ShiftId { get; set; } // ShifID

		[Required(ErrorMessage ="تاریخ لوح شیفت اجباری است.")]
		public DateTime ShiftDate { get; set; } // ShiftDate

		[Required(ErrorMessage ="شناسه نوع تولید شیفت اجباری است.")]
		public int ProductionTypeId { get; set; } // ProductionTypeId

		public int? ShiftWorthPercent { get; set; } // ShiftWorthPercent
		public TimeSpan? ShiftTime { get; set; } // ShiftTime
	}
}
