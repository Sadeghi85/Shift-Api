// ReSharper disable All

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shift.Repository
{
    public partial class ShiftDbContext : DbContext, IShiftDbContext
    {
		public DbContext Instance => this;
		partial void InitializePartial() {

		}
        partial void DisposePartial(bool disposing) {

		}
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder) {

		}
		static partial void OnCreateModelPartial(ModelBuilder modelBuilder, string schema) {
		}

        // Stored Procedures
        

    }
}
