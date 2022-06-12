// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // VW_SAMT_BaseYear_SIMA
    public partial class VwSamtBaseYearSima
    {
        public int Id { get; set; } // ID
        public string Program { get; set; } // Program (length: 1000)
        public int BaseYear { get; set; } // BaseYear
        public int InitialBaseYear { get; set; } // initialBaseYear
        public int? InitialTime { get; set; } // InitialTime
        public int? LicenseProgramTime { get; set; } // LicenseProgramTime
        public int? LicenseProgramCount { get; set; } // LicenseProgramCount
        public int? LpcMain { get; set; } // lpcMain
        public int? LptMain { get; set; } // lptMain
        public int InitialCount { get; set; } // InitialCount
        public double InitialPayment { get; set; } // InitialPayment
        public int BaseYearTime { get; set; } // BaseYearTime
        public int BaseYearCount { get; set; } // BaseYearCount
        public double BaseYearPayment { get; set; } // BaseYearPayment
        public double? MinuteRate { get; set; } // MinuteRate
        public string EstimateDate { get; set; } // EstimateDate (length: 10)
        public string EstimateNumer { get; set; } // EstimateNumer (length: 1000)
        public string LicenseNumber { get; set; } // LicenseNumber (length: 1000)
        public bool IsDeleted { get; set; } // IsDeleted
        public int GroupId { get; set; } // GroupID
        public int PortalId { get; set; } // PortalID
        public int PartFrom { get; set; } // PartFrom
        public int? PartTo { get; set; } // PartTo
        public int StructureId { get; set; } // StructureID
        public int ProgramGradeId { get; set; } // ProgramGradeID
        public int? StructureTypeId { get; set; } // StructureTypeID
        public bool? HasRevisoryEstimation { get; set; } // HasRevisoryEstimation
        public string EvaluateDate { get; set; } // EvaluateDate (length: 10)
        public double? NumberParticipation { get; set; } // NumberParticipation
        public string TheParticipation { get; set; } // TheParticipation (length: 1000)
        public string LastEstimateDate { get; set; } // LastEstimateDate (length: 10)

        public VwSamtBaseYearSima()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
