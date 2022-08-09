using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shift.Api.Permission;
using Shift.Bussiness;

namespace Shift.Api.Controllers.WebApi {

	
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : YaldaController {


		private readonly IUserService _userService;

		public UserController(IUserService userService) {
			_userService = userService;
		}

		// GET: api/<ShiftTabletController>
		[HttpPost("GetUserInfo")]
		[Authorize]
		public async Task<IActionResult> GetUserInfo() {
			var uInfo = await _userService.GetUserInfoAsync();
			return Ok(uInfo);
		}
	}
}