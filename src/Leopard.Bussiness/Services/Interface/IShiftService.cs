using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness {

	public interface IShiftService {

		public Task<StoreViewModel<ShiftShift>> FindByPortalId(int Id);
		public Task<StoreViewModel<ShiftViewModel>> GetAll(ShiftSearchModel model);

		//public IQueryable<ShiftShift> GetByPortalId(int portalId);

		public Task<BaseResult> Register(ShiftInputModel model);

		public Task<BaseResult> Update(ShiftInputModel model);

		public Task<BaseResult> Delete(ShiftInputModel model);


		public Task<StoreViewModel<ShiftShiftJobTemplateViewModel>> GetAllShiftJobTemplates(ShiftShiftJobTemplateSearchModel model);

		public Task<BaseResult> RegisterShiftJobTemplate(ShiftShiftJobTemplateInputModel model);
		public Task<BaseResult> DeleteShiftJobTemplate(ShiftShiftJobTemplateInputModel model);
		public Task<BaseResult> UpdateShiftJobTemplate(ShiftShiftJobTemplateInputModel model);
	}
}
