// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Shift.Repository
{
    // Shift_EmploymentDetail
    /// <summary>
    /// ثابت هایی که به نوع همکاری و شبکه وابسته هست و به حقوق عوامل اعمال میشود.
    /// </summary>
    public partial class ShiftEmploymentDetail
    {
        public int Id { get; set; } // ID (Primary key)
        public int RequiredShift { get; set; } // RequiredShift
        public int? PerformancePaymentMultiplicationPercent { get; set; } // PerformancePaymentMultiplicationPercent
        public int PerformancePaymentAmount { get; set; } // performancePaymentAmount
        public int? LivePaymenetPercent { get; set; } // LivePaymenetPercent
        public int? LivePaymenetAmount { get; set; } // LivePaymenetAmount
        public int CreatedBy { get; set; } // CreatedBy
        public int ModifiedBy { get; set; } // ModifiedBy
        public DateTime CreateDateTime { get; set; } // CreateDateTime
        public DateTime LastModifiedDateTime { get; set; } // LastModifiedDateTime
        public int? SpecialDayPaymentAmount { get; set; } // SpecialDayPaymentAmount
        public int? SpecialDayPaymetMultiplicationPercent { get; set; } // SpecialDayPaymetMultiplicationPercent
        public int? PortalId { get; set; } // portalID
        public int? UnrequiredShiftPayment { get; set; } // UnrequiredShiftPayment
        public int? CooperationTypeId { get; set; } // CooperationTypeID
        public bool IsDeleted { get; set; } // IsDeleted

        // Foreign keys

        /// <summary>
        /// Parent Portal pointed by [Shift_EmploymentDetail].([PortalId]) (FK_Shift_EmploymentDetail_Portals)
        /// </summary>
        [JsonIgnore]
        public virtual Portal Portal { get; set; } // FK_Shift_EmploymentDetail_Portals

        /// <summary>
        /// Parent SamtHrCooperationType pointed by [Shift_EmploymentDetail].([CooperationTypeId]) (FK_Shift_EmploymentDetail_SAMT_HRCooperationType)
        /// </summary>
        [JsonIgnore]
        public virtual SamtHrCooperationType SamtHrCooperationType { get; set; } // FK_Shift_EmploymentDetail_SAMT_HRCooperationType

        public ShiftEmploymentDetail()
        {
            IsDeleted = false;
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
