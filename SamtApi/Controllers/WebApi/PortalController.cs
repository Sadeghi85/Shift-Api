using Leopard.Bussiness.Model;
using Leopard.Bussiness.Model.ReturnModel;
using Leopard.Bussiness.Services.Interface;
using Leopard.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SamtApi.Controllers.WebApi {

	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class PortalController : YaldaController {

		private readonly IPortalService _portal;
		public PortalController(IPortalService portal) {
			_portal = portal;
		}


		// GET: api/<PortalController>
		[HttpPost("GetAll")]
		public async Task<IActionResult> GetAll(PortalSearchModel model) {

			var portalId = GetUserPortalId() ?? 0;
			if (portalId > 1) {
				model.PortalId = portalId;
			}

			var res = await _portal.GetAll(model);
			return Ok(OperationResult<List<PortalResult>?>.SuccessResult(res, _portal.GetAllTotalCount()));
		}

	}
}
