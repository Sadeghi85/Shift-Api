// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // TelavatEquipmentCategories
    public partial class TelavatEquipmentCategory
    {
        public int Id { get; set; } // ID (Primary key)
        public int Type { get; set; } // Type
        public string Title { get; set; } // Title (length: 1000)
        public int? PortalId { get; set; } // PortalID
        public int Ordering { get; set; } // Ordering

        // Reverse navigation

        /// <summary>
        /// Child TelavatEquipments where [TelavatEquipments].[CategoryID] point to this entity (FK_TelavatEquipments_TelavatEquipmentCategories)
        /// </summary>
        public virtual ICollection<TelavatEquipment> TelavatEquipments { get; set; } // TelavatEquipments.FK_TelavatEquipments_TelavatEquipmentCategories

        public TelavatEquipmentCategory()
        {
            TelavatEquipments = new List<TelavatEquipment>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
