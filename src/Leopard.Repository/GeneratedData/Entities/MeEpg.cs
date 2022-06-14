// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // ME_Epg
    public partial class MeEpg
    {
        public long EpgId { get; set; } // EpgId (Primary key)
        public long? StateId { get; set; } // StateId
        public string Date { get; set; } // Date (length: 10)
        public string StartTime { get; set; } // StartTime (length: 12)
        public string EndTime { get; set; } // EndTime (length: 12)
        public long? NetworkId { get; set; } // NetworkId
        public string NetworkName { get; set; } // NetworkName (length: 500)
        public string Title { get; set; } // Title (length: 500)
        public int? IsReplay { get; set; } // IsReplay
        public int? IsRepeat { get; set; } // IsRepeat
        public string Summary { get; set; } // Summary
        public int? IsCommercials { get; set; } // IsCommercials
        public int? IsInterlude { get; set; } // IsInterlude
        public long? LiveProgramTypeId { get; set; } // LiveProgramTypeId
        public string LiveProgramTypeName { get; set; } // LiveProgramTypeName (length: 500)
        public string LiveBroadcastModeName { get; set; } // LiveBroadcastModeName (length: 500)
        public string ProductionStateName { get; set; } // ProductionStateName (length: 500)
        public string GenreString { get; set; } // GenreString (length: 500)
        public string FormatString { get; set; } // FormatString (length: 500)
        public string GenreTagging { get; set; } // GenreTagging (length: 500)
        public string FormatTagging { get; set; } // FormatTagging (length: 500)
        public int? Rownum { get; set; } // rownum
        public long? MainId { get; set; } // MainId
        public long? MetaId { get; set; } // MetaId
        public long? SubItemId { get; set; } // Sub_Item_ID
        public DateTime CreateDateTime { get; set; } // CreateDateTime (Primary key)
        public DateTime? LastModifiedDateTime { get; set; } // LastModifiedDateTime

        public MeEpg()
        {
            CreateDateTime = DateTime.Now;
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>