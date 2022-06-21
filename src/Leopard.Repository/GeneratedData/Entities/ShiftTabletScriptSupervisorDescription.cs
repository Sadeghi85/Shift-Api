// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // Shift_TabletScriptSupervisorDescription
    public partial class ShiftTabletScriptSupervisorDescription
    {
        public int Id { get; set; } // Id (Primary key)
        public int? ShiftTabletId { get; set; } // ShiftTabletId
        public int? CreatedBy { get; set; } // CreatedBy
        public int? ModifiedBy { get; set; } // ModifiedBy
        public DateTime? CreateDateTime { get; set; } // CreateDateTime
        public DateTime? LastModifiedDateTime { get; set; } // LastModifiedDateTime
        public string Description { get; set; } // Description (length: 1000)
        public bool? IsDeleted { get; set; } // IsDeleted

        // Foreign keys

        /// <summary>
        /// Parent ShiftShiftTablet pointed by [Shift_TabletScriptSupervisorDescription].([ShiftTabletId]) (FK_Shift_TabletScriptSupervisorDescription_Shift_ShiftTablet)
        /// </summary>
        public virtual ShiftShiftTablet ShiftShiftTablet { get; set; } // FK_Shift_TabletScriptSupervisorDescription_Shift_ShiftTablet

        public ShiftTabletScriptSupervisorDescription()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
