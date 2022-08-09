using Cheetah.Utilities;
using IdentityModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Shift.Bussiness;
using System.Security.Claims;

namespace Shift.Api.Permission {


	public class PermissionActionFilter : IAsyncAuthorizationFilter {
		private readonly string _name;

		public PermissionActionFilter(string name) {
			_name = name;
		}


		public async Task OnAuthorizationAsync(AuthorizationFilterContext context) {
			//bool isAuthorized = false;
			bool isAuthorized = await MumboJumboFunction(context, _name); // :)

			if (!isAuthorized) {
				//context.Result = new UnauthorizedResult();
				context.Result = new ForbidResult();
			}
		}


		private async Task<bool> MumboJumboFunction(AuthorizationFilterContext context, string name) {

			var user = context.HttpContext.User;
			var userService = context.HttpContext.RequestServices.GetService<IUserService>();

			var ident = user.Identity as ClaimsIdentity;
			var userId = ident?.Claims?.FirstOrDefault(c => c.Type == JwtClaimTypes.Subject)?.Value?.ToInt32();
			if (null == userId) {
				return false;
			}

			return await userService.HasUserPermission(userId.Value, _name);
		}

	}


}
