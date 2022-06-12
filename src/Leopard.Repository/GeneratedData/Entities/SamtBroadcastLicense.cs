// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // SAMT_BroadcastLicense
    public partial class SamtBroadcastLicense
    {
        public long Id { get; set; } // Id (Primary key)
        public int? BuilderReviewId { get; set; } // BuilderReviewId
        public string LicenseLetterNo { get; set; } // LicenseLetterNo (length: 300)
        public int? SoundBandId { get; set; } // SoundBandId
        public int? ImageRatioId { get; set; } // ImageRatioId
        public int? FileFormatId { get; set; } // FileFormatId
        public int? ProgAgeRangeId { get; set; } // ProgAgeRangeId
        public int? AgeWarningId { get; set; } // AgeWarningId
        public string WebSite { get; set; } // WebSite (length: 300)
        public string Email { get; set; } // Email (length: 100)
        public string SocialNetwork { get; set; } // SocialNetwork (length: 100)
        public string Phone { get; set; } // Phone (length: 50)
        public string SmsNumber { get; set; } // SmsNumber (length: 50)
        public string SmsQuestion { get; set; } // SmsQuestion (length: 1000)
        public bool? HasSubtitle { get; set; } // HasSubtitle
        public string SubtitleText { get; set; } // SubtitleText (length: 1000)
        public string LicenseImg { get; set; } // licenseImg (length: 400)

        // Foreign keys

        /// <summary>
        /// Parent SamtBuilderReview pointed by [SAMT_BroadcastLicense].([BuilderReviewId]) (FK_SAMT_BroadcastLicense_SAMT_BuilderReviews)
        /// </summary>
        public virtual SamtBuilderReview SamtBuilderReview { get; set; } // FK_SAMT_BroadcastLicense_SAMT_BuilderReviews

        public SamtBroadcastLicense()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
