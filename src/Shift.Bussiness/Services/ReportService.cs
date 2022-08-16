using Shift.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Bussiness {
	public class ReportService : ServiceBase, IReportService {

		private readonly IPortalStore _portalStore;

		public ReportService(IPrincipal iPrincipal, IPortalStore portalStore, IShiftLogStore shiftLogStore) : base(iPrincipal, shiftLogStore) {
			_portalStore = portalStore;
		}

		public async Task<MemoryStream> GetReport(PortalSearchModel model) {
			var stream = new MemoryStream();

			try {
				if (CurrentUserPortalId > 1) {
				model.Id = CurrentUserPortalId;
			}

			var getAllExpressions = new List<Expression<Func<Portal, bool>>>();

			getAllExpressions.Add(x => x.NoDashboard == false);

			await _portalStore.GetAllWithPagingAsync(getAllExpressions, x => new PortalViewModel { Id = x.Id, Title = x.Title }, model.OrderKey, model.Desc, model.PageSize, model.PageNo);

			

			
				

			} catch (Exception ex) {
				var i = 0;
			}

			return stream;





		}


	}
}
