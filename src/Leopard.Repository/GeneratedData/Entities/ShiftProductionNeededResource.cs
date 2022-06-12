// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // Shift_ProductionNeededResource
    public partial class ShiftProductionNeededResource
    {
        public int Id { get; set; } // ID (Primary key)
        public int? ShifProductionTypeId { get; set; } // ShifProductionTypeId
        public int? ResourceId { get; set; } // ResourceId
        public int? CreatedBy { get; set; } // CreatedBy
        public int? ModifiedBy { get; set; } // ModifiedBy
        public DateTime? CreateDateTime { get; set; } // CreateDateTime
        public DateTime? LastModifiedDateTime { get; set; } // LastModifiedDateTime

        // Foreign keys

        /// <summary>
        /// Parent SamtResourceType pointed by [Shift_ProductionNeededResource].([ResourceId]) (FK_Shift_ProductionNeededResource_SAMT_ResourceTypes)
        /// </summary>
        public virtual SamtResourceType SamtResourceType { get; set; } // FK_Shift_ProductionNeededResource_SAMT_ResourceTypes

        /// <summary>
        /// Parent ShiftProductionType pointed by [Shift_ProductionNeededResource].([ShifProductionTypeId]) (FK_Shift_ProductionNeededResource_Shift_ProductionType)
        /// </summary>
        public virtual ShiftProductionType ShiftProductionType { get; set; } // FK_Shift_ProductionNeededResource_Shift_ProductionType

        public ShiftProductionNeededResource()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
