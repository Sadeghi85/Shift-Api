// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // FIDS_SAMT_RequestLogStatus
    public partial class FidsSamtRequestLogStatu
    {
        public int Id { get; set; } // ID (Primary key)
        public int LogId { get; set; } // LogID (Primary key)
        public int Status { get; set; } // Status (Primary key)

        public FidsSamtRequestLogStatu()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
