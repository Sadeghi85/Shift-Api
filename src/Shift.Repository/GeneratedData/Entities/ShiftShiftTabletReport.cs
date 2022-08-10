// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Shift.Repository
{
    // Shift_ShiftTabletReports
    public partial class ShiftShiftTabletReport
    {
        public int Id { get; set; } // ID (Primary key)
        public int ShiftTabletId { get; set; } // ShiftTabletID
        public int? CreatedBy { get; set; } // CreatedBy
        public int? ModifiedBy { get; set; } // ModifiedBy
        public DateTime? CreateDateTime { get; set; } // CreateDateTime
        public DateTime? LastModifiedDateTime { get; set; } // LastModifiedDateTime
        public string ReportDescription { get; set; } // ReportDescription
        public bool IsDeleted { get; set; } // IsDeleted
        public int RoleTypeId { get; set; } // RoleTypeID

        // Foreign keys

        /// <summary>
        /// Parent ShiftShiftTablet pointed by [Shift_ShiftTabletReports].([ShiftTabletId]) (FK_Shift_ShiftTabletReports_Shift_ShiftTablet)
        /// </summary>
        public virtual ShiftShiftTablet ShiftShiftTablet { get; set; } // FK_Shift_ShiftTabletReports_Shift_ShiftTablet

        public ShiftShiftTabletReport()
        {
            IsDeleted = false;
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
