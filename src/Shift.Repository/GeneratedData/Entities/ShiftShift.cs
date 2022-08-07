// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Shift.Repository
{
    // Shift_Shift
    public partial class ShiftShift
    {
        public int Id { get; set; } // ID (Primary key)
        public string Title { get; set; } // Title (length: 250)
        public int PortalId { get; set; } // PortalID
        public TimeSpan StartTime { get; set; } // StartTime
        public TimeSpan EndTime { get; set; } // EndTime
        public int? CreatedBy { get; set; } // CreatedBy
        public int? ModifiedBy { get; set; } // ModifiedBy
        public DateTime? CreateDateTime { get; set; } // CreateDateTime
        public DateTime? LastModifiedDateTime { get; set; } // LastModifiedDateTime

        /// <summary>
        /// نوع شیفت که گویای دو نوع شیفت رژی (1) و شیف هماهنگی(2) میباشد.
        /// </summary>
        public int ShiftTypeId { get; set; } // ShiftTypeID
        public bool HasRewardFine { get; set; } // HasRewardFine
        public int RewardFineAmount { get; set; } // RewardFineAmount
        public bool IsDeleted { get; set; } // IsDeleted

        // Reverse navigation

        /// <summary>
        /// Child ShiftShiftTablets where [Shift_ShiftTablet].[ShiftID] point to this entity (FK_ShiftExecution_PortalShift)
        /// </summary>
        public virtual ICollection<ShiftShiftTablet> ShiftShiftTablets { get; set; } // Shift_ShiftTablet.FK_ShiftExecution_PortalShift

        /// <summary>
        /// Child ShiftShiftTemplates where [Shift_ShiftTemplate].[ShiftID] point to this entity (FK_ShiftNeededResource_Shift_Shift)
        /// </summary>
        public virtual ICollection<ShiftShiftTemplate> ShiftShiftTemplates { get; set; } // Shift_ShiftTemplate.FK_ShiftNeededResource_Shift_Shift

        // Foreign keys

        /// <summary>
        /// Parent Portal pointed by [Shift_Shift].([PortalId]) (FK_PortalShift_Portals)
        /// </summary>
        public virtual Portal Portal { get; set; } // FK_PortalShift_Portals

        public ShiftShift()
        {
            HasRewardFine = false;
            RewardFineAmount = 0;
            IsDeleted = false;
            ShiftShiftTablets = new List<ShiftShiftTablet>();
            ShiftShiftTemplates = new List<ShiftShiftTemplate>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>