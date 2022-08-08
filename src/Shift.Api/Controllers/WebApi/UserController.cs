using Microsoft.AspNetCore.Mvc;
using Shift.Bussiness;

namespace Shift.Api.Controllers.WebApi {
	public class UserController : YaldaController {


		private readonly IUserService _userService;

		public UserController(IUserService userService) {
			_userService = userService;
		}

		// GET: api/<ShiftTabletController>
		[HttpPost("GetUserInfo")]
		public async Task<IActionResult> GetUserInfo() {
			var uInfo = _userService.GetUserInfo();
			return Ok(uInfo);
		}
	}
}