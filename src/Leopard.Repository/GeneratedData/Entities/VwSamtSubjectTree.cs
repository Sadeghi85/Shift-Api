// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // VW_SAMT_SubjectTree
    public partial class VwSamtSubjectTree
    {
        public int Intpk { get; set; } // Intpk
        public int L4Id { get; set; } // L4ID
        public int? L3Id { get; set; } // L3ID
        public int? L2Id { get; set; } // L2ID
        public int? L1Id { get; set; } // L1ID
        public string L4 { get; set; } // L4 (length: 1000)
        public string L3 { get; set; } // L3 (length: 200)
        public string L2 { get; set; } // L2 (length: 200)
        public string L1 { get; set; } // L1 (length: 200)
        public string FullTitle { get; set; } // FullTitle (length: 1603)
        public bool IsActive { get; set; } // IsActive

        public VwSamtSubjectTree()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>