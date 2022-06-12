// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // SAMT_BuilderReviews
    public partial class SamtBuilderReview
    {
        public int Id { get; set; } // ID (Primary key)
        public int LogId { get; set; } // LogID
        public bool? IsLive { get; set; } // IsLive
        public string Subject { get; set; } // Subject
        public string ReviewDate { get; set; } // ReviewDate (length: 10)
        public string BroadcastDate { get; set; } // BroadcastDate (length: 10)
        public string BroadcasTime { get; set; } // BroadcasTime (length: 5)
        public int? TitrageStartStructureType { get; set; } // TitrageStart_StructureType
        public int? TitrageStartTime { get; set; } // TitrageStart_Time
        public string TitrageStartDesc { get; set; } // TitrageStart_Desc
        public string Presenter { get; set; } // Presenter
        public string Expert { get; set; } // Expert
        public string DirectGuest { get; set; } // DirectGuest
        public string PhoneGuest { get; set; } // PhoneGuest
        public string Location { get; set; } // Location
        public int? TitrageEndStructureType { get; set; } // TitrageEnd_StructureType
        public int? TitrageEndTime { get; set; } // TitrageEnd_Time
        public string TitrageEndDesc { get; set; } // TitrageEnd_Desc
        public string Problems { get; set; } // Problems
        public int? CreatedBy { get; set; } // CreatedBy
        public int? ModifiedBy { get; set; } // ModifiedBy
        public DateTime? CreateDateTime { get; set; } // CreateDateTime
        public DateTime? LastModifiedDateTime { get; set; } // LastModifiedDateTime
        public int? OmidId { get; set; } // OmidId
        public int? QuranId { get; set; } // QuranId

        // Reverse navigation

        /// <summary>
        /// Child SamtBroadcastLicenses where [SAMT_BroadcastLicense].[BuilderReviewId] point to this entity (FK_SAMT_BroadcastLicense_SAMT_BuilderReviews)
        /// </summary>
        public virtual ICollection<SamtBroadcastLicense> SamtBroadcastLicenses { get; set; } // SAMT_BroadcastLicense.FK_SAMT_BroadcastLicense_SAMT_BuilderReviews

        /// <summary>
        /// Child TelavatBuilderReviewsItems where [TelavatBuilderReviewsItems].[BuilderReviewID] point to this entity (FK_TelavatBuilderReviewsItems_TelavatBuilderReviews)
        /// </summary>
        public virtual ICollection<TelavatBuilderReviewsItem> TelavatBuilderReviewsItems { get; set; } // TelavatBuilderReviewsItems.FK_TelavatBuilderReviewsItems_TelavatBuilderReviews

        /// <summary>
        /// Child TelavatBuilderReviewsTitrages where [TelavatBuilderReviewsTitrages].[BuilderReviewID] point to this entity (FK_TelavatBuilderReviewsTitrages_TelavatBuilderReviews)
        /// </summary>
        public virtual ICollection<TelavatBuilderReviewsTitrage> TelavatBuilderReviewsTitrages { get; set; } // TelavatBuilderReviewsTitrages.FK_TelavatBuilderReviewsTitrages_TelavatBuilderReviews

        /// <summary>
        /// Child TelavatBuilderReviewsWelles where [TelavatBuilderReviewsWelle].[BuilderReviewID] point to this entity (FK_TelavatBuilderwelle_TelavatBuilderReviews)
        /// </summary>
        public virtual ICollection<TelavatBuilderReviewsWelle> TelavatBuilderReviewsWelles { get; set; } // TelavatBuilderReviewsWelle.FK_TelavatBuilderwelle_TelavatBuilderReviews

        // Foreign keys

        /// <summary>
        /// Parent SamtRequestLog pointed by [SAMT_BuilderReviews].([LogId]) (FK_TelavatBuilderReviews_TelavatRequestLogs)
        /// </summary>
        public virtual SamtRequestLog SamtRequestLog { get; set; } // FK_TelavatBuilderReviews_TelavatRequestLogs

        public SamtBuilderReview()
        {
            SamtBroadcastLicenses = new List<SamtBroadcastLicense>();
            TelavatBuilderReviewsItems = new List<TelavatBuilderReviewsItem>();
            TelavatBuilderReviewsTitrages = new List<TelavatBuilderReviewsTitrage>();
            TelavatBuilderReviewsWelles = new List<TelavatBuilderReviewsWelle>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
