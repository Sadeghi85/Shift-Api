// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // SAMT_ResourceTypes
    public partial class SamtResourceType
    {
        public int Id { get; set; } // ID (Primary key)
        public int? ParentId { get; set; } // ParentID
        public string Title { get; set; } // Title (length: 1000)
        public double AmountWage { get; set; } // AmountWage
        public bool IsDeleted { get; set; } // IsDeleted

        // Reverse navigation

        /// <summary>
        /// Child ConductorChannelProgramAgents where [ConductorChannelProgramAgents].[ResourceTypeID] point to this entity (FK_ConductorChannelProgramAgents_SAMT_ResourceTypes)
        /// </summary>
        public virtual ICollection<ConductorChannelProgramAgent> ConductorChannelProgramAgents { get; set; } // ConductorChannelProgramAgents.FK_ConductorChannelProgramAgents_SAMT_ResourceTypes

        /// <summary>
        /// Child ShiftShiftTabletCrews where [Shift_ShiftTabletCrew].[ResourceId] point to this entity (FK_Shift_ShiftTableCrew_SAMT_ResourceTypes)
        /// </summary>
        public virtual ICollection<ShiftShiftTabletCrew> ShiftShiftTabletCrews { get; set; } // Shift_ShiftTabletCrew.FK_Shift_ShiftTableCrew_SAMT_ResourceTypes

        /// <summary>
        /// Child ShiftTabletNeededResources where [shiftTabletNeededResource].[ResourceTypeId] point to this entity (FK_shiftTabletNeededResource_SAMT_ResourceTypes)
        /// </summary>
        public virtual ICollection<ShiftTabletNeededResource> ShiftTabletNeededResources { get; set; } // shiftTabletNeededResource.FK_shiftTabletNeededResource_SAMT_ResourceTypes

        /// <summary>
        /// Child TelavatPaymentLogDetails where [TelavatPaymentLogDetails].[AgentPostID] point to this entity (FK_TelavatPaymentLogDetails_TelavatResourceTypes)
        /// </summary>
        public virtual ICollection<TelavatPaymentLogDetail> TelavatPaymentLogDetails { get; set; } // TelavatPaymentLogDetails.FK_TelavatPaymentLogDetails_TelavatResourceTypes

        public SamtResourceType()
        {
            AmountWage = 0;
            IsDeleted = false;
            ConductorChannelProgramAgents = new List<ConductorChannelProgramAgent>();
            ShiftShiftTabletCrews = new List<ShiftShiftTabletCrew>();
            ShiftTabletNeededResources = new List<ShiftTabletNeededResource>();
            TelavatPaymentLogDetails = new List<TelavatPaymentLogDetail>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
