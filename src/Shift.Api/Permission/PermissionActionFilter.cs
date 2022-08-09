using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace Shift.Api.Permission {


	public class PermissionActionFilter : IAsyncAuthorizationFilter {
		private readonly string _name;

		public PermissionActionFilter(string name) {
			_name = name;
		}


		public async Task OnAuthorizationAsync(AuthorizationFilterContext context) {
			//bool isAuthorized = false;
			bool isAuthorized = await MumboJumboFunction(context.HttpContext.User, _name); // :)

			if (!isAuthorized) {
				//context.Result = new UnauthorizedResult();
				context.Result = new ForbidResult();
			}
		}


		private async Task<bool> MumboJumboFunction(ClaimsPrincipal user, string name) {
			throw new NotImplementedException();
		}

	}


}
