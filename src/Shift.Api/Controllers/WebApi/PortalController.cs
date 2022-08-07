using Shift.Bussiness;
using Shift.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shift.Api.Controllers.WebApi {

	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class PortalController : YaldaController {

		private readonly IPortalService _portal;
		public PortalController(IPortalService portal) {
			_portal = portal;
		}

		[HttpPost("GetAll")]
		public async Task<IActionResult> GetAll(PortalSearchModel model) {

			if (!ModelState.IsValid) {
				var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

				var errMsgs = string.Join(Environment.NewLine, allErrors);
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var res = await _portal.GetAll(model);

			return Ok(OperationResult<List<PortalViewModel>>.SuccessResult(res.Result, res.TotalCount));
		}

	}
}
