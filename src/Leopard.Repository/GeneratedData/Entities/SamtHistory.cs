// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // SAMT_History
    public partial class SamtHistory
    {
        public int HistoryId { get; set; } // HistoryID (Primary key)
        public string HistoryTitle { get; set; } // HistoryTitle (length: 1000)

        public SamtHistory()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
