// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Shift.Repository
{
    // TelavatAgentResourceTypes
    public partial class TelavatAgentResourceType
    {
        public int Id { get; set; } // ID (Primary key)
        public int AgentId { get; set; } // AgentID
        public int ResourceTypeId { get; set; } // ResourceTypeID
        public bool IsDeleted { get; set; } // IsDeleted
        public DateTime CreateDateTime { get; set; } // CreateDateTime

        public TelavatAgentResourceType()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
