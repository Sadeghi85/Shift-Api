using Shift.Bussiness;
using Shift.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cheetah.Utilities;

namespace Shift.Api.Controllers.WebApi {
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class JobController : YaldaController {

		private readonly IJobService _jobService;

		public JobController(IJobService jobService) {
			_jobService = jobService;
		}

		// GET: api/<ResourceTypeController>
		[HttpPost("GetAll")]
		public async Task<IActionResult> GetAll(JobSearchModel model) {

			if (!ModelState.IsValid) {
				var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

				var errMsgs = string.Join(Environment.NewLine, allErrors);
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var res = await _jobService.GetAll(model);

			return Ok(OperationResult<List<JobViewModel>>.SuccessResult(res.Result, res.TotalCount));

		}


	}
}
