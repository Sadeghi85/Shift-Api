using Cheetah.Utilities;
using IdentityModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shift.Api.Models;
using System.Security.Claims;

namespace Shift.Api.Controllers.WebApi {
	[Route("api/[controller]")]
	[ApiController]
	public class YaldaController : ControllerBase {
		protected int? GetUserId() {
			var ident = User.Identity as ClaimsIdentity;
			return ident.Claims.FirstOrDefault(c => c.Type == JwtClaimTypes.Subject)?.Value?.ToInt32();
		}

		protected int? GetUserPortalId() {
			var ident = User.Identity as ClaimsIdentity;
			return ident.Claims.FirstOrDefault(c => c.Type == "PortalId")?.Value?.ToInt32();
		}
	}
}
