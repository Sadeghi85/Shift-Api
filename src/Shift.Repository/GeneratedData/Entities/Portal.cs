// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Shift.Repository
{
    // Portals
    public partial class Portal
    {
        public int Id { get; set; } // ID (Primary key)
        public string Title { get; set; } // Title (length: 200)
        public string Domain { get; set; } // Domain (length: 200)
        public int? ParentId { get; set; } // ParentID
        public string Description { get; set; } // Description (length: 1000)
        public string Alias { get; set; } // Alias (length: 20)
        public string Direction { get; set; } // Direction (length: 3)
        public string Language { get; set; } // Language (length: 6)
        public string Favicon { get; set; } // Favicon (length: 100)
        public int? CreatedBy { get; set; } // CreatedBy
        public int? ModifiedBy { get; set; } // ModifiedBy
        public DateTime? CreateDateTime { get; set; } // CreateDateTime
        public DateTime? LastModifiedDateTime { get; set; } // LastModifiedDateTime
        public bool ShowHerOwnLogo { get; set; } // ShowHerOwnLogo
        public bool NoDashboard { get; set; } // NoDashboard
        public string TitleAlias { get; set; } // TitleAlias (length: 150)
        public string MetaDescription { get; set; } // MetaDescription (length: 250)
        public string MetaKeyWord { get; set; } // MetaKeyWord (length: 250)
        public string FolderAlias { get; set; } // FolderAlias (length: 250)
        public string ValidLoginIps { get; set; } // ValidLoginIps (length: 4000)
        public int Qouta { get; set; } // Qouta
        public int Ordering { get; set; } // Ordering
        public int? MoeinId { get; set; } // MoeinId
        public bool IsSelected { get; set; } // IsSelected
        public int? ChannelLatinId { get; set; } // ChannelLatinID
        public int? EpgKey { get; set; } // EPGKey
        public int? SamtId { get; set; } // SamtId
        public int? ChehrehId { get; set; } // ChehrehId
        public bool Enable { get; set; } // Enable
        public string IconName { get; set; } // IconName (length: 50)
        public int? PortalId { get; set; } // PortalID
        public string UidLevel { get; set; } // UIDLevel (length: 2)

        // Reverse navigation

        /// <summary>
        /// Child ShiftEmploymentDetails where [Shift_EmploymentDetail].[portalID] point to this entity (FK_Shift_EmploymentDetail_Portals)
        /// </summary>
        public virtual ICollection<ShiftEmploymentDetail> ShiftEmploymentDetails { get; set; } // Shift_EmploymentDetail.FK_Shift_EmploymentDetail_Portals

        /// <summary>
        /// Child ShiftPortalLocations where [Shift_PortalLocations].[PortalID] point to this entity (FK_Shift_ShiftTabletLocation_Portals)
        /// </summary>
        public virtual ICollection<ShiftPortalLocation> ShiftPortalLocations { get; set; } // Shift_PortalLocations.FK_Shift_ShiftTabletLocation_Portals

        /// <summary>
        /// Child ShiftShifts where [Shift_Shift].[PortalID] point to this entity (FK_PortalShift_Portals)
        /// </summary>
        public virtual ICollection<ShiftShift> ShiftShifts { get; set; } // Shift_Shift.FK_PortalShift_Portals

        /// <summary>
        /// Child ShiftShiftTablets where [Shift_ShiftTablet].[PortalID] point to this entity (FK_Shift_ShiftTablet_Portals)
        /// </summary>
        public virtual ICollection<ShiftShiftTablet> ShiftShiftTablets { get; set; } // Shift_ShiftTablet.FK_Shift_ShiftTablet_Portals

        /// <summary>
        /// Child Users where [Users].[PortalID] point to this entity (FK_Users_Portals)
        /// </summary>
        public virtual ICollection<User> Users { get; set; } // Users.FK_Users_Portals

        /// <summary>
        /// Child UsersPortals where [UsersPortals].[PortalId] point to this entity (FK_UsersPortals_Portals)
        /// </summary>
        public virtual ICollection<UsersPortal> UsersPortals { get; set; } // UsersPortals.FK_UsersPortals_Portals

        public Portal()
        {
            Domain = "";
            Description = "";
            Alias = "";
            Language = "fa";
            Favicon = "";
            ShowHerOwnLogo = false;
            NoDashboard = false;
            Qouta = 0;
            Ordering = 0;
            IsSelected = false;
            Enable = true;
            ShiftEmploymentDetails = new List<ShiftEmploymentDetail>();
            ShiftPortalLocations = new List<ShiftPortalLocation>();
            ShiftShifts = new List<ShiftShift>();
            ShiftShiftTablets = new List<ShiftShiftTablet>();
            Users = new List<User>();
            UsersPortals = new List<UsersPortal>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
