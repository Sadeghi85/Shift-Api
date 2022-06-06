using Leopard.Bussiness;
using Leopard.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using ILogger = Serilog.ILogger;

namespace Leopard.Api.Controllers {
	
	[ApiController]
	[Route("api/v{v:apiVersion}/[controller]")]
	[ApiVersion("1.0")]
	//[Authorize]
	[AllowAnonymous]
	public class DefaultController : ControllerBase {
		private readonly ILogger _logger;
		private readonly IDefaultService _defaultService;

		public DefaultController(ILogger logger, IDefaultService defaultService) {
			_logger = logger;
			_defaultService = defaultService;
		}

		[HttpGet]
		[Route("GetPortals")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OperationResult<string>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesDefaultResponseType]
		public async Task<IActionResult> GetPortals() {
			if (!ModelState.IsValid) {
				return Ok(OperationResult<string>.FailureResult(""));
			}

			var values = await _defaultService.GetPortalsAsync();

			if (values.Count > 0) {
				return Ok(OperationResult<List<PortalViewModel>>.SuccessResult(values, values.Count));
			}

			return Ok(OperationResult<string>.FailureResult(""));
		}
		
	}
}