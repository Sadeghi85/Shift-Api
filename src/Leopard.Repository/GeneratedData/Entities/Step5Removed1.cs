// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // step5_removed1
    public partial class Step5Removed1
    {
        public int Id { get; set; } // ID (Primary key)
        public int LogId { get; set; } // LogID (Primary key)
        public int Status { get; set; } // Status (Primary key)

        public Step5Removed1()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
