// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // ApiScopeProperties
    public partial class ApiScopeProperty
    {
        public int Id { get; set; } // Id (Primary key)
        public int ScopeId { get; set; } // ScopeId
        public string Key { get; set; } // Key (length: 250)
        public string Value { get; set; } // Value (length: 2000)

        // Foreign keys

        /// <summary>
        /// Parent ApiScope pointed by [ApiScopeProperties].([ScopeId]) (FK_ApiScopeProperties_ApiScopes_ScopeId)
        /// </summary>
        public virtual ApiScope ApiScope { get; set; } // FK_ApiScopeProperties_ApiScopes_ScopeId

        public ApiScopeProperty()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
