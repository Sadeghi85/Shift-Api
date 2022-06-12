using Leopard.Bussiness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Services.Interface {
	public interface IShiftService {

		public OperationResult FindByPortalId(int Id);
		public OperationResult GetAll();

		public OperationResult GetByPortalId(int portalId);

		public Task<OperationResult> Register(ShiftModel model);

		public Task<OperationResult> Update(ShiftModel model);

		public Task<OperationResult> Delete(int id);



	}
}
