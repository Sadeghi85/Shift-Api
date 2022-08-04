// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // TelavatAgentResourceTypes
    public partial class TelavatAgentResourceType
    {

        // Foreign keys

        /// <summary>
        /// Parent SamtAgent pointed by [TelavatAgentResourceTypes].([AgentId]) (FK_TelavatAgentResourceTypes_SAMT_Agents)
        /// </summary>
        public virtual SamtAgent SamtAgent { get; set; } // FK_TelavatAgentResourceTypes_SAMT_Agents

        /// <summary>
        /// Parent SamtResourceType pointed by [TelavatAgentResourceTypes].([ResourceTypeId]) (FK_TelavatAgentResourceTypes_SAMT_ResourceTypes)
        /// </summary>
        public virtual SamtResourceType SamtResourceType { get; set; } // FK_TelavatAgentResourceTypes_SAMT_ResourceTypes

    }

}
// </auto-generated>
