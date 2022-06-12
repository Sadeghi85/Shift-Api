// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // ConductorChannelProgCategory
    public partial class ConductorChannelProgCategory
    {
        public int Id { get; set; } // ID (Primary key)
        public string Title { get; set; } // Title (length: 50)
        public bool Enabled { get; set; } // Enabled
        public int ChannelId { get; set; } // ChannelId

        // Reverse navigation

        /// <summary>
        /// Child CondactorChannelProgSubCategories where [CondactorChannelProgSubCategory].[ChannelProgCatID] point to this entity (FK_CondactorChannelProgSubCategory_ConductorChannelProgCategory)
        /// </summary>
        public virtual ICollection<CondactorChannelProgSubCategory> CondactorChannelProgSubCategories { get; set; } // CondactorChannelProgSubCategory.FK_CondactorChannelProgSubCategory_ConductorChannelProgCategory

        public ConductorChannelProgCategory()
        {
            Enabled = true;
            ChannelId = 1;
            CondactorChannelProgSubCategories = new List<CondactorChannelProgSubCategory>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
