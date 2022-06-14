// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // Calendars
    public partial class Calendar
    {
        public int Id { get; set; } // ID (Primary key)
        public string Title { get; set; } // Title (length: 500)
        public string Description { get; set; } // Description
        public string Image { get; set; } // Image (length: 500)
        public string CalendarDate { get; set; } // CalendarDate (length: 10)
        public int Ordering { get; set; } // Ordering
        public int PortalId { get; set; } // PortalID
        public string FullDescription { get; set; } // FullDescription
        public int? CreatedBy { get; set; } // CreatedBy
        public int? ModifiedBy { get; set; } // ModifiedBy
        public DateTime? CreateDateTime { get; set; } // CreateDateTime
        public DateTime? LastModifiedDateTime { get; set; } // LastModifiedDateTime

        public Calendar()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>