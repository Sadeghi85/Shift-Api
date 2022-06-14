// <auto-generated>
// ReSharper disable All

using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    public partial class SamtRequests3Store : StoreBase<SamtRequests3>, ISamtRequests3Store
    {
        private readonly ILeopardDbContext _ctx;
        private readonly ILogger _logger;

        public SamtRequests3Store(ILeopardDbContext ctx, ILogger logger) : base(ctx, logger)
        {
            _ctx = ctx;
    		_logger = logger;
        }
    }
}
// </auto-generated>