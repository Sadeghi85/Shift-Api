// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // SAMT_BroadcastDuration
    public partial class SamtBroadcastDuration
    {
        public int BroadcastDurationId { get; set; } // BroadcastDurationID (Primary key)
        public string BroadcastDurationTitle { get; set; } // BroadcastDurationTitle (length: 1000)

        public SamtBroadcastDuration()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
