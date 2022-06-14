// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // ConductorChannelPrograms
    public partial class ConductorChannelProgram
    {
        public int Id { get; set; } // ID (Primary key)
        public int ChannelId { get; set; } // ChannelID
        public string Title { get; set; } // Title (length: 1000)
        public string Description { get; set; } // Description
        public int PortalId { get; set; } // PortalID
        public bool Enable { get; set; } // Enable
        public bool IsLive { get; set; } // isLive
        public bool IsLocked { get; set; } // IsLocked
        public int? CreatedBy { get; set; } // CreatedBy
        public int? ModifiedBy { get; set; } // ModifiedBy
        public DateTime? CreateDateTime { get; set; } // CreateDateTime
        public DateTime? LastModifiedDateTime { get; set; } // LastModifiedDateTime
        public int? ChannelGroupId { get; set; } // ChannelGroupID
        public int ProgramTypeId { get; set; } // ProgramTypeID
        public int ClacketCount { get; set; } // ClacketCount
        public int ClacketWarning { get; set; } // ClacketWarning
        public string ProgramImage { get; set; } // ProgramImage (length: 1000)
        public string ProgramLogo { get; set; } // ProgramLogo (length: 1000)
        public string ThumbnailProgramLogo { get; set; } // ThumbnailProgramLogo (length: 1000)
        public string ThumbnailProgramImage { get; set; } // ThumbnailProgramImage (length: 1000)
        public int? TaminGroupId { get; set; } // TaminGroupID
        public string AdaptiveTitle { get; set; } // AdaptiveTitle (length: 250)
        public bool IsClipArt { get; set; } // IsClipArt
        public string ProgramTime { get; set; } // ProgramTime (length: 10)
        public string PermissibleDate { get; set; } // PermissibleDate (length: 10)
        public bool IsPlayable { get; set; } // IsPlayable
        public int? ClipArtCategoryId { get; set; } // ClipArtCategoryID
        public int? ClipArtSubCategoryId { get; set; } // ClipArtSubCategoryID
        public string ClipArtSubject { get; set; } // ClipArtSubject (length: 500)
        public string ClipArtProgramNumber { get; set; } // ClipArtProgramNumber (length: 500)
        public int? SubjectId { get; set; } // SubjectID
        public int? FrameId { get; set; } // FrameID
        public string ProgramSummery { get; set; } // ProgramSummery
        public string FurtherInfo { get; set; } // FurtherInfo
        public string ProgramProducer { get; set; } // ProgramProducer (length: 500)
        public int? ProductionType { get; set; } // ProductionType
        public int? BroadcastType { get; set; } // BroadcastType
        public int? ProgramGradeId { get; set; } // ProgramGradeID
        public int? ProgramApproachId { get; set; } // ProgramApproachID
        public string EstimateNumber { get; set; } // EstimateNumber (length: 50)
        public string ProgramIdentity { get; set; } // ProgramIdentity (length: 50)
        public string Director { get; set; } // Director (length: 50)
        public bool? HasPartner { get; set; } // HasPartner
        public string PartnerInfo { get; set; } // PartnerInfo
        public int? AgeRangeId { get; set; } // AgeRangeID
        public int? AgeWarningId { get; set; } // AgeWarningID
        public string GeneralTopic { get; set; } // GeneralTopic (length: 1000)
        public string WebAddress { get; set; } // WebAddress (length: 200)
        public string Email { get; set; } // Email (length: 50)
        public string SocialNetwork { get; set; } // SocialNetwork (length: 200)
        public string Phone { get; set; } // Phone (length: 50)
        public string SmsNumber { get; set; } // SmsNumber (length: 50)
        public int? BroadcastTypeId { get; set; } // BroadcastTypeID
        public int? BroadcastFrameId { get; set; } // BroadcastFrameID
        public int? ClipArtSuitableTimeId { get; set; } // ClipArtSuitableTimeId
        public int? SamtId { get; set; } // SamtId
        public int? TaminTypeId { get; set; } // TaminTypeID
        public bool ShowInRightClickMenu { get; set; } // ShowInRightClickMenu
        public int? RightClickActionAs { get; set; } // RightClickActionAs
        public int? SoundBandId { get; set; } // SoundBandID
        public int? MoeinId { get; set; } // moeinId
        public int? EventId { get; set; } // EventId
        public string FileAddress { get; set; } // FileAddress (length: 1000)
        public int? StructureId { get; set; } // StructureID
        public string CountryProducer { get; set; } // CountryProducer (length: 1000)
        public int? ProductionYear { get; set; } // ProductionYear
        public int? SubStructureId { get; set; } // SubStructureID
        public bool IsFromNegar { get; set; } // IsFromNegar
        public long? ProductId { get; set; } // ProductId
        public bool IsFromSimaDepartment { get; set; } // IsFromSimaDepartment
        public int? ConductorBoxTypeId { get; set; } // ConductorBoxTypeID
        public int? PreprationTypeId { get; set; } // PreprationTypeID
        public int? SimaClipArtApprovalStatus { get; set; } // SimaClipArtApprovalStatus
        public string SimaClipArtApprovalDescription { get; set; } // SimaClipArtApprovalDescription
        public int? SimaClipArtApprovalUserId { get; set; } // SimaClipArtApprovalUserID
        public DateTime? SimaClipArtApprovalDate { get; set; } // SimaClipArtApprovalDate

        // Reverse navigation

        /// <summary>
        /// Parent (One-to-One) ConductorChannelProgram pointed by [ConductorBoxRequest].[ClipArtID] (FK_ConductorBoxRequest_ConductorChannelPrograms)
        /// </summary>
        public virtual ConductorBoxRequest ConductorBoxRequest { get; set; } // ConductorBoxRequest.FK_ConductorBoxRequest_ConductorChannelPrograms

        /// <summary>
        /// Child ConductorBoxItems where [ConductorBoxItems].[ClipArtID] point to this entity (FK_ConductorBoxItems_ConductorChannelPrograms)
        /// </summary>
        public virtual ICollection<ConductorBoxItem> ConductorBoxItems { get; set; } // ConductorBoxItems.FK_ConductorBoxItems_ConductorChannelPrograms

        /// <summary>
        /// Child ConductorBroadcastCertificates where [ConductorBroadcastCertificates].[ProgramID] point to this entity (FK_ConductorBroadcastCertificates_ConductorChannelPrograms)
        /// </summary>
        public virtual ICollection<ConductorBroadcastCertificate> ConductorBroadcastCertificates { get; set; } // ConductorBroadcastCertificates.FK_ConductorBroadcastCertificates_ConductorChannelPrograms

        /// <summary>
        /// Child ConductorChangeLogs where [ConductorChangeLogs].[ProgramID] point to this entity (FK_ConductorChangeLogs_ConductorChannelPrograms)
        /// </summary>
        public virtual ICollection<ConductorChangeLog> ConductorChangeLogs { get; set; } // ConductorChangeLogs.FK_ConductorChangeLogs_ConductorChannelPrograms

        /// <summary>
        /// Child ConductorChannelProgramAgents where [ConductorChannelProgramAgents].[ChannelProgramID] point to this entity (FK_ConductorChannelProgramAgents_ConductorChannelPrograms)
        /// </summary>
        public virtual ICollection<ConductorChannelProgramAgent> ConductorChannelProgramAgents { get; set; } // ConductorChannelProgramAgents.FK_ConductorChannelProgramAgents_ConductorChannelPrograms

        /// <summary>
        /// Child ConductorChannelProgramApprovalLogs where [ConductorChannelProgramApprovalLogs].[ProgramID] point to this entity (FK_ConductorChannelProgramApprovalLog_ConductorChannelPrograms)
        /// </summary>
        public virtual ICollection<ConductorChannelProgramApprovalLog> ConductorChannelProgramApprovalLogs { get; set; } // ConductorChannelProgramApprovalLogs.FK_ConductorChannelProgramApprovalLog_ConductorChannelPrograms

        /// <summary>
        /// Child ConductorChannelProgramEvents where [ConductorChannelProgramEvents].[ChannelProgramID] point to this entity (FK_ConductorChannelProgramEvents_ConductorChannelPrograms)
        /// </summary>
        public virtual ICollection<ConductorChannelProgramEvent> ConductorChannelProgramEvents { get; set; } // ConductorChannelProgramEvents.FK_ConductorChannelProgramEvents_ConductorChannelPrograms

        /// <summary>
        /// Child ConductorChannelProgramInfoes where [ConductorChannelProgramInfo].[ProgramID] point to this entity (FK_ConductorChannelProgramInfo_ConductorChannelPrograms)
        /// </summary>
        public virtual ICollection<ConductorChannelProgramInfo> ConductorChannelProgramInfoes { get; set; } // ConductorChannelProgramInfo.FK_ConductorChannelProgramInfo_ConductorChannelPrograms

        /// <summary>
        /// Child ConductorChannelProgramInTags where [ConductorChannelProgramInTags].[ConductorChannelProgramID] point to this entity (FK_ConductorChannelProgramInTags_ConductorChannelPrograms)
        /// </summary>
        public virtual ICollection<ConductorChannelProgramInTag> ConductorChannelProgramInTags { get; set; } // ConductorChannelProgramInTags.FK_ConductorChannelProgramInTags_ConductorChannelPrograms

        /// <summary>
        /// Child ConductorProgramApproaches where [ConductorProgramApproachs].[ProgramID] point to this entity (FK_ConductorProgramApproachs_ConductorChannelPrograms)
        /// </summary>
        public virtual ICollection<ConductorProgramApproach> ConductorProgramApproaches { get; set; } // ConductorProgramApproachs.FK_ConductorProgramApproachs_ConductorChannelPrograms

        /// <summary>
        /// Child ConductorTablePakhshes where [ConductorTablePakhsh].[ProgramID] point to this entity (FK_ConductorTablePakhsh_ConductorChannelPrograms)
        /// </summary>
        public virtual ICollection<ConductorTablePakhsh> ConductorTablePakhshes { get; set; } // ConductorTablePakhsh.FK_ConductorTablePakhsh_ConductorChannelPrograms

        // Foreign keys

        /// <summary>
        /// Parent SamtStructure pointed by [ConductorChannelPrograms].([StructureId]) (FK_ConductorChannelPrograms_SAMT_Structures)
        /// </summary>
        public virtual SamtStructure SamtStructure { get; set; } // FK_ConductorChannelPrograms_SAMT_Structures

        public ConductorChannelProgram()
        {
            IsLive = false;
            IsLocked = false;
            ProgramTypeId = 1;
            ClacketCount = 0;
            ClacketWarning = 0;
            ProgramImage = "";
            ProgramLogo = "";
            ThumbnailProgramLogo = "";
            ThumbnailProgramImage = "";
            IsClipArt = false;
            IsPlayable = false;
            IsFromNegar = false;
            IsFromSimaDepartment = false;
            ConductorBoxItems = new List<ConductorBoxItem>();
            ConductorBroadcastCertificates = new List<ConductorBroadcastCertificate>();
            ConductorChangeLogs = new List<ConductorChangeLog>();
            ConductorChannelProgramAgents = new List<ConductorChannelProgramAgent>();
            ConductorChannelProgramApprovalLogs = new List<ConductorChannelProgramApprovalLog>();
            ConductorChannelProgramEvents = new List<ConductorChannelProgramEvent>();
            ConductorChannelProgramInfoes = new List<ConductorChannelProgramInfo>();
            ConductorChannelProgramInTags = new List<ConductorChannelProgramInTag>();
            ConductorProgramApproaches = new List<ConductorProgramApproach>();
            ConductorTablePakhshes = new List<ConductorTablePakhsh>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>