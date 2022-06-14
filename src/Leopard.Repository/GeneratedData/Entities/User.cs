// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // Users
    public partial class User
    {
        public int Id { get; set; } // ID (Primary key)
        public string Username { get; set; } // Username (length: 100)
        public string FirstName { get; set; } // FirstName (length: 200)
        public string LastName { get; set; } // LastName (length: 200)
        public string Email { get; set; } // Email (length: 200)
        public string Password { get; set; } // Password
        public string LoginKey { get; set; } // LoginKey (length: 16)
        public int RandomId { get; set; } // RandomID
        public DateTime? LastLogin { get; set; } // LastLogin
        public int PortalId { get; set; } // PortalID
        public DateTime PassExpireDate { get; set; } // PassExpireDate
        public bool UnExpire { get; set; } // UnExpire
        public int FailedPassword { get; set; } // FailedPassword
        public DateTime? FailedPasswordDateTime { get; set; } // FailedPasswordDateTime
        public bool IsLock { get; set; } // IsLock
        public int? QuestionSecurityId { get; set; } // QuestionSecurityID
        public string AnswerQuestionSecurity { get; set; } // AnswerQuestionSecurity (length: 1000)
        public int UserType { get; set; } // UserType
        public int? CreatedBy { get; set; } // CreatedBy
        public int? ModifiedBy { get; set; } // ModifiedBy
        public DateTime? CreateDateTime { get; set; } // CreateDateTime
        public DateTime? LastModifiedDateTime { get; set; } // LastModifiedDateTime
        public string AuthenticationType { get; set; } // AuthenticationType (length: 50)
        public bool EmailConfirmed { get; set; } // EmailConfirmed
        public bool IsAuthenticated { get; set; } // IsAuthenticated
        public string PasswordHash { get; set; } // PasswordHash (length: 150)
        public string PhoneNumber { get; set; } // PhoneNumber (length: 50)

        // Reverse navigation

        /// <summary>
        /// Child SamtProgramTransfers where [SAMT_ProgramTransfers].[CreatedBy] point to this entity (FK_SAMT_ProgramTransfers_Users)
        /// </summary>
        public virtual ICollection<SamtProgramTransfer> SamtProgramTransfers_CreatedBy { get; set; } // SAMT_ProgramTransfers.FK_SAMT_ProgramTransfers_Users

        /// <summary>
        /// Child SamtProgramTransfers where [SAMT_ProgramTransfers].[DeletedBy] point to this entity (FK_SAMT_ProgramTransfers_Users2)
        /// </summary>
        public virtual ICollection<SamtProgramTransfer> SamtProgramTransfers_DeletedBy { get; set; } // SAMT_ProgramTransfers.FK_SAMT_ProgramTransfers_Users2

        /// <summary>
        /// Child SamtProgramTransfers where [SAMT_ProgramTransfers].[ModifiedBy] point to this entity (FK_SAMT_ProgramTransfers_Users1)
        /// </summary>
        public virtual ICollection<SamtProgramTransfer> SamtProgramTransfers_ModifiedBy { get; set; } // SAMT_ProgramTransfers.FK_SAMT_ProgramTransfers_Users1

        /// <summary>
        /// Child SamtRequestLogs where [SAMT_RequestLogs].[CreatedBy] point to this entity (FK_SAMT_RequestLogs_Users)
        /// </summary>
        public virtual ICollection<SamtRequestLog> SamtRequestLogs { get; set; } // SAMT_RequestLogs.FK_SAMT_RequestLogs_Users

        /// <summary>
        /// Child TelavatGroupPermissions where [TelavatGroupPermissions].[UserID] point to this entity (FK_TelavatGroupPermissions_Users)
        /// </summary>
        public virtual ICollection<TelavatGroupPermission> TelavatGroupPermissions { get; set; } // TelavatGroupPermissions.FK_TelavatGroupPermissions_Users

        /// <summary>
        /// Child UsersPortals where [UsersPortals].[UserId] point to this entity (FK_UsersPortals_Users)
        /// </summary>
        public virtual ICollection<UsersPortal> UsersPortals { get; set; } // UsersPortals.FK_UsersPortals_Users

        // Foreign keys

        /// <summary>
        /// Parent Portal pointed by [Users].([PortalId]) (FK_Users_Portals)
        /// </summary>
        public virtual Portal Portal { get; set; } // FK_Users_Portals

        public User()
        {
            Email = "";
            PassExpireDate = DateTime.Now;
            UnExpire = false;
            FailedPassword = 0;
            IsLock = false;
            UserType = 1;
            CreateDateTime = DateTime.Now;
            LastModifiedDateTime = DateTime.Now;
            EmailConfirmed = true;
            IsAuthenticated = true;
            SamtProgramTransfers_CreatedBy = new List<SamtProgramTransfer>();
            SamtProgramTransfers_DeletedBy = new List<SamtProgramTransfer>();
            SamtProgramTransfers_ModifiedBy = new List<SamtProgramTransfer>();
            SamtRequestLogs = new List<SamtRequestLog>();
            TelavatGroupPermissions = new List<TelavatGroupPermission>();
            UsersPortals = new List<UsersPortal>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>