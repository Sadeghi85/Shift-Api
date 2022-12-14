// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Shift.Repository
{
    // Shift_ShiftTabletConductorChanges
    public partial class ShiftShiftTabletConductorChanx
    {
        public int Id { get; set; } // ID (Primary key)
        public string OldProgramTitle { get; set; } // OldProgramTitle (length: 250)
        public string NewProgramTitle { get; set; } // NewProgramTitle (length: 250)
        public int ShiftTabletId { get; set; } // ShiftTabletID
        public string Description { get; set; } // Description
        public int? CreatedBy { get; set; } // CreatedBy
        public int? ModifiedBy { get; set; } // ModifiedBy
        public DateTime? CreateDateTime { get; set; } // CreateDateTime
        public DateTime? LastModifiedDateTime { get; set; } // LastModifiedDateTime
        public bool IsDeleted { get; set; } // IsDeleted
        public int RoleTypeId { get; set; } // RoleTypeID

        // Foreign keys

        /// <summary>
        /// Parent ShiftShiftTablet pointed by [Shift_ShiftTabletConductorChanges].([ShiftTabletId]) (FK_Shift_ShiftTabletConductorChanges_Shift_ShiftTablet)
        /// </summary>
        [JsonIgnore]
        public virtual ShiftShiftTablet ShiftShiftTablet { get; set; } // FK_Shift_ShiftTabletConductorChanges_Shift_ShiftTablet

        public ShiftShiftTabletConductorChanx()
        {
            IsDeleted = false;
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
