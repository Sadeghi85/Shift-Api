using Leopard.Bussiness.Model;
using Leopard.Bussiness.Model.ReturnModel;
using Leopard.Bussiness.Services.Interface;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Services {
	public class ShiftService : BaseService, IShiftService {

		private readonly IShiftShiftStore _shiftShiftStore;
		private readonly IPortalStore _portalStore;
		private readonly IShiftLogStore _shiftLogStore;
		private readonly IShiftNeededResourceStore _shiftNeededResourceStore;
		private readonly ISamtResourceTypeStore _samtResourceTypeStore;

		private List<Expression<Func<ShiftShift, bool>>> GetAllExpressions { get; set; } = new List<Expression<Func<ShiftShift, bool>>>();

		private List<Expression<Func<ShiftNeededResource, bool>>> GetAllShiftNeededResourceExpressions { get; set; } = new List<Expression<Func<ShiftNeededResource, bool>>>();

		public ShiftService(IShiftShiftStore shiftShiftStore, IPortalStore portalStore, IShiftLogStore shiftLogStore, IShiftNeededResourceStore shiftNeededResourceStore, ISamtResourceTypeStore samtResourceTypeStore) {
			_shiftShiftStore = shiftShiftStore;
			_portalStore = portalStore;
			_shiftLogStore = shiftLogStore;
			_shiftNeededResourceStore = shiftNeededResourceStore;
			_samtResourceTypeStore = samtResourceTypeStore;
		}




		public async Task<BaseResult> Delete(ShiftModel model) {

			try {
				var found = _shiftShiftStore.FindById(model.Id);
				if (found == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه مورد نظر شناسایی نشد.";
				} else {
					found.IsDeleted = true;
					var res = await _shiftShiftStore.Update(found);
				}
			} catch (Exception ex) {

				ShiftLog shiftLog = new ShiftLog { Message = ex.Message + " " + ex.InnerException?.Message ?? ex.Message };

				//_shiftLogStore.ResetContext();

				var ss = await _shiftLogStore.InsertAsync(shiftLog);
				BaseResult.Success = false;
				base.BaseResult.Message = $"خطای سیستمی شماره {shiftLog.Id} لطفای به مدیر سیستم اطلاع دهید.";
			}

			return BaseResult;

		}

		public List<ShiftShift> FindByPortalId(int portalId) {

			List<ShiftShift>? res = _shiftShiftStore.GetAll().Where(pp => pp.PortalId == portalId).ToList();

			return res;

		}

		public Task<List<ShiftResultModel>> GetAll(ShiftSearchModel model) {



			if (model.PortalId != 0) {
				GetAllExpressions.Add(pp => pp.PortalId == model.PortalId);
			}
			if (!string.IsNullOrWhiteSpace(model.Title)) {
				GetAllExpressions.Add(pp => pp.Title.Contains(model.Title));
			}
			if (model.ShiftType != 0) {
				GetAllExpressions.Add(pp => pp.ShiftType == model.ShiftType);
			}
			if (model.Id != 0) {
				GetAllExpressions.Add(pp => pp.Id == model.Id);
			}
			if (model.IsDeleted != null) {
				GetAllExpressions.Add(pp => pp.IsDeleted == model.IsDeleted.Value);
			}

			GetAllExpressions.Add(pp => pp.IsDeleted != true);
			Task<List<ShiftResultModel>>? res = _shiftShiftStore.GetAllWithPagingAsync(GetAllExpressions, pp => new ShiftResultModel { Id = pp.Id, Title = pp.Title, PortalTitle = pp.Portal.Title, PortalId = pp.PortalId, EndTime = pp.EndTime, StartTime = pp.StartTime, ShiftTypeId = pp.ShiftType, ShiftTypeTitle = GetShiftTypeTitleByShiftTypeId(pp.ShiftType) }, pp => pp.Id, model.PageSize, model.PageNo, "desc");



			//IQueryable<ShiftShift>? res = _shiftShiftStore.GetAll().Where(pp => pp.Title.Contains(model.Title) && pp.PortalId == model.PortalId).Skip(model.PageNo*model.PageSize).Take(model.PageSize);
			//if (model.desc == false) {

			//	res = res.OrderBy(pp => pp.Title);
			//} else {
			//	res = res.OrderByDescending(pp => pp.Title);
			//}

			return res;
		}

		private static string GetShiftTypeTitleByShiftTypeId(int? ShiftTypeId) {
			switch (ShiftTypeId) {
				case 1:
					return "رژی";
					break;
				case 2:
					return "هماهنگی";
					break;
				default: return "نامشخص";

			}
		}

		public int GetAllCount() {
			var res = _shiftShiftStore.TotalCount(GetAllExpressions);
			return res;
		}


		public IQueryable<ShiftShift> GetByPortalId(int portalId) {
			//throw new NotImplementedException();
			IQueryable<ShiftShift>? res = _shiftShiftStore.GetAll().Where(pp => pp.PortalId == portalId);
			return res;

		}

		public async Task<BaseResult> Register(ShiftModel model) {

			var foundPortal = _portalStore.FindById(model.PortalId);
			if (null == foundPortal) {
				BaseResult.Success = false;
				BaseResult.Message = "شناسه پورتال شناسایی نشد.";

				return BaseResult;
			}

			try {

				var found = _shiftShiftStore.GetAll().Any(x => x.Title == model.Title);
				if (found) {
					BaseResult.Success = false;
					BaseResult.Message = "نام انتخاب شده برای شیفت تکراری است.";

					return BaseResult;
				} 

				found = _shiftShiftStore.CheckTimeOverlap(0, model.PortalId, model.ShiftType, model.StartTime, model.EndTime);
				if (found) {
					BaseResult.Success = false;
					BaseResult.Message = "بازه زمانی انتخاب شده با موارد ثبت شده تداخل دارد.";

					return BaseResult;
				}



				ShiftShift shiftShift = new ShiftShift { Title = model.Title, PortalId = model.PortalId, ShiftType = model.ShiftType, StartTime = model.StartTime, EndTime = model.EndTime, IsDeleted = false };

				await _shiftShiftStore.InsertAsync(shiftShift);

				
			} catch (Exception ex) {

				ShiftLog shiftLog = new ShiftLog { Message = ex.Message + Environment.NewLine + ex.InnerException?.Message + Environment.NewLine + ex.StackTrace ?? "" };

				//_shiftLogStore.ResetContext();

				await _shiftLogStore.InsertAsync(shiftLog);
				BaseResult.Success = false;
				base.BaseResult.Message = $"خطای سیستمی شماره {shiftLog.Id} لطفا به مدیر سیستم اطلاع دهید.";

				return BaseResult;
			}


			return BaseResult;

		}

		private bool IsInShiftType(int shiftType) {
			List<int> shiftTypes = new List<int>() { 1, 2 };
			var res = shiftTypes.Contains(shiftType);
			return res;
		}

		public async Task<BaseResult> Update(ShiftModel model) {

			try {
				var foundShift = _shiftShiftStore.FindById(model.Id);
				
				if (null == foundShift) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه مورد نظر جستجو نشد.";

					return BaseResult;
				}

				var foundPortal = _portalStore.FindById(model.PortalId);
				if (null == foundPortal) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه پورتال شناسایی نشد.";

					return BaseResult;
				}

				var found = _shiftShiftStore.GetAll().Any(x => x.Title == model.Title && x.Id != model.Id);
				if (found) {
					BaseResult.Success = false;
					BaseResult.Message = "نام انتخاب شده برای شیفت تکراری است.";

					return BaseResult;
				}

				found = _shiftShiftStore.CheckTimeOverlap(model.Id, model.PortalId, model.ShiftType, model.StartTime, model.EndTime);
				if (found) {
					BaseResult.Success = false;
					BaseResult.Message = "بازه زمانی انتخاب شده با موارد ثبت شده تداخل دارد.";

					return BaseResult;
				}

				foundShift.Title = model.Title;
				foundShift.StartTime = model.StartTime;
				foundShift.EndTime = model.EndTime;
				foundShift.ShiftType = model.ShiftType;
				foundShift.PortalId = model.PortalId;
				await _shiftShiftStore.Update(foundShift);

				
			} catch (Exception ex) {

				ShiftLog shiftLog = new ShiftLog { Message = ex.Message + Environment.NewLine + ex.InnerException?.Message + Environment.NewLine + ex.StackTrace ?? "" };

				//_shiftLogStore.ResetContext();

				await _shiftLogStore.InsertAsync(shiftLog);
				BaseResult.Success = false;
				base.BaseResult.Message = $"خطای سیستمی شماره {shiftLog.Id} لطفا به مدیر سیستم اطلاع دهید.";

				return BaseResult;
			}
			return BaseResult;
		}

		public async Task<BaseResult> RegisterShiftResource(ShiftNeededResourceModel model) {


			try {
				var foundResourceShift = _shiftNeededResourceStore.GetAll().Any(pp => pp.ShiftId == model.ShiftId && pp.ResourceTypeId == model.ResourceTypeId);
				var foundShift = _shiftShiftStore.FindById(model.ShiftId);
				var foundResource = _samtResourceTypeStore.FindById(model.ResourceTypeId);

				if (foundResourceShift) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه سمت برای شیفت قبلا ثبت شده است.";
				} else if (foundResource == null) {
					BaseResult.Success = false;
					BaseResult.Message = "سمت مورد نظر یافت نشد.";

				} else if (foundShift == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شیفت مورد نظر یافت نشد.";
				} else {
					await _shiftNeededResourceStore.InsertAsync(new ShiftNeededResource {
						IsDeleted = false,
						ResourceTypeId = model.ResourceTypeId,
						ShiftId = model.ShiftId
					});
				}
			} catch (Exception ex) {

				ShiftLog shiftLog = new ShiftLog { Message = ex.Message + " " + ex.InnerException?.Message ?? ex.Message };

				//_shiftLogStore.ResetContext();

				var ss = await _shiftLogStore.InsertAsync(shiftLog);
				BaseResult.Success = false;
				base.BaseResult.Message = $"خطای سیستمی شماره {shiftLog.Id} لطفای به مدیر سیستم اطلاع دهید.";
			}
			return BaseResult;
		}

		public async Task<BaseResult> UpdateShiftResource(ShiftNeededResourceModel model) {

			try {
				var founded = _shiftNeededResourceStore.FindById(model.Id);
				var foundResourceShift = _shiftNeededResourceStore.GetAll().Any(pp => pp.ShiftId == model.ShiftId && pp.ResourceTypeId == model.ResourceTypeId);
				var foundShift = _shiftShiftStore.FindById(model.ShiftId);
				var foundResource = _samtResourceTypeStore.FindById(model.ResourceTypeId);

				if (foundResourceShift) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه سمت برای شیفت قبلا ثبت شده است.";
				} else if (foundResource == null) {
					BaseResult.Success = false;
					BaseResult.Message = "سمت مورد نظر یافت نشد.";

				} else if (foundShift == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شیفت مورد نظر یافت نشد.";
				} else if (founded == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه مورد نظر یافت نشد.";
				} else {
					founded.ShiftId = model.ShiftId;
					founded.ResourceTypeId = model.ResourceTypeId;
					await _shiftNeededResourceStore.Update(founded);
				}
			} catch (Exception ex) {

				ShiftLog shiftLog = new ShiftLog { Message = ex.Message + " " + ex.InnerException?.Message ?? ex.Message };

				//_shiftLogStore.ResetContext();

				var ss = await _shiftLogStore.InsertAsync(shiftLog);
				BaseResult.Success = false;
				base.BaseResult.Message = $"خطای سیستمی شماره {shiftLog.Id} لطفای به مدیر سیستم اطلاع دهید.";
			}

			return BaseResult;
		}

		public async Task<BaseResult> DeleteShiftResource(ShiftNeededResourceModel model) {

			try {
				var founded = _shiftNeededResourceStore.FindById(model.Id);


				if (founded == null) {
					BaseResult.Success = false;
					BaseResult.Message = "شناسه مورد نظر یافت نشد.";
				} else {
					founded.IsDeleted = true;

					await _shiftNeededResourceStore.Update(founded);
				}
			} catch (Exception ex) {

				ShiftLog shiftLog = new ShiftLog { Message = ex.Message + " " + ex.InnerException?.Message ?? ex.Message };

				//_shiftLogStore.ResetContext();

				var ss = await _shiftLogStore.InsertAsync(shiftLog);
				BaseResult.Success = false;
				base.BaseResult.Message = $"خطای سیستمی شماره {shiftLog.Id} لطفای به مدیر سیستم اطلاع دهید.";
			}

			return BaseResult;
		}

		public async Task< List<ShiftNeededResourcesResult>?> GetAllShiftNeededResources(ShiftNeededResourcesSearchModel model) {

			if (model.ShiftId != 0) {
				GetAllShiftNeededResourceExpressions.Add(pp => pp.ShiftId == model.ShiftId);
			}
			if (model.ResourceTypeId != 0) {
				GetAllShiftNeededResourceExpressions.Add(pp=> pp.ResourceTypeId==model.ResourceTypeId);
			}
			if (model.IsDeleted!=null) {
				GetAllShiftNeededResourceExpressions.Add(pp=> pp.IsDeleted== model.IsDeleted);
			}

			List<ShiftNeededResourcesResult>? res = await _shiftNeededResourceStore.GetAllWithPagingAsync(GetAllShiftNeededResourceExpressions, pp =>
			new ShiftNeededResourcesResult {
				Id=pp.Id,
				ResourceId=pp.ResourceTypeId ,
				ResourceTypeName= pp.SamtResourceType.Title ,
				ShiftId= pp.ShiftId , 
				ShiftName= pp.ShiftShift.Title
			}, pp=> pp.Id, model.PageSize , model.PageNo );
			return res;
		}

		public int GetAllShiftNeededResourcesCount() {
			var res = _shiftNeededResourceStore.TotalCount(GetAllShiftNeededResourceExpressions);
			return res;
		}

	}
}
