// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // TelavatSourceTypes
    public partial class TelavatSourceType
    {
        public int Id { get; set; } // ID (Primary key)
        public int? ParentId { get; set; } // ParentID
        public string Title { get; set; } // Title (length: 1000)
        public int PortalId { get; set; } // PortalID
        public int Ordering { get; set; } // Ordering

        // Foreign keys

        /// <summary>
        /// Parent Portal pointed by [TelavatSourceTypes].([PortalId]) (FK_TelavatSourceTypes_Portals)
        /// </summary>
        public virtual Portal Portal { get; set; } // FK_TelavatSourceTypes_Portals

        public TelavatSourceType()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
