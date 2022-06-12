// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // SAMT_ProgramTransfers
    public partial class SamtProgramTransfer
    {
        public int Id { get; set; } // ID (Primary key)
        public int RequestId { get; set; } // RequestID
        public int PartFrom { get; set; } // PartFrom
        public int PartTo { get; set; } // PartTo
        public int BaseYear { get; set; } // BaseYear
        public bool IsDeleted { get; set; } // IsDeleted
        public int? CreatedBy { get; set; } // CreatedBy
        public int? ModifiedBy { get; set; } // ModifiedBy
        public DateTime? CreateDateTime { get; set; } // CreateDateTime
        public DateTime? LastModifiedDateTime { get; set; } // LastModifiedDateTime
        public int? DeletedBy { get; set; } // DeletedBy
        public DateTime? DeletedDateTime { get; set; } // DeletedDateTime

        // Foreign keys

        /// <summary>
        /// Parent User pointed by [SAMT_ProgramTransfers].([CreatedBy]) (FK_SAMT_ProgramTransfers_Users)
        /// </summary>
        public virtual User User_CreatedBy { get; set; } // FK_SAMT_ProgramTransfers_Users

        /// <summary>
        /// Parent User pointed by [SAMT_ProgramTransfers].([DeletedBy]) (FK_SAMT_ProgramTransfers_Users2)
        /// </summary>
        public virtual User User_DeletedBy { get; set; } // FK_SAMT_ProgramTransfers_Users2

        /// <summary>
        /// Parent User pointed by [SAMT_ProgramTransfers].([ModifiedBy]) (FK_SAMT_ProgramTransfers_Users1)
        /// </summary>
        public virtual User User_ModifiedBy { get; set; } // FK_SAMT_ProgramTransfers_Users1

        public SamtProgramTransfer()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
