// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // Shift_ProductionType
    public partial class ShiftProductionType
    {
        public int Id { get; set; } // ID (Primary key)
        public string Title { get; set; } // Title (length: 250)
        public int? CreatedBy { get; set; } // CreatedBy
        public int? ModifiedBy { get; set; } // ModifiedBy
        public DateTime? CreateDateTime { get; set; } // CreateDateTime
        public DateTime? LastModifiedDateTime { get; set; } // LastModifiedDateTime
        public bool IsDeleted { get; set; } // IsDeleted

        // Reverse navigation

        /// <summary>
        /// Child ShiftProductionNeededResources where [Shift_ProductionNeededResource].[ShifProductionTypeId] point to this entity (FK_Shift_ProductionNeededResource_Shift_ProductionType)
        /// </summary>
        public virtual ICollection<ShiftProductionNeededResource> ShiftProductionNeededResources { get; set; } // Shift_ProductionNeededResource.FK_Shift_ProductionNeededResource_Shift_ProductionType

        /// <summary>
        /// Child ShiftShiftTablets where [Shift_ShiftTablet].[ProductionTypeId] point to this entity (FK_ShiftExecution_ProductionType)
        /// </summary>
        public virtual ICollection<ShiftShiftTablet> ShiftShiftTablets { get; set; } // Shift_ShiftTablet.FK_ShiftExecution_ProductionType

        public ShiftProductionType()
        {
            ShiftProductionNeededResources = new List<ShiftProductionNeededResource>();
            ShiftShiftTablets = new List<ShiftShiftTablet>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
