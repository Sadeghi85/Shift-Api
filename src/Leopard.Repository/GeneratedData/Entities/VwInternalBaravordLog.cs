// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // VW_InternalBaravordLogs
    public partial class VwInternalBaravordLog
    {
        public int InternalBaravordsId { get; set; } // InternalBaravordsID
        public int? InternalResourceId { get; set; } // InternalResourceID
        public int? RequestId { get; set; } // RequestID
        public int? BaravordId { get; set; } // BaravordID
        public int? ResourceId { get; set; } // ResourceID
        public int? ResourceCount { get; set; } // ResourceCount
        public int? ResourceTime { get; set; } // ResourceTime
        public int? MeasurementUnitId { get; set; } // MeasurementUnitID
        public long? Fee { get; set; } // Fee
        public long? TotalFee { get; set; } // TotalFee
        public string Description { get; set; } // Description
        public long? FeeBahrevari { get; set; } // Fee_Bahrevari
        public long? TotalFeeBahrevari { get; set; } // TotalFee_Bahrevari
        public int? ResourceCostId { get; set; } // ResourceCostID
        public int? JobType { get; set; } // JobType
        public int? InternalBaravordLogsId { get; set; } // InternalBaravordLogsID
        public int? LogId { get; set; } // LogID
        public bool? Accept { get; set; } // Accept
        public string LogDescription { get; set; } // LogDescription
        public bool? IsDeleted { get; set; } // IsDeleted

        public VwInternalBaravordLog()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
