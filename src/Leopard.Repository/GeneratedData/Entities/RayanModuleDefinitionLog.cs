// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // RayanModuleDefinitionLogs
    public partial class RayanModuleDefinitionLog
    {
        public int Id { get; set; } // ID (Primary key)
        public int RayanModuleDefinitionId { get; set; } // RayanModuleDefinitionID
        public string Version { get; set; } // Version (length: 5)
        public int? CreatedBy { get; set; } // CreatedBy
        public int? ModifiedBy { get; set; } // ModifiedBy
        public DateTime? CreateDateTime { get; set; } // CreateDateTime
        public DateTime? LastModifiedDateTime { get; set; } // LastModifiedDateTime

        // Foreign keys

        /// <summary>
        /// Parent RayanModuleDefinition pointed by [RayanModuleDefinitionLogs].([RayanModuleDefinitionId]) (FK_RayanModuleDefinitionLogs_RayanModuleDefinitions)
        /// </summary>
        public virtual RayanModuleDefinition RayanModuleDefinition { get; set; } // FK_RayanModuleDefinitionLogs_RayanModuleDefinitions

        public RayanModuleDefinitionLog()
        {
            CreateDateTime = DateTime.Now;
            LastModifiedDateTime = DateTime.Now;
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
