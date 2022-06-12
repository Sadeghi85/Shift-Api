// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // ClientClaims
    public partial class ClientClaim
    {
        public int Id { get; set; } // Id (Primary key)
        public string Type { get; set; } // Type (length: 250)
        public string Value { get; set; } // Value (length: 250)
        public int ClientId { get; set; } // ClientId

        // Foreign keys

        /// <summary>
        /// Parent Client pointed by [ClientClaims].([ClientId]) (FK_ClientClaims_Clients_ClientId)
        /// </summary>
        public virtual Client Client { get; set; } // FK_ClientClaims_Clients_ClientId

        public ClientClaim()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
