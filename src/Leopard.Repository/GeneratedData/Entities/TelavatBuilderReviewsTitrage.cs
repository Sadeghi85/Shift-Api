// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // TelavatBuilderReviewsTitrages
    public partial class TelavatBuilderReviewsTitrage
    {
        public int Id { get; set; } // ID (Primary key)
        public int BuilderReviewId { get; set; } // BuilderReviewID
        public bool IsStart { get; set; } // IsStart
        public int Type { get; set; } // Type

        // Foreign keys

        /// <summary>
        /// Parent SamtBuilderReview pointed by [TelavatBuilderReviewsTitrages].([BuilderReviewId]) (FK_TelavatBuilderReviewsTitrages_TelavatBuilderReviews)
        /// </summary>
        public virtual SamtBuilderReview SamtBuilderReview { get; set; } // FK_TelavatBuilderReviewsTitrages_TelavatBuilderReviews

        public TelavatBuilderReviewsTitrage()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
