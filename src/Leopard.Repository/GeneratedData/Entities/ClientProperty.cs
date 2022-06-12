// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // ClientProperties
    public partial class ClientProperty
    {
        public int Id { get; set; } // Id (Primary key)
        public int ClientId { get; set; } // ClientId
        public string Key { get; set; } // Key (length: 250)
        public string Value { get; set; } // Value (length: 2000)

        // Foreign keys

        /// <summary>
        /// Parent Client pointed by [ClientProperties].([ClientId]) (FK_ClientProperties_Clients_ClientId)
        /// </summary>
        public virtual Client Client { get; set; } // FK_ClientProperties_Clients_ClientId

        public ClientProperty()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
