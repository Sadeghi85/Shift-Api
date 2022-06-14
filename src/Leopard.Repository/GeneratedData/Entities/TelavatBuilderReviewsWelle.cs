// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // TelavatBuilderReviewsWelle
    public partial class TelavatBuilderReviewsWelle
    {
        public int Id { get; set; } // ID (Primary key)
        public int BuilderReviewId { get; set; } // BuilderReviewID
        public int StructureType { get; set; } // StructureType
        public int Type { get; set; } // Type
        public int PartNumber { get; set; } // PartNumber

        // Foreign keys

        /// <summary>
        /// Parent SamtBuilderReview pointed by [TelavatBuilderReviewsWelle].([BuilderReviewId]) (FK_TelavatBuilderwelle_TelavatBuilderReviews)
        /// </summary>
        public virtual SamtBuilderReview SamtBuilderReview { get; set; } // FK_TelavatBuilderwelle_TelavatBuilderReviews

        public TelavatBuilderReviewsWelle()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>