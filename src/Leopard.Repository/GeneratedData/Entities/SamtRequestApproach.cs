// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // SAMT_RequestApproach
    public partial class SamtRequestApproach
    {
        public int Id { get; set; } // ID (Primary key)
        public int RequestId { get; set; } // RequestID
        public int ApproachId { get; set; } // ApproachID
        public int ApproachPercent { get; set; } // ApproachPercent
        public bool IsDeleted { get; set; } // IsDeleted

        // Foreign keys

        /// <summary>
        /// Parent SamtApproach pointed by [SAMT_RequestApproach].([ApproachId]) (FK_TelavatRequestApproach_TelavatApproach)
        /// </summary>
        public virtual SamtApproach SamtApproach { get; set; } // FK_TelavatRequestApproach_TelavatApproach

        /// <summary>
        /// Parent SamtRequest pointed by [SAMT_RequestApproach].([RequestId]) (FK_SAMT_RequestApproach_SAMT_Requests)
        /// </summary>
        public virtual SamtRequest SamtRequest { get; set; } // FK_SAMT_RequestApproach_SAMT_Requests

        public SamtRequestApproach()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
