// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // SAMT_RequestCosts
    public partial class SamtRequestCost
    {
        public int Id { get; set; } // ID (Primary key)
        public int RequestId { get; set; } // RequestID
        public int CategoryId { get; set; } // CategoryID
        public double Cost { get; set; } // Cost
        public bool IsDeleted { get; set; } // IsDeleted

        public SamtRequestCost()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>