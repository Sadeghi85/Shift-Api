// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // Shift_Log
    public partial class ShiftLog
    {
        public int Id { get; set; } // ID (Primary key)
        public string Message { get; set; } // Message (length: 2147483647)
        public DateTime? CreateDateTime { get; set; } // CreateDateTime

        public ShiftLog()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
