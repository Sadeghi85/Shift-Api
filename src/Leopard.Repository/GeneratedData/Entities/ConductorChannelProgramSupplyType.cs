// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // ConductorChannelProgramSupplyTypes
    public partial class ConductorChannelProgramSupplyType
    {
        public int Id { get; set; } // ID (Primary key)
        public string Title { get; set; } // Title (length: 150)
        public string Description { get; set; } // Description (length: 1000)
        public bool Enabled { get; set; } // Enabled

        // Reverse navigation

        /// <summary>
        /// Child ConductorChannelProgramInfoes where [ConductorChannelProgramInfo].[ProgramSupplyType] point to this entity (FK_ConductorChannelProgramInfo_ConductorChannelProgramSupplyTypes)
        /// </summary>
        public virtual ICollection<ConductorChannelProgramInfo> ConductorChannelProgramInfoes { get; set; } // ConductorChannelProgramInfo.FK_ConductorChannelProgramInfo_ConductorChannelProgramSupplyTypes

        public ConductorChannelProgramSupplyType()
        {
            ConductorChannelProgramInfoes = new List<ConductorChannelProgramInfo>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
