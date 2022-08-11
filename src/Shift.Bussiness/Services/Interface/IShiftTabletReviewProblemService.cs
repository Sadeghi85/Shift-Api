

using Shift.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Bussiness {
	public interface IShiftTabletReviewProblemService {
		
		public Task<StoreViewModel<ShiftTabletReviewProblemViewModel>> GetAll(ShiftTabletReviewProblemSearchModel model);
		public Task<BaseResult> Create(ShiftTabletReviewProblemInputModel model);
		public Task<BaseResult> Update(ShiftTabletReviewProblemInputModel model);
		public Task<BaseResult> Delete(int id);
		public Task<BaseResult> Delete(string ids);

	}
}
