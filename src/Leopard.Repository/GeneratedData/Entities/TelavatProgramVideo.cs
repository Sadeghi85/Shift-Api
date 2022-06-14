// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // TelavatProgramVideos
    public partial class TelavatProgramVideo
    {
        public int Id { get; set; } // ID (Primary key)
        public int? LogId { get; set; } // LogID
        public string ProgramTitle { get; set; } // ProgramTitle (length: 1000)
        public int GroupId { get; set; } // GroupID
        public string EstimateNumer { get; set; } // EstimateNumer (length: 1000)
        public string Producer { get; set; } // Producer (length: 1000)
        public int Part { get; set; } // Part
        public int Time { get; set; } // Time
        public int BandSoundId { get; set; } // BandSoundID
        public string BroadcastDate { get; set; } // BroadcastDate (length: 10)
        public int StructureId { get; set; } // StructureID
        public int TypeId { get; set; } // TypeID
        public int? ExpertId { get; set; } // ExpertID
        public int? ReaderId { get; set; } // ReaderID
        public int? ExecuterId { get; set; } // ExecuterID
        public int SubtitleStatusId { get; set; } // SubtitleStatusID
        public int ProgramStatusId { get; set; } // ProgramStatusID
        public int PlayStatusId { get; set; } // PlayStatusID
        public bool HasLogo { get; set; } // HasLogo
        public int? ProgramOccasionId { get; set; } // ProgramOccasionID
        public string VideoFile { get; set; } // VideoFile (length: 1000)
        public int? CountCorrective { get; set; } // CountCorrective
        public string RegDate { get; set; } // RegDate (length: 10)
        public string RegTime { get; set; } // RegTime (length: 5)
        public string FileName { get; set; } // FileName (length: 1000)
        public string NumberProgram { get; set; } // NumberProgram (length: 1000)
        public int? CreatedBy { get; set; } // CreatedBy
        public int? ModifiedBy { get; set; } // ModifiedBy
        public DateTime? CreateDateTime { get; set; } // CreateDateTime
        public DateTime? LastModifiedDateTime { get; set; } // LastModifiedDateTime
        public bool IsPrinted { get; set; } // IsPrinted
        public string ReviewerName { get; set; } // ReviewerName (length: 1000)
        public string Subject { get; set; } // Subject (length: 1000)
        public bool IsSend { get; set; } // IsSend
        public string PathLocalFile { get; set; } // PathLocalFile (length: 1000)
        public bool IsDeleted { get; set; } // IsDeleted
        public int? SenderUserId { get; set; } // SenderUserID
        public int? ReceiverUserId { get; set; } // ReceiverUserID
        public string ReceiveDate { get; set; } // ReceiveDate (length: 10)
        public string ReceiveTime { get; set; } // ReceiveTime (length: 5)

        // Reverse navigation

        /// <summary>
        /// Child TelavatProgramVideoExperts where [TelavatProgramVideoExperts].[ProgramVideoID] point to this entity (FK_TelavatProgramVideoExperts_TelavatProgramVideos)
        /// </summary>
        public virtual ICollection<TelavatProgramVideoExpert> TelavatProgramVideoExperts { get; set; } // TelavatProgramVideoExperts.FK_TelavatProgramVideoExperts_TelavatProgramVideos

        /// <summary>
        /// Parent (One-to-One) TelavatProgramVideo pointed by [TelavatProgramVideos].[ID] (FK_TelavatProgramVideos_TelavatProgramVideos)
        /// </summary>
        public virtual TelavatProgramVideo TelavatProgramVideo2 { get; set; } // TelavatProgramVideos.FK_TelavatProgramVideos_TelavatProgramVideos

        // Foreign keys

        /// <summary>
        /// Parent SamtGroup pointed by [TelavatProgramVideos].([GroupId]) (FK_TelavatProgramVideos_TelavatGroups)
        /// </summary>
        public virtual SamtGroup SamtGroup { get; set; } // FK_TelavatProgramVideos_TelavatGroups

        /// <summary>
        /// Parent SamtRequestLog pointed by [TelavatProgramVideos].([LogId]) (FK_TelavatProgramVideos_TelavatRequestLogs)
        /// </summary>
        public virtual SamtRequestLog SamtRequestLog { get; set; } // FK_TelavatProgramVideos_TelavatRequestLogs

        /// <summary>
        /// Parent SamtStructure pointed by [TelavatProgramVideos].([StructureId]) (FK_TelavatProgramVideos_TelavatProgramStructures)
        /// </summary>
        public virtual SamtStructure SamtStructure { get; set; } // FK_TelavatProgramVideos_TelavatProgramStructures

        /// <summary>
        /// Parent TelavatBandSound pointed by [TelavatProgramVideos].([BandSoundId]) (FK_TelavatProgramVideos_TelavatBandSounds)
        /// </summary>
        public virtual TelavatBandSound TelavatBandSound { get; set; } // FK_TelavatProgramVideos_TelavatBandSounds

        /// <summary>
        /// Parent TelavatPlayStatu pointed by [TelavatProgramVideos].([PlayStatusId]) (FK_TelavatProgramVideos_TelavatPlayStatus)
        /// </summary>
        public virtual TelavatPlayStatu TelavatPlayStatu { get; set; } // FK_TelavatProgramVideos_TelavatPlayStatus

        /// <summary>
        /// Parent TelavatProgramExpert pointed by [TelavatProgramVideos].([ExecuterId]) (FK_TelavatProgramVideos_TelavatProgramExperts2)
        /// </summary>
        public virtual TelavatProgramExpert Executer { get; set; } // FK_TelavatProgramVideos_TelavatProgramExperts2

        /// <summary>
        /// Parent TelavatProgramExpert pointed by [TelavatProgramVideos].([ExpertId]) (FK_TelavatProgramVideos_TelavatProgramExperts)
        /// </summary>
        public virtual TelavatProgramExpert Expert { get; set; } // FK_TelavatProgramVideos_TelavatProgramExperts

        /// <summary>
        /// Parent TelavatProgramExpert pointed by [TelavatProgramVideos].([ReaderId]) (FK_TelavatProgramVideos_TelavatProgramExperts1)
        /// </summary>
        public virtual TelavatProgramExpert Reader { get; set; } // FK_TelavatProgramVideos_TelavatProgramExperts1

        /// <summary>
        /// Parent TelavatProgramOccasion pointed by [TelavatProgramVideos].([ProgramOccasionId]) (FK_TelavatProgramVideos_TelavatProgramOccasions)
        /// </summary>
        public virtual TelavatProgramOccasion TelavatProgramOccasion { get; set; } // FK_TelavatProgramVideos_TelavatProgramOccasions

        /// <summary>
        /// Parent TelavatProgramStatu pointed by [TelavatProgramVideos].([ProgramStatusId]) (FK_TelavatProgramVideos_TelavatProgramStatus)
        /// </summary>
        public virtual TelavatProgramStatu TelavatProgramStatu { get; set; } // FK_TelavatProgramVideos_TelavatProgramStatus

        /// <summary>
        /// Parent TelavatProgramType pointed by [TelavatProgramVideos].([TypeId]) (FK_TelavatProgramVideos_TelavatProgramTypes)
        /// </summary>
        public virtual TelavatProgramType TelavatProgramType { get; set; } // FK_TelavatProgramVideos_TelavatProgramTypes

        /// <summary>
        /// Parent TelavatProgramVideo pointed by [TelavatProgramVideos].([Id]) (FK_TelavatProgramVideos_TelavatProgramVideos)
        /// </summary>
        public virtual TelavatProgramVideo TelavatProgramVideo1 { get; set; } // FK_TelavatProgramVideos_TelavatProgramVideos

        /// <summary>
        /// Parent TelavatSubtitleStatu pointed by [TelavatProgramVideos].([SubtitleStatusId]) (FK_TelavatProgramVideos_TelavatSubtitleStatus)
        /// </summary>
        public virtual TelavatSubtitleStatu TelavatSubtitleStatu { get; set; } // FK_TelavatProgramVideos_TelavatSubtitleStatus

        public TelavatProgramVideo()
        {
            GroupId = 1;
            EstimateNumer = "";
            Producer = "";
            CountCorrective = 0;
            RegDate = "";
            RegTime = "";
            FileName = "";
            NumberProgram = "";
            IsPrinted = false;
            IsSend = false;
            PathLocalFile = "";
            IsDeleted = false;
            TelavatProgramVideoExperts = new List<TelavatProgramVideoExpert>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>