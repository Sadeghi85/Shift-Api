using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness {

	public interface IShiftService {

		public List<ShiftShift> FindByPortalId(int Id);
		public Task<List<ShiftViewModel>> GetAll(ShiftSearchModel model, out Task<int> totalCount);

		public IQueryable<ShiftShift> GetByPortalId(int portalId);

		public Task<BaseResult> Register(ShiftInputModel model);

		public Task<BaseResult> Update(ShiftInputModel model);

		public Task<BaseResult> Delete(ShiftInputModel model);

		//public int GetAllCount();


		public Task<List<ShiftShiftJobTemplateViewModel>?> GetAllShiftJobTemplates(ShiftShiftJobTemplateSearchModel model, out Task<int> totalCount);
		//public int GetAllShiftNeededResourcesCount();

		public Task<BaseResult> RegisterShiftJobTemplate(ShiftShiftJobTemplateInputModel model);
		public Task<BaseResult> DeleteShiftJobTemplate(ShiftShiftJobTemplateInputModel model);
		public Task<BaseResult> UpdateShiftJobTemplate(ShiftShiftJobTemplateInputModel model);
	}
}
