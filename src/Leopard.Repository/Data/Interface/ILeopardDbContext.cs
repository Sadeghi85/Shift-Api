using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    public partial interface ILeopardDbContext : IDisposable
    {
		DbContext Instance { get; }


		// Stored Procedures

	}
}
