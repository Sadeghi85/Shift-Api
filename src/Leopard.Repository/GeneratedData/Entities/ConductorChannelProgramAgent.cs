// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // ConductorChannelProgramAgents
    public partial class ConductorChannelProgramAgent
    {
        public int Id { get; set; } // ID (Primary key)
        public int ChannelProgramId { get; set; } // ChannelProgramID
        public int AgentId { get; set; } // AgentID
        public int ResourceTypeId { get; set; } // ResourceTypeID

        // Foreign keys

        /// <summary>
        /// Parent ConductorChannelProgram pointed by [ConductorChannelProgramAgents].([ChannelProgramId]) (FK_ConductorChannelProgramAgents_ConductorChannelPrograms)
        /// </summary>
        public virtual ConductorChannelProgram ConductorChannelProgram { get; set; } // FK_ConductorChannelProgramAgents_ConductorChannelPrograms

        /// <summary>
        /// Parent SamtResourceType pointed by [ConductorChannelProgramAgents].([ResourceTypeId]) (FK_ConductorChannelProgramAgents_SAMT_ResourceTypes)
        /// </summary>
        public virtual SamtResourceType SamtResourceType { get; set; } // FK_ConductorChannelProgramAgents_SAMT_ResourceTypes

        public ConductorChannelProgramAgent()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>