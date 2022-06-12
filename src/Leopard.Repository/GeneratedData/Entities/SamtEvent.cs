// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // SAMT_Events
    public partial class SamtEvent
    {
        public int Id { get; set; } // ID (Primary key)
        public int? ParentId { get; set; } // ParentID
        public bool HasChild { get; set; } // HasChild
        public string EventTitle { get; set; } // EventTitle (length: 100)
        public string EventDescription { get; set; } // EventDescription
        public int EventType { get; set; } // EventType
        public int? EventYear { get; set; } // EventYear
        public int EventMonth { get; set; } // EventMonth
        public int? EventDayFrom { get; set; } // EventDayFrom
        public int? EventDayTo { get; set; } // EventDayTo
        public int? EventDuration { get; set; } // EventDuration
        public bool IsReligious { get; set; } // IsReligious
        public bool IsNational { get; set; } // IsNational
        public bool IsInternational { get; set; } // IsInternational
        public bool IsPublicHoliday { get; set; } // IsPublicHoliday
        public bool Sadness { get; set; } // Sadness
        public bool IsExpired { get; set; } // IsExpired

        public SamtEvent()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
