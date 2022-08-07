using Shift.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Bussiness {

	public interface IShiftService {

		//public Task<StoreViewModel<ShiftShift>> FindByPortalId(int Id);
		public Task<StoreViewModel<ShiftViewModel>> GetAll(ShiftSearchModel model);
		//public IQueryable<ShiftShift> GetByPortalId(int portalId);
		public Task<BaseResult> Register(ShiftInputModel model);
		public Task<BaseResult> Update(ShiftInputModel model);
		public Task<BaseResult> Delete(int id);

		public Task<StoreViewModel<ShiftTemplateViewModel>> GetAllShiftTemplates(ShiftTemplateSearchModel model);
		public Task<BaseResult> RegisterShiftTemplate(ShiftTemplateInputModel model);
		public Task<BaseResult> UpdateShiftTemplate(ShiftTemplateInputModel model);
		public Task<BaseResult> DeleteShiftTemplate(int id);
	}
}
