// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Shift.Repository
{
    // UsersPortals
    public partial class UsersPortal
    {
        public int Id { get; set; } // ID (Primary key)
        public int UserId { get; set; } // UserId
        public int PortalId { get; set; } // PortalId
        public int? CreatedBy { get; set; } // CreatedBy
        public int? ModifiedBy { get; set; } // ModifiedBy
        public DateTime? CreateDateTime { get; set; } // CreateDateTime
        public DateTime? LastModifiedDateTime { get; set; } // LastModifiedDateTime

        // Foreign keys

        /// <summary>
        /// Parent Portal pointed by [UsersPortals].([PortalId]) (FK_UsersPortals_Portals)
        /// </summary>
        public virtual Portal Portal { get; set; } // FK_UsersPortals_Portals

        /// <summary>
        /// Parent User pointed by [UsersPortals].([UserId]) (FK_UsersPortals_Users)
        /// </summary>
        public virtual User User { get; set; } // FK_UsersPortals_Users

        public UsersPortal()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
