// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // requestBackup2
    public partial class RequestBackup2
    {
        public int RequestId { get; set; } // RequestID (Primary key)
        public string BaseYear { get; set; } // BaseYear (length: 5)
        public string Program { get; set; } // Program (length: 250)
        public int? PortalId { get; set; } // PortalID
        public int? GroupId { get; set; } // GroupID
        public string LicenseNumber { get; set; } // LicenseNumber (length: 17)
        public string ExportationDate { get; set; } // ExportationDate (length: 10)
        public int? ProgramGradeId { get; set; } // ProgramGradeID
        public int? StructureId { get; set; } // StructureID
        public int? LicenseProgramCount { get; set; } // LicenseProgramCount
        public int? TotalTimeMin { get; set; } // TotalTimeMin
        public string ApprovedStartDate { get; set; } // ApprovedStartDate (length: 10)
        public string ApprovedEndDate { get; set; } // ApprovedEndDate (length: 10)
        public string ApprovedBroadCastDate { get; set; } // ApprovedBroadCastDate (length: 10)
        public int? StructureTypeId { get; set; } // StructureTypeID
        public int? ArchivedPercent { get; set; } // ArchivedPercent
        public int? RecordedPercent { get; set; } // RecordedPercent
        public int? LivePercent { get; set; } // LivePercent
        public string EstimateDate { get; set; } // EstimateDate (length: 10)
        public string EstimateNumer { get; set; } // EstimateNumer (length: 20)
        public int? ProgramNumber { get; set; } // ProgramNumber
        public int? Time { get; set; } // Time
        public double? MinuteRate { get; set; } // MinuteRate
        public double? DirectPayment { get; set; } // DirectPayment
        public string OtherDesc { get; set; } // OtherDesc
        public int? EvaluationType { get; set; } // EvaluationType
        public string TheParticipation { get; set; } // TheParticipation (length: 100)
        public int? NumberParticipation { get; set; } // NumberParticipation
        public bool? HasRevisoryEstimation { get; set; } // HasRevisoryEstimation
        public string CorrectiveDesc { get; set; } // CorrectiveDesc (length: 510)
        public string EvaluationEstimateDate { get; set; } // EvaluationEstimateDate (length: 10)
        public int? EvaluationProgramNumber { get; set; } // evaluationProgramNumber
        public int? EvaluationTime { get; set; } // EvaluationTime
        public double? EvaluationMinuteRate { get; set; } // EvaluationMinuteRate
        public double? EvaluationDirectPayment { get; set; } // EvaluationDirectPayment
        public string EvaluationDesc { get; set; } // EvaluationDesc (length: 3000)
        public int? EvaluatedNumberPartnership { get; set; } // EvaluatedNumberPartnership
        public string EvaluatedThePartnership { get; set; } // EvaluatedThePartnership (length: 100)

        public RequestBackup2()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>