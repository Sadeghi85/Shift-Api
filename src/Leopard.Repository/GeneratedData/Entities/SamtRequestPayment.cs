// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // SAMT_RequestPayments
    public partial class SamtRequestPayment
    {
        public int Id { get; set; } // ID (Primary key)
        public int RequestId { get; set; } // RequestID
        public int? OldRequestId { get; set; } // OldRequestID
        public double Amount { get; set; } // Amount
        public int? CreatedBy { get; set; } // CreatedBy
        public int? ModifiedBy { get; set; } // ModifiedBy
        public DateTime? CreateDateTime { get; set; } // CreateDateTime
        public DateTime? LastModifiedDateTime { get; set; } // LastModifiedDateTime
        public bool IsCreditor { get; set; } // IsCreditor
        public DateTime? DatePayment { get; set; } // DatePayment
        public int? Type { get; set; } // Type
        public int BaseYear { get; set; } // BaseYear

        // Foreign keys

        /// <summary>
        /// Parent SamtRequest pointed by [SAMT_RequestPayments].([RequestId]) (FK_TelavatRequestPayments_SAMT_Requests)
        /// </summary>
        public virtual SamtRequest SamtRequest { get; set; } // FK_TelavatRequestPayments_SAMT_Requests

        public SamtRequestPayment()
        {
            BaseYear = 0;
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
