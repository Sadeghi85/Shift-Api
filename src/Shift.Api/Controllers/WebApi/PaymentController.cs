
using Shift.Bussiness;
using Shift.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cheetah.Utilities;

namespace Shift.Api.Controllers.WebApi {
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class PaymentController : YaldaController {

		private readonly IPaymentService _paymentService;

		public PaymentController(IPaymentService paymentService) {
			_paymentService = paymentService;
		}

		// GET: api/<ResourceTypeController>
		[HttpPost("GetAll")]
		public async Task<IActionResult> GetAll(PaymentSearchModel model) {

			if (!ModelState.IsValid) {
				var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

				var errMsgs = string.Join(Environment.NewLine, allErrors);
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var res = await _paymentService.GetAll(model);

			return Ok(OperationResult<List<PaymentViewModel>>.SuccessResult(res.Result, res.TotalCount));

		}

		[HttpPost("Update")]
		public async Task<OkObjectResult> Update(PaymentInputModel model) {
			if (!ModelState.IsValid) {
				var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

				var errMsgs = string.Join(Environment.NewLine, allErrors);
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var res = await _paymentService.Update(model);

			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));

		}


	}
}
