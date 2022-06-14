// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // IranHijriCalendarSetting
    public partial class IranHijriCalendarSetting
    {
        public int Id { get; set; } // ID (Primary key)
        public int DaysInMonth { get; set; } // DaysInMonth
        public DateTime MonthStartDate { get; set; } // MonthStartDate
        public DateTime MonthEndDate { get; set; } // MonthEndDate
        public int HijriMonth { get; set; } // HijriMonth
        public int? CreatedBy { get; set; } // CreatedBy
        public int? ModifiedBy { get; set; } // ModifiedBy
        public DateTime? CreateDateTime { get; set; } // CreateDateTime
        public DateTime? LastModifiedDateTime { get; set; } // LastModifiedDateTime
        public int HijriYear { get; set; } // HijriYear

        public IranHijriCalendarSetting()
        {
            CreateDateTime = DateTime.Now;
            LastModifiedDateTime = DateTime.Now;
            HijriYear = 0;
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>