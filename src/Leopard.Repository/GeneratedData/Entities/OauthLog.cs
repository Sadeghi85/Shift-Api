// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // OauthLogs
    public partial class OauthLog
    {
        public int Id { get; set; } // ID (Primary key)
        public string Token { get; set; } // Token
        public string Response { get; set; } // Response
        public DateTime DateReg { get; set; } // DateReg

        public OauthLog()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
