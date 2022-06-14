// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // VW_SAMTV2_ProgramTopics
    public partial class VwSamtv2ProgramTopic
    {
        public int Id { get; set; } // ID
        public int? ProductId { get; set; } // productID
        public int PlanTopicId { get; set; } // PlanTopicID
        public int? RootPlanTopicId { get; set; } // RootPlanTopicID
        public int PercentUsed { get; set; } // PercentUsed
        public DateTime FetchDate { get; set; } // FetchDate
        public int? RootPlanTopicIdLevel2 { get; set; } // RootPlanTopicID_LEVEL2

        public VwSamtv2ProgramTopic()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>