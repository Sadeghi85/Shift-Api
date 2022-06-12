// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // SAMT_RequestSubjects
    public partial class SamtRequestSubject
    {
        public int Id { get; set; } // ID (Primary key)
        public int RequestId { get; set; } // RequestID
        public int SubjectId { get; set; } // SubjectID
        public int SubjectPercent { get; set; } // SubjectPercent
        public bool IsDeleted { get; set; } // IsDeleted

        // Foreign keys

        /// <summary>
        /// Parent SamtRequest pointed by [SAMT_RequestSubjects].([RequestId]) (FK_TelavatRequestSubjects_SAMT_Requests)
        /// </summary>
        public virtual SamtRequest SamtRequest { get; set; } // FK_TelavatRequestSubjects_SAMT_Requests

        /// <summary>
        /// Parent SamtSubject pointed by [SAMT_RequestSubjects].([SubjectId]) (FK_TelavatRequestSubjects_TelavatSubjects)
        /// </summary>
        public virtual SamtSubject SamtSubject { get; set; } // FK_TelavatRequestSubjects_TelavatSubjects

        public SamtRequestSubject()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
