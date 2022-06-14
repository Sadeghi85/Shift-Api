// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // ConductorChannelProgramAgeRanges
    public partial class ConductorChannelProgramAgeRanx
    {
        public int Id { get; set; } // ID (Primary key)
        public string Title { get; set; } // Title (length: 50)
        public bool Enabled { get; set; } // Enabled
        public string Description { get; set; } // Description (length: 500)

        // Reverse navigation

        /// <summary>
        /// Child ConductorChannelProgramInfoes where [ConductorChannelProgramInfo].[AgeRange] point to this entity (FK_ConductorChannelProgramInfo_ConductorChannelProgramAgeRanges)
        /// </summary>
        public virtual ICollection<ConductorChannelProgramInfo> ConductorChannelProgramInfoes { get; set; } // ConductorChannelProgramInfo.FK_ConductorChannelProgramInfo_ConductorChannelProgramAgeRanges

        public ConductorChannelProgramAgeRanx()
        {
            ConductorChannelProgramInfoes = new List<ConductorChannelProgramInfo>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>