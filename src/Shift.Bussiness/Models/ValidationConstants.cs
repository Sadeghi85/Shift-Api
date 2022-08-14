using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Bussiness {
	public static class ValidationConstants {


		public const string RoleTypeIdRequired = "نوع نقش اجباری است";
		public const string ReportDescriptionRequired = "متن گزارش اجباری است";

		public const string TitleRequired = "عنوان اجباری است";

		public const string IdRequired = "شناسه اجباری است";
		public const string LocationIdRequired = "شناسه لوکیشن اجباری است";

		public const string ShiftTabletIdRequired = "شناسه لوح شیفت اجباری است";
		public const string DescriptionRequired = "توضیحات اجباری است";
		public const string ShiftTabletCrewIdRequired = "شناسه لوح شیفت کارمند اجباری است";
		public const string IsRewardRequred = "نوع پاداش یا جریمه اجباری است 1 پاداش 0 جریمه";
		public const string RewardShiftpercentageRequired = "درصد پاداش یا جریمه اجباری است";
		public const string RewardAmmountRequired = "مقدار پاداش یا جریمه اجباری است";
		
		public const string PortalIdRequired = "شناسه پورتال اجباری است";
		public const string ShiftTypeIdRequired = "شناسه نوع شیفت باید 1)رژی یا 2)هماهنگی باشد";
		public const string StartTimeRequired = "زمان شروع شیفت اجباری است";
		public const string EndTimeRequired = "زمان پایان شیفت اجباری است";
		public const string FileNumberRequired = "شماره فایل اجباری است";
		public const string FileNameRquired = "نام فایل اجباری است";
		public const string ClacketNoRequired = "کلاکت اجباری است";
		public const string ProblemDescriptionRquired = "مورد اشکال اجباری است";
		public const string ReviewerCodeRequired = "کد بازبین اجباری است";
		public const string AgenetIdRequired = "شناسه کارمند اجباری است";
		public const string JobIdRequired = "عنوان شغلی اجباری است";
		
		public const string ShiftIdRequired = "شناسه شیفت اجباری است";
		public const string ShiftDateRequired = "تاریخ لوح شیفت اجباری است";
		public const string ProductionTypeIdRequired = "شناسه نوع تولید شیفت اجباری است";
		public const string ProgramTitleRequired = "نام برنامه اجباری است";
		public const string ReplacedProgramTitleRequired = "نام برنامه جایگزین شونده اجباری است";
		public const string HasLiveProgramsRequired = "آیا شیفت دارای برنامه زنده است؟";
		public const string RequiredShiftRequired = "تعداد شیفت های موظفی اجباری است";
		public const string CooperationTypeIdRequired = "نوع همکاری اجباری است";
		public const string UnrequiredShiftPaymentRequired = "مبلغ شیفت غیر موظفی اجباری است";


	}
}
