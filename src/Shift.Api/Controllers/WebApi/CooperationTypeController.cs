using Shift.Bussiness;
using Shift.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cheetah.Utilities;

namespace Shift.Api.Controllers.WebApi {

	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class CooperationTypeController : YaldaController {

		private readonly ICooperationTypeService  _cooperationTypeService;
		public CooperationTypeController(ICooperationTypeService cooperationTypeService) {
			_cooperationTypeService = cooperationTypeService;
		}

		[HttpPost("GetAll")]
		public async Task<IActionResult> GetAll(CooperationTypeSearchModel model) {

			if (!ModelState.IsValid) {
				var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

				var errMsgs = string.Join(Environment.NewLine, allErrors);
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var res = await _cooperationTypeService.GetAll(model);

			return Ok(OperationResult<List<CooperationTypeViewModel>>.SuccessResult(res.Result, res.TotalCount));
		}

	}
}
