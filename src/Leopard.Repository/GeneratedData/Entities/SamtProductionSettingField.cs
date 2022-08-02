// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // SAMT_ProductionSettingFields
    public partial class SamtProductionSettingField
    {
        public int Id { get; set; } // ID (Primary key)
        public int Type { get; set; } // Type
        public int SectionId { get; set; } // SectionID
        public string Title { get; set; } // Title (length: 1000)
        public int Ordering { get; set; } // Ordering
        public bool Enabled { get; set; } // Enabled
        public bool IsWriting { get; set; } // IsWriting
        public string FieldKey { get; set; } // FieldKey (length: 1000)
        public bool Hide { get; set; } // Hide
        public int? CreatedBy { get; set; } // CreatedBy
        public int? ModifiedBy { get; set; } // ModifiedBy
        public DateTime? CreateDateTime { get; set; } // CreateDateTime
        public DateTime? LastModifiedDateTime { get; set; } // LastModifiedDateTime

        // Reverse navigation

        /// <summary>
        /// Child SamtProductionSettingItems where [SAMT_ProductionSettingItems].[FieldID] point to this entity (FK_SAMT_ProductionSettingItems_SAMT_ProductionSettingFields)
        /// </summary>
        public virtual ICollection<SamtProductionSettingItem> SamtProductionSettingItems { get; set; } // SAMT_ProductionSettingItems.FK_SAMT_ProductionSettingItems_SAMT_ProductionSettingFields

        public SamtProductionSettingField()
        {
            Type = 1;
            Enabled = true;
            IsWriting = false;
            Hide = false;
            SamtProductionSettingItems = new List<SamtProductionSettingItem>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
