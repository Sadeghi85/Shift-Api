// <auto-generated>
// ReSharper disable All

using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    public partial class MojriEducationStore : StoreBase<MojriEducation>, IMojriEducationStore
    {
        private readonly ILeopardDbContext _ctx;
        private readonly ILogger _logger;
        private readonly IPrincipal _iPrincipal;

        public MojriEducationStore(ILeopardDbContext ctx, ILogger logger, IPrincipal principal) : base(ctx, logger, principal)
        {
            _ctx = ctx;
    		_logger = logger;
            _iPrincipal = principal;
        }
    }
}
// </auto-generated>
