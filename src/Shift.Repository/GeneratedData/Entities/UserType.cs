// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Shift.Repository
{
    // UserTypes
    public partial class UserType
    {
        public int Id { get; set; } // ID (Primary key)
        public string Title { get; set; } // Title (length: 200)
        public int PortalId { get; set; } // PortalID
        public int? CreatedBy { get; set; } // CreatedBy
        public int? ModifiedBy { get; set; } // ModifiedBy
        public DateTime? CreateDateTime { get; set; } // CreateDateTime
        public DateTime? LastModifiedDateTime { get; set; } // LastModifiedDateTime

        // Reverse navigation

        /// <summary>
        /// Child UserTypeGroups where [UserTypeGroups].[UserTypeID] point to this entity (FK_UserTypeGroup_UserTypes)
        /// </summary>
        public virtual ICollection<UserTypeGroup> UserTypeGroups { get; set; } // UserTypeGroups.FK_UserTypeGroup_UserTypes

        /// <summary>
        /// Child UserUserTypes where [UserUserTypes].[UserTypeID] point to this entity (FK_UserUserTypes_UserTypes)
        /// </summary>
        public virtual ICollection<UserUserType> UserUserTypes { get; set; } // UserUserTypes.FK_UserUserTypes_UserTypes

        public UserType()
        {
            PortalId = 1;
            UserTypeGroups = new List<UserTypeGroup>();
            UserUserTypes = new List<UserUserType>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
