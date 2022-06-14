// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // SAMTV3_StrengthsWeaknesses
    public partial class Samtv3StrengthsWeakness
    {
        public int Id { get; set; } // ID (Primary key)
        public int? ParentId { get; set; } // ParentId
        public bool IsWeakness { get; set; } // IsWeakness
        public string ContentVariable { get; set; } // ContentVariable (length: 500)
        public string Description { get; set; } // Description (length: 4000)
        public bool IsDeleted { get; set; } // IsDeleted
        public int? CreatedBy { get; set; } // CreatedBy
        public DateTime? CreateDateTime { get; set; } // CreateDateTime
        public int? ModifiedBy { get; set; } // ModifiedBy
        public DateTime? LastModifiedDateTime { get; set; } // LastModifiedDateTime

        // Reverse navigation

        /// <summary>
        /// Child Samtv3AssessmentStrengthsWeakness where [SAMTV3_AssessmentStrengthsWeaknesses].[StrengthsWeaknessId] point to this entity (FK_SAMTV3_AssessmentStrengthsWeaknesses_SAMTV3_StrengthsWeaknesses)
        /// </summary>
        public virtual ICollection<Samtv3AssessmentStrengthsWeakness> Samtv3AssessmentStrengthsWeakness { get; set; } // SAMTV3_AssessmentStrengthsWeaknesses.FK_SAMTV3_AssessmentStrengthsWeaknesses_SAMTV3_StrengthsWeaknesses

        public Samtv3StrengthsWeakness()
        {
            Samtv3AssessmentStrengthsWeakness = new List<Samtv3AssessmentStrengthsWeakness>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>