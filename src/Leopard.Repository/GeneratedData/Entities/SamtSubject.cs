// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // SAMT_Subjects
    public partial class SamtSubject
    {
        public int Id { get; set; } // ID (Primary key)
        public int? ParentId { get; set; } // ParentID
        public string Title { get; set; } // Title (length: 1000)
        public int SubjectLevel { get; set; } // SubjectLevel
        public int? SubjectOrder { get; set; } // SubjectOrder
        public bool IsActive { get; set; } // IsActive
        public bool IsDeleted { get; set; } // IsDeleted

        // Reverse navigation

        /// <summary>
        /// Child ConductorItemDispatchSubjects where [ConductorItemDispatchSubjects].[SubjectID] point to this entity (FK_ConductorItemDispatchSubjects_SAMT_Subjects)
        /// </summary>
        public virtual ICollection<ConductorItemDispatchSubject> ConductorItemDispatchSubjects { get; set; } // ConductorItemDispatchSubjects.FK_ConductorItemDispatchSubjects_SAMT_Subjects

        /// <summary>
        /// Child SamtRequests where [SAMT_Requests].[MainSubjectID] point to this entity (FK_TelavatRequests_TelavatSubjects)
        /// </summary>
        public virtual ICollection<SamtRequest> SamtRequests { get; set; } // SAMT_Requests.FK_TelavatRequests_TelavatSubjects

        /// <summary>
        /// Child SamtRequestLogSubjects where [SAMT_RequestLogSubjects].[SubjectID] point to this entity (FK_SAMT_RequestLogSubjects_TelavatSubjects)
        /// </summary>
        public virtual ICollection<SamtRequestLogSubject> SamtRequestLogSubjects { get; set; } // SAMT_RequestLogSubjects.FK_SAMT_RequestLogSubjects_TelavatSubjects

        /// <summary>
        /// Child SamtRequestSubjects where [SAMT_RequestSubjects].[SubjectID] point to this entity (FK_TelavatRequestSubjects_TelavatSubjects)
        /// </summary>
        public virtual ICollection<SamtRequestSubject> SamtRequestSubjects { get; set; } // SAMT_RequestSubjects.FK_TelavatRequestSubjects_TelavatSubjects

        /// <summary>
        /// Child Samtv3MonitoringKeyword where [SAMTV3_MonitoringKeywords].[KeywordId] point to this entity (FK_SAMTV3_MonitoringKeywords_SAMT_Subjects)
        /// </summary>
        public virtual ICollection<Samtv3MonitoringKeyword> Samtv3MonitoringKeyword { get; set; } // SAMTV3_MonitoringKeywords.FK_SAMTV3_MonitoringKeywords_SAMT_Subjects

        /// <summary>
        /// Child Samtv3MonitoringSubject where [SAMTV3_MonitoringSubjects].[SubjectId] point to this entity (FK_SAMTV3_MonitoringSubjects_SAMT_Subjects)
        /// </summary>
        public virtual ICollection<Samtv3MonitoringSubject> Samtv3MonitoringSubject { get; set; } // SAMTV3_MonitoringSubjects.FK_SAMTV3_MonitoringSubjects_SAMT_Subjects

        public SamtSubject()
        {
            IsDeleted = false;
            ConductorItemDispatchSubjects = new List<ConductorItemDispatchSubject>();
            SamtRequestLogSubjects = new List<SamtRequestLogSubject>();
            SamtRequests = new List<SamtRequest>();
            SamtRequestSubjects = new List<SamtRequestSubject>();
            Samtv3MonitoringKeyword = new List<Samtv3MonitoringKeyword>();
            Samtv3MonitoringSubject = new List<Samtv3MonitoringSubject>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>