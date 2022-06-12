// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // DeviceCodes
    public partial class DeviceCode
    {
        public string UserCode { get; set; } // UserCode (Primary key) (length: 200)
        public string DeviceCode_ { get; set; } // DeviceCode (length: 200)
        public string SubjectId { get; set; } // SubjectId (length: 200)
        public string SessionId { get; set; } // SessionId (length: 100)
        public string ClientId { get; set; } // ClientId (length: 200)
        public string Description { get; set; } // Description (length: 200)
        public DateTime CreationTime { get; set; } // CreationTime
        public DateTime Expiration { get; set; } // Expiration
        public string Data { get; set; } // Data

        public DeviceCode()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
