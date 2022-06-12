// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // SAMTV2_ProgramTopics
    public partial class Samtv2ProgramTopic
    {
        public int Id { get; set; } // ID (Primary key)
        public int? ProductId { get; set; } // productID
        public int PlanTopicId { get; set; } // PlanTopicID
        public int? RootPlanTopicId { get; set; } // RootPlanTopicID
        public int PercentUsed { get; set; } // PercentUsed
        public DateTime FetchDate { get; set; } // FetchDate

        // Foreign keys

        /// <summary>
        /// Parent Samtv2PlanTopic pointed by [SAMTV2_ProgramTopics].([PlanTopicId]) (FK_SAMTV2_ProgramTopics_SAMTV2_PlanTopics)
        /// </summary>
        public virtual Samtv2PlanTopic Samtv2PlanTopic { get; set; } // FK_SAMTV2_ProgramTopics_SAMTV2_PlanTopics

        public Samtv2ProgramTopic()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
