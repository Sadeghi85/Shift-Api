// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // SAMT_ProposalStatusCodes
    public partial class SamtProposalStatusCode
    {
        public int Id { get; set; } // ID (Primary key)
        public string Title { get; set; } // Title (length: 1000)
        public bool IsExpire { get; set; } // IsExpire

        public SamtProposalStatusCode()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>