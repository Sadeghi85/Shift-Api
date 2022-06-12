// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // Pakhsh_ChannelLocations
    public partial class PakhshChannelLocation
    {
        public int Id { get; set; } // ID (Primary key)
        public int ChannelId { get; set; } // ChannelID
        public string Title { get; set; } // Title (length: 1000)
        public int? CreatedBy { get; set; } // CreatedBy
        public DateTime? CreateDateTime { get; set; } // CreateDateTime
        public int? ModifiedBy { get; set; } // ModifiedBy
        public DateTime? LastModifiedDateTime { get; set; } // LastModifiedDateTime

        // Foreign keys

        /// <summary>
        /// Parent Portal pointed by [Pakhsh_ChannelLocations].([ChannelId]) (FK_Pakhsh_ChanelLocations_Portals)
        /// </summary>
        public virtual Portal Portal { get; set; } // FK_Pakhsh_ChanelLocations_Portals

        public PakhshChannelLocation()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
