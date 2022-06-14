// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // ApiResourceClaims
    public partial class ApiResourceClaim
    {
        public int Id { get; set; } // Id (Primary key)
        public int ApiResourceId { get; set; } // ApiResourceId
        public string Type { get; set; } // Type (length: 200)

        // Foreign keys

        /// <summary>
        /// Parent ApiResource pointed by [ApiResourceClaims].([ApiResourceId]) (FK_ApiResourceClaims_ApiResources_ApiResourceId)
        /// </summary>
        public virtual ApiResource ApiResource { get; set; } // FK_ApiResourceClaims_ApiResources_ApiResourceId

        public ApiResourceClaim()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>