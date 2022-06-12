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
    public partial class VwSamtProductionReviewLog2Store : StoreBase<VwSamtProductionReviewLog2>, IVwSamtProductionReviewLog2Store
    {
        private readonly ILeopardDbContext _ctx;
        private readonly ILogger _logger;

        public VwSamtProductionReviewLog2Store(ILeopardDbContext ctx, ILogger logger) : base(ctx, logger)
        {
            _ctx = ctx;
    		_logger = logger;
        }
    }
}
// </auto-generated>
