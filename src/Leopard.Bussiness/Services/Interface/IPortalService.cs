using Leopard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leopard.Bussiness.Services.Interface {
	public interface IPortalService {
		public IQueryable<Portal> GetAll();
		public Portal GetById(int id);
	}
}
