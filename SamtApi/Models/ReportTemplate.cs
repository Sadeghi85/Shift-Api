namespace SamtApi.Models {
	public class ReportTemplate {

		public string PersianDate { get; set; }
		public string DayName { get; set; }

		public List<PersonTemplate> _personTemplates { get; set; }=new List<PersonTemplate>();
		
	}

	public class PersonTemplate {
		public string Name { get; set; }
		public string ResourceName { get; set; }	
		public string Shift { get; set; }
	}

}
