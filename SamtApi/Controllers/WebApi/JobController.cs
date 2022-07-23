using Leopard.Bussiness;
using Leopard.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SamtApi.Controllers.WebApi {
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class JobController : YaldaController {


		private readonly IJobService _jobService;


		public JobController(IJobService resourceTypeService) {
			_jobService = resourceTypeService;
		}

		// GET: api/<ResourceTypeController>
		[HttpPost("GetAll")]
		public async Task<IActionResult> GetAll(JobSearchModel model) {


			var res = await _jobService.GetAll(model, out var resCount);

			return Ok(OperationResult<List<JobViewModel>>.SuccessResult(res, resCount));

		}


	}
}
