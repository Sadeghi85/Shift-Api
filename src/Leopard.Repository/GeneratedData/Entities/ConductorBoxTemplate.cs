// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // ConductorBoxTemplates
    public partial class ConductorBoxTemplate
    {
        public int Id { get; set; } // ID (Primary key)
        public int TypeId { get; set; } // TypeID
        public int ChannelId { get; set; } // ChannelID
        public DateTime Date { get; set; } // Date
        public int Duration { get; set; } // Duration
        public int? CreatedBy { get; set; } // CreatedBy
        public int? ModifiedBy { get; set; } // ModifiedBy
        public DateTime? CreateDateTime { get; set; } // CreateDateTime
        public DateTime? LastModifiedDateTime { get; set; } // LastModifiedDateTime
        public bool IsDeleted { get; set; } // IsDeleted

        // Reverse navigation

        /// <summary>
        /// Child ConductorBoxItems where [ConductorBoxItems].[TemplateID] point to this entity (FK_ConductorBoxItems_ConductorBoxTemplates)
        /// </summary>
        public virtual ICollection<ConductorBoxItem> ConductorBoxItems { get; set; } // ConductorBoxItems.FK_ConductorBoxItems_ConductorBoxTemplates

        // Foreign keys

        /// <summary>
        /// Parent ConductorBoxType pointed by [ConductorBoxTemplates].([TypeId]) (FK_ConductorBoxItems_ConductorBoxItemTypes)
        /// </summary>
        public virtual ConductorBoxType ConductorBoxType { get; set; } // FK_ConductorBoxItems_ConductorBoxItemTypes

        public ConductorBoxTemplate()
        {
            IsDeleted = false;
            ConductorBoxItems = new List<ConductorBoxItem>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>