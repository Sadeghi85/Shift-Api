// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // ConductorAutoFileNumber
    public partial class ConductorAutoFileNumber
    {
        public int Id { get; set; } // Id (Primary key)
        public string UidLevel { get; set; } // UIDLevel (length: 2)
        public string EstimateGid { get; set; } // EstimateGID (length: 3)
        public string Year { get; set; } // year (length: 2)
        public string Month { get; set; } // month (length: 2)
        public string Day { get; set; } // day (length: 2)
        public int? DaylyCount { get; set; } // DaylyCount
        public string Result { get; set; } // Result (length: 100)

        public ConductorAutoFileNumber()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
