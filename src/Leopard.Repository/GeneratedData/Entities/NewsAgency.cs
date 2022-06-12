// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // NewsAgencies
    public partial class NewsAgency
    {
        public int Id { get; set; } // ID (Primary key)
        public int? ParentId { get; set; } // ParentID
        public string Title { get; set; } // Title (length: 100)
        public string Description { get; set; } // Description (length: 400)
        public int Ordering { get; set; } // Ordering
        public int PortalId { get; set; } // PortalID
        public string IconUri { get; set; } // IconURI (length: 4000)
        public string PictureUri { get; set; } // PictureURI (length: 4000)
        public bool Enabled { get; set; } // Enabled

        // Reverse navigation

        /// <summary>
        /// Child News where [News].[AgencyID] point to this entity (FK_News_NewsAgencies1)
        /// </summary>
        public virtual ICollection<News> News { get; set; } // News.FK_News_NewsAgencies1

        /// <summary>
        /// Child NewsAgenciesUsers where [NewsAgenciesUsers].[AgencyID] point to this entity (FK_NewsAgenciesUsers_NewsAgencies)
        /// </summary>
        public virtual ICollection<NewsAgenciesUser> NewsAgenciesUsers { get; set; } // NewsAgenciesUsers.FK_NewsAgenciesUsers_NewsAgencies

        /// <summary>
        /// Child NewsAgencies where [NewsAgencies].[ParentID] point to this entity (FK_NewsAgencies_NewsAgencies)
        /// </summary>
        public virtual ICollection<NewsAgency> NewsAgencies { get; set; } // NewsAgencies.FK_NewsAgencies_NewsAgencies

        // Foreign keys

        /// <summary>
        /// Parent NewsAgency pointed by [NewsAgencies].([ParentId]) (FK_NewsAgencies_NewsAgencies)
        /// </summary>
        public virtual NewsAgency Parent { get; set; } // FK_NewsAgencies_NewsAgencies

        public NewsAgency()
        {
            News = new List<News>();
            NewsAgencies = new List<NewsAgency>();
            NewsAgenciesUsers = new List<NewsAgenciesUser>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
