// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // RequestLogQualities
    public partial class RequestLogQuality
    {
        public int Id { get; set; } // ID (Primary key)
        public int? LogId { get; set; } // LogID
        public int? MainQualityId { get; set; } // MainQualityID
        public int? QualityId { get; set; } // QualityID
        public bool? Accept { get; set; } // Accept
        public double? Rate { get; set; } // Rate
        public string Description { get; set; } // Description
        public int? CreatedBy { get; set; } // CreatedBy
        public int? ModifiedBy { get; set; } // ModifiedBy
        public DateTime? CreateDateTime { get; set; } // CreateDateTime
        public DateTime? LastModifiedDateTime { get; set; } // LastModifiedDateTime
        public bool IsDeleted { get; set; } // IsDeleted

        public RequestLogQuality()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
