// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // shiftTabletNeededResource
    public partial class ShiftTabletNeededResource
    {
        public int Id { get; set; } // Id (Primary key)
        public int ResourceTypeId { get; set; } // ResourceTypeId
        public int ShiftId { get; set; } // ShiftId
        public int? CreatedBy { get; set; } // CreatedBy
        public int? ModifiedBy { get; set; } // ModifiedBy
        public DateTime? CreateDateTime { get; set; } // CreateDateTime
        public DateTime? LastModifiedDateTime { get; set; } // LastModifiedDateTime
        public bool IsDeleted { get; set; } // IsDeleted

        // Foreign keys

        /// <summary>
        /// Parent SamtResourceType pointed by [shiftTabletNeededResource].([ResourceTypeId]) (FK_shiftTabletNeededResource_SAMT_ResourceTypes)
        /// </summary>
        public virtual SamtResourceType SamtResourceType { get; set; } // FK_shiftTabletNeededResource_SAMT_ResourceTypes

        /// <summary>
        /// Parent ShiftShift pointed by [shiftTabletNeededResource].([ShiftId]) (FK_shiftTabletNeededResource_Shift_Shift)
        /// </summary>
        public virtual ShiftShift ShiftShift { get; set; } // FK_shiftTabletNeededResource_Shift_Shift

        public ShiftTabletNeededResource()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>