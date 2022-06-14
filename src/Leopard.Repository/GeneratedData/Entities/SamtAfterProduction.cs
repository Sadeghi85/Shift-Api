// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // SAMT_AfterProductions
    public partial class SamtAfterProduction
    {
        public int Id { get; set; } // ID (Primary key)
        public int? InitialCompilationProgress { get; set; } // InitialCompilationProgress
        public int? MusicMakingProgress { get; set; } // MusicMakingProgress
        public string ComposerName { get; set; } // ComposerName (length: 100)
        public int? CaptionMakingProgress { get; set; } // CaptionMakingProgress
        public string CaptionMakingDescription { get; set; } // CaptionMakingDescription (length: 1000)
        public int? SpecialEffectsProgress { get; set; } // SpecialEffectsProgress
        public int? TrojKarTime { get; set; } // TrojKarTime
        public int? ConpetDesignProgress { get; set; } // ConpetDesignProgress
        public int? ConpetDesignTime { get; set; } // ConpetDesignTime
        public string FieldSpecialEffect { get; set; } // FieldSpecialEffect (length: 100)
        public int? ColorCorrectionProgress { get; set; } // ColorCorrectionProgress
        public int? ColorCorrectionPart { get; set; } // ColorCorrectionPart
        public int? VoiceMixingProgress { get; set; } // VoiceMixingProgress
        public int? VoiceMixingPart { get; set; } // VoiceMixingPart
        public int? FinalCompilationProgress { get; set; } // FinalCompilationProgress
        public int? FinalCompilationPart { get; set; } // FinalCompilationPart
        public int RequestId { get; set; } // RequestID
        public DateTime? CreateDate { get; set; } // CreateDate
        public DateTime? ModifyDate { get; set; } // ModifyDate
        public int? CreatorId { get; set; } // CreatorId

        // Foreign keys

        /// <summary>
        /// Parent SamtRequest pointed by [SAMT_AfterProductions].([RequestId]) (FK_SAMT_AfterProductions_SAMT_Requests)
        /// </summary>
        public virtual SamtRequest SamtRequest { get; set; } // FK_SAMT_AfterProductions_SAMT_Requests

        public SamtAfterProduction()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>