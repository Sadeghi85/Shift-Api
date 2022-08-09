using Microsoft.AspNetCore.Mvc;

namespace Shift.Api.Permission {

	public class PermissionAttribute : TypeFilterAttribute {

		//public string Name { get; }


		public PermissionAttribute(string name) : base(typeof(PermissionActionFilter)) {
			Arguments = new object[] { name };
		}
	}

}
