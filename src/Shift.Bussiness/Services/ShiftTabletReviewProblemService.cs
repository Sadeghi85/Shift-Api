using Shift.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text.Json;
using System.Text.Json.Serialization;
using OfficeOpenXml;
using PdfRpt.Core.Contracts;

namespace Shift.Bussiness {
	public class ShiftTabletReviewProblemService : ServiceBase, IShiftTabletReviewProblemService {

		private readonly IShiftShiftTabletStore _shiftShiftTabletStore;
		private readonly IShiftShiftTabletReviewProblemStore _shiftShiftTabletReviewProblemStore;

		public ShiftTabletReviewProblemService(IPrincipal iPrincipal, IShiftShiftTabletStore shiftShiftTabletStore, IShiftLogStore shiftLogStore, IShiftShiftTabletReviewProblemStore shiftShiftTabletReviewProblemStore) : base(iPrincipal, shiftLogStore) {

			_shiftShiftTabletStore = shiftShiftTabletStore;
			_shiftShiftTabletReviewProblemStore = shiftShiftTabletReviewProblemStore;
		}


		public async Task<StoreViewModel<ShiftTabletReviewProblemViewModel>> GetAll(ShiftTabletReviewProblemSearchModel model) {

			var getAllExpressions = new List<Expression<Func<ShiftShiftTabletReviewProblem, bool>>>();

			getAllExpressions.Add(pp => pp.ShiftShiftTablet.IsDeleted == false);

			if (CurrentUserPortalId == 1) {
				//if (model.PortalId > 0) {
				//	getAllShiftShiftJobTemplateExpressions.Add(x => x.PortalId == model.PortalId);
				//}
			} else {
				getAllExpressions.Add(x => x.ShiftShiftTablet.ShiftShift.PortalId == CurrentUserPortalId);
			}

			if (model.Id > 0) {
				getAllExpressions.Add(x => x.Id == model.Id);
			}
			if (model.ShiftTabletId > 0) {
				getAllExpressions.Add(x => x.ShiftTabletId == model.ShiftTabletId);
			}
			if (model.RoleTypeId > 0) {
				getAllExpressions.Add(x => x.RoleTypeId == model.RoleTypeId);
			}
			if (model.IsDeleted != null) {
				getAllExpressions.Add(x => x.IsDeleted == model.IsDeleted);
			}

			var res = await _shiftShiftTabletReviewProblemStore.GetAllWithPagingAsync(getAllExpressions,
				x => new ShiftTabletReviewProblemViewModel {
					Id = x.Id,
					ShiftTabletId = x.ShiftTabletId,
					RoleTypeId = x.RoleTypeId,
					Description = x.Description,
					ClacketNo = x.ClacketNo,
					FileNumber = x.FileNumber,
					ProblemDescription = x.ProblemDescription,
					ProgramTitle = x.ProgramTitle,
					ReviewerCode = x.ReviewerCode,

				},
				model.OrderKey, model.Desc, model.PageSize, model.PageNo);

			return res;
		}
		public async Task<BaseResult> Create(ShiftTabletReviewProblemInputModel model) {

			try {

				var foundShiftTablet = await _shiftShiftTabletStore.FindByIdAsync(x => x.Id == model.ShiftTabletId && x.IsDeleted == false);
				if (null == foundShiftTablet) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه لوح شیفت یافت نشد";

					return BaseResult;
				}

				if (CurrentUserPortalId > 1 && CurrentUserPortalId != foundShiftTablet.ShiftShift.PortalId) {
					BaseResult.Success = false;
					BaseResult.Message = "شما به این قسمت دسترسی ندارید";
					return BaseResult;
				}

				var shiftShiftTabletReviewProblem = new ShiftShiftTabletReviewProblem {
					RoleTypeId = model.RoleTypeId,
					ShiftTabletId = model.ShiftTabletId,
					Description = model.Description,
					ClacketNo = model.ClacketNo,
					FileNumber = model.FileNumber,
					ProblemDescription = model.ProblemDescription,
					ProgramTitle = model.ProgramTitle,
					ReviewerCode = model.ReviewerCode,

					IsDeleted = false
				};

				_shiftShiftTabletReviewProblemStore.Insert(shiftShiftTabletReviewProblem);

				var res = await _shiftShiftTabletReviewProblemStore.SaveChangesAsync();

				if (res < 0) {
					BaseResult = await LogError(new Exception("Failed to insert shiftShiftTabletReviewProblem\r\n\r\n" + JsonSerializer.Serialize(shiftShiftTabletReviewProblem, new JsonSerializerOptions() {
						ReferenceHandler = ReferenceHandler.IgnoreCycles,
						WriteIndented = true
					})));
					return BaseResult;
				}

			} catch (Exception ex) {

				BaseResult = await LogError(ex);
			}

			return BaseResult;
		}

		public async Task<BaseResult> Update(ShiftTabletReviewProblemInputModel model) {

			try {

				var foundShiftTablet = await _shiftShiftTabletStore.FindByIdAsync(x => x.Id == model.ShiftTabletId && x.IsDeleted == false);
				if (null == foundShiftTablet) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه لوح شیفت یافت نشد";

					return BaseResult;
				}

				if (CurrentUserPortalId > 1 && CurrentUserPortalId != foundShiftTablet.ShiftShift.PortalId) {
					BaseResult.Success = false;
					BaseResult.Message = "شما به این قسمت دسترسی ندارید";
					return BaseResult;
				}

				var foundShiftTabletReviewProblem = await _shiftShiftTabletReviewProblemStore.FindByIdAsync(x => x.Id == model.Id && x.IsDeleted == false && x.ShiftTabletId == model.ShiftTabletId && x.RoleTypeId == model.RoleTypeId);

				if (null == foundShiftTabletReviewProblem) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه اشکالات بازبینی لوح شیفت یافت نشد";

					return BaseResult;
				}

				foundShiftTabletReviewProblem.Description = model.Description;
				foundShiftTabletReviewProblem.ClacketNo = model.ClacketNo;
				foundShiftTabletReviewProblem.FileNumber = model.FileNumber;
				foundShiftTabletReviewProblem.ProblemDescription = model.ProblemDescription;
				foundShiftTabletReviewProblem.ProgramTitle = model.ProgramTitle;
				foundShiftTabletReviewProblem.ReviewerCode = model.ReviewerCode;


				_shiftShiftTabletReviewProblemStore.Update(foundShiftTabletReviewProblem);

				var res = await _shiftShiftTabletReviewProblemStore.SaveChangesAsync();

				if (res < 0) {
					BaseResult = await LogError(new Exception("Failed to update shiftShiftTabletReviewProblem\r\n\r\n" + JsonSerializer.Serialize(foundShiftTabletReviewProblem, new JsonSerializerOptions() {
						ReferenceHandler = ReferenceHandler.IgnoreCycles,
						WriteIndented = true
					})));
					return BaseResult;
				}

			} catch (Exception ex) {

				BaseResult = await LogError(ex);
			}

			return BaseResult;
		}

		public async Task<BaseResult> Delete(int id) {
			try {

				var found = await _shiftShiftTabletReviewProblemStore.FindByIdAsync(id);

				if (found == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه مورد نظر یافت نشد";
					return BaseResult;
				}

				if (CurrentUserPortalId > 1 && CurrentUserPortalId != found.ShiftShiftTablet.ShiftShift.PortalId) {
					BaseResult.Success = false;
					BaseResult.Message = "شما به این قسمت دسترسی ندارید";
					return BaseResult;
				}

				found.IsDeleted = true;

				_shiftShiftTabletReviewProblemStore.Update(found);

				var res = await _shiftShiftTabletReviewProblemStore.SaveChangesAsync();

				if (res < 0) {
					BaseResult = await LogError(new Exception("Failed to delete shiftShiftTabletReviewProblem\r\n\r\n" + JsonSerializer.Serialize(found, new JsonSerializerOptions() {
						ReferenceHandler = ReferenceHandler.IgnoreCycles,
						WriteIndented = true
					})));
					return BaseResult;
				}

			} catch (Exception ex) {

				BaseResult = await LogError(ex);
			}

			return BaseResult;

		}

		public async Task<BaseResult> Delete(string ids) {
			try {

				var _ids = JsonSerializer.Deserialize<List<int>>(ids);

				var foundReviewProblems = await _shiftShiftTabletReviewProblemStore.GetAllAsync(x => _ids.Contains(x.Id), x => x, x => x.Id);

				if (foundReviewProblems.TotalCount == 0) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه مورد نظر یافت نشد";
					return BaseResult;
				}

				foreach (var found in foundReviewProblems.Result) {
					if (CurrentUserPortalId > 1 && CurrentUserPortalId != found.ShiftShiftTablet.ShiftShift.PortalId) {
						BaseResult.Success = false;
						BaseResult.Message = "شما به این قسمت دسترسی ندارید";
						return BaseResult;
					}

					found.IsDeleted = true;

					_shiftShiftTabletReviewProblemStore.Update(found);

				}

				var res = await _shiftShiftTabletReviewProblemStore.SaveChangesAsync();

				if (res < 0) {
					BaseResult = await LogError(new Exception("Failed to delete shiftShiftTabletReviewProblem\r\n\r\n" + JsonSerializer.Serialize(foundReviewProblems.Result, new JsonSerializerOptions() {
						ReferenceHandler = ReferenceHandler.IgnoreCycles,
						WriteIndented = true
					})));
					return BaseResult;
				}

			} catch (Exception ex) {

				BaseResult = await LogError(ex);
			}

			return BaseResult;

		}
	}
}
