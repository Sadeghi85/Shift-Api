// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // SAMT_Groups
    public partial class SamtGroup
    {
        public int Id { get; set; } // ID (Primary key)
        public string Title { get; set; } // Title (length: 1000)
        public int PortalId { get; set; } // PortalID
        public int Ordering { get; set; } // Ordering
        public bool IsDeleted { get; set; } // IsDeleted
        public bool NoDashboard { get; set; } // NoDashboard
        public string NumberColor { get; set; } // NumberColor (length: 100)
        public string EstimateGid { get; set; } // EstimateGID (length: 3)

        // Reverse navigation

        /// <summary>
        /// Child SamtRequests where [SAMT_Requests].[GroupID] point to this entity (FK_TelavatRequests_TelavatGroups)
        /// </summary>
        public virtual ICollection<SamtRequest> SamtRequests { get; set; } // SAMT_Requests.FK_TelavatRequests_TelavatGroups

        /// <summary>
        /// Child TelavatGroupPermissions where [TelavatGroupPermissions].[GroupID] point to this entity (FK_TelavatGroupPermissions_TelavatGroups)
        /// </summary>
        public virtual ICollection<TelavatGroupPermission> TelavatGroupPermissions { get; set; } // TelavatGroupPermissions.FK_TelavatGroupPermissions_TelavatGroups

        /// <summary>
        /// Child TelavatGroupsBudgets where [TelavatGroupsBudgets].[GroupID] point to this entity (FK_TelavatGroupsBudgets_TelavatGroups)
        /// </summary>
        public virtual ICollection<TelavatGroupsBudget> TelavatGroupsBudgets { get; set; } // TelavatGroupsBudgets.FK_TelavatGroupsBudgets_TelavatGroups

        /// <summary>
        /// Child TelavatProgramVideos where [TelavatProgramVideos].[GroupID] point to this entity (FK_TelavatProgramVideos_TelavatGroups)
        /// </summary>
        public virtual ICollection<TelavatProgramVideo> TelavatProgramVideos { get; set; } // TelavatProgramVideos.FK_TelavatProgramVideos_TelavatGroups

        // Foreign keys

        /// <summary>
        /// Parent Portal pointed by [SAMT_Groups].([PortalId]) (FK_TelavatGroups_Portals)
        /// </summary>
        public virtual Portal Portal { get; set; } // FK_TelavatGroups_Portals

        public SamtGroup()
        {
            IsDeleted = false;
            NoDashboard = false;
            SamtRequests = new List<SamtRequest>();
            TelavatGroupPermissions = new List<TelavatGroupPermission>();
            TelavatGroupsBudgets = new List<TelavatGroupsBudget>();
            TelavatProgramVideos = new List<TelavatProgramVideo>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
