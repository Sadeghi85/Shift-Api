namespace Shift.Bussiness {
	public class ReportTemplate {

		public string PersianDate { get; set; }
		public string DayName { get; set; }

		//public List<PersonTemplate> _personTemplates { get; set; }=new List<PersonTemplate>();
		public  List<TheShift> Shifts { get; set; }
		
	}

	public class TheShift {
		public string ShiftName { get; set; }	
		public List<ThePerson> ThePersonList { get; set; }=new List<ThePerson>();
	}

	public class ThePerson {
		public string Name { get; set; }
		public string ResourceName { get; set; }
	}

	public class PersonTemplate {
		public string Name { get; set; }
		public string ResourceName { get; set; }	
		public string Shift { get; set; }
	}

}
