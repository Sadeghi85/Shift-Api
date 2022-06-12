// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // ConductorTablePakhsh
    public partial class ConductorTablePakhsh
    {
        public int Id { get; set; } // ID (Primary key)
        public int ChannelId { get; set; } // ChannelID
        public int ProgramId { get; set; } // ProgramID
        public int ProgramPartNo { get; set; } // ProgramPartNo
        public string BroadcastDate { get; set; } // BroadcastDate (length: 10)
        public TimeSpan BroadcastTime { get; set; } // BroadcastTime
        public TimeSpan ProgramLength { get; set; } // ProgramLength
        public TimeSpan EndTime { get; set; } // EndTime
        public bool IsLocked { get; set; } // isLocked
        public int WeekNumber { get; set; } // WeekNumber
        public int VersionNumber { get; set; } // VersionNumber
        public bool IsReleased { get; set; } // isReleased
        public int ReleasedVersion { get; set; } // ReleasedVersion
        public int CurrentStatus { get; set; } // CurrentStatus
        public string Description { get; set; } // Description (length: 500)
        public int? CreatedBy { get; set; } // CreatedBy
        public int? ModifiedBy { get; set; } // ModifiedBy
        public DateTime? CreateDateTime { get; set; } // CreateDateTime
        public DateTime? LastModifiedDateTime { get; set; } // LastModifiedDateTime
        public bool IsRepeat { get; set; } // isRepeat
        public bool IsLive { get; set; } // isLive
        public bool IsBuggy { get; set; } // isBuggy
        public string FullDescription { get; set; } // FullDescription (length: 4000)
        public string RegieDescription { get; set; } // RegieDescription (length: 4000)
        public string Source { get; set; } // Source (length: 4000)
        public string TapeNumber { get; set; } // TapeNumber (length: 4000)
        public bool IsWorkedByRegie { get; set; } // IsWorkedByRegie
        public int? SystemId { get; set; } // SystemID
        public bool HasTimeChange { get; set; } // HasTimeChange
        public int? TimeChangeBy { get; set; } // TimeChangeBy
        public bool IsCordinator { get; set; } // IsCordinator
        public bool IsBroadCastUser { get; set; } // IsBroadCastUser
        public bool IsDeleted { get; set; } // IsDeleted
        public DateTime? CordinatorLastChangeDate { get; set; } // CordinatorLastChangeDate
        public DateTime? BroadCastUserLastChangeDate { get; set; } // BroadCastUserLastChangeDate
        public bool IsBold { get; set; } // IsBold
        public int? ParentId { get; set; } // ParentId
        public DateTime? SentToBroadcastDateTime { get; set; } // SentToBroadcastDateTime
        public int Ordering { get; set; } // Ordering
        public int? BoxItemId { get; set; } // BoxItemID

        // Reverse navigation

        /// <summary>
        /// Child ConductorBroadcastCertificates where [ConductorBroadcastCertificates].[ConductorID] point to this entity (FK_ConductorBroadcastCertificates_ConductorTablePakhsh)
        /// </summary>
        public virtual ICollection<ConductorBroadcastCertificate> ConductorBroadcastCertificates { get; set; } // ConductorBroadcastCertificates.FK_ConductorBroadcastCertificates_ConductorTablePakhsh

        /// <summary>
        /// Child ConductorItemDispatches where [ConductorItemDispatch].[RequestID] point to this entity (FK_ConductorItemDispatch_ConductorTablePakhsh)
        /// </summary>
        public virtual ICollection<ConductorItemDispatch> ConductorItemDispatches { get; set; } // ConductorItemDispatch.FK_ConductorItemDispatch_ConductorTablePakhsh

        // Foreign keys

        /// <summary>
        /// Parent ConductorChannelProgram pointed by [ConductorTablePakhsh].([ProgramId]) (FK_ConductorTablePakhsh_ConductorChannelPrograms)
        /// </summary>
        public virtual ConductorChannelProgram ConductorChannelProgram { get; set; } // FK_ConductorTablePakhsh_ConductorChannelPrograms

        public ConductorTablePakhsh()
        {
            ProgramPartNo = 0;
            CurrentStatus = 0;
            IsRepeat = false;
            IsLive = false;
            IsBuggy = false;
            IsWorkedByRegie = false;
            HasTimeChange = false;
            IsCordinator = false;
            IsBroadCastUser = false;
            IsDeleted = false;
            IsBold = false;
            Ordering = 0;
            ConductorBroadcastCertificates = new List<ConductorBroadcastCertificate>();
            ConductorItemDispatches = new List<ConductorItemDispatch>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
