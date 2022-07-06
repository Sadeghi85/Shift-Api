using Leopard.Bussiness.Model;
using Leopard.Bussiness.Model.ReturnModel;
using Leopard.Bussiness.Services.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SamtApi.Controllers.WebApi {
	[Route("api/[controller]")]
	[ApiController]
	public class ShiftEmploymentDetailController : YaldaController {

		private IShiftEmploymentDetailService _shiftEmploymentDetail;


		public ShiftEmploymentDetailController(IShiftEmploymentDetailService shiftEmploymentDetail) {
			_shiftEmploymentDetail = shiftEmploymentDetail;
		}


		[HttpPost("GetAll")]
		public async Task<IActionResult> GetAll(ShiftEmploymentDetailSearchModel model) {

			var portalId = GetUserPortalId() ?? 0;
			if (portalId > 1) {
				model.PortalId = portalId;
			}

			List<ShiftEmploymentDetailResult>? res =await _shiftEmploymentDetail.GetAll(model);
			return Ok(OperationResult<List<ShiftEmploymentDetailResult>?>.SuccessResult(res, _shiftEmploymentDetail.GetAllCount()));

		}
		[HttpPost("Register")]
		public async Task<IActionResult> Register(ShiftEmploymentDetailModel model) {

			if (!ModelState.IsValid) {
				var errors = ModelState.Select(x => x.Value.Errors)
						   .Where(y => y.Count > 0)
						   .ToList();


				var errMsgs = string.Join(",", errors[0].Select(pp => pp.ErrorMessage));
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var res = await _shiftEmploymentDetail.Register(model);
			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));

		}

		[HttpPost("Update")]
		public async Task<IActionResult> Update(ShiftEmploymentDetailModel model) {
			if (!ModelState.IsValid) {
				var errors = ModelState.Select(x => x.Value.Errors)
						   .Where(y => y.Count > 0)
						   .ToList();


				var errMsgs = string.Join(",", errors[0].Select(pp => pp.ErrorMessage));
				return Ok(OperationResult<string>.FailureResult(errMsgs));
			}

			var res = await _shiftEmploymentDetail.Update(model);
			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));

		}

		[HttpPost("Delete")]
		public async Task<IActionResult> Delete(ShiftEmploymentDetailModel model) {

			var res = await _shiftEmploymentDetail.Delete(model);
			if (res.Success) {
				return Ok(OperationResult<string>.SuccessResult(res.Message));
			}
			return Ok(OperationResult<string>.FailureResult(res.Message));
		}
	}
}
