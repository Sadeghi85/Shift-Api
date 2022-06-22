using Leopard.Bussiness.Model;
using Leopard.Bussiness.Model.ReturnModel;
using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Services.Interface {
	public interface IShiftService {

		public List<ShiftShift> FindByPortalId(int Id);
		public Task<List<ShiftResultModel>> GetAll(ShiftSearchModel model);

		public IQueryable<ShiftShift> GetByPortalId(int portalId);

		public Task<BaseResult> Register(ShiftModel model);

		public Task<BaseResult> Update(ShiftModel model);

		public Task<BaseResult> Delete(int id);

		public int GetAllCount();



	}
}
