using Shift.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Bussiness {
	public interface IPaymentService {
		public Task<StoreViewModel<PaymentViewModel>> GetAll(PaymentSearchModel model);
		public Task<BaseResult> Update(PaymentInputModel model);

	}
}
