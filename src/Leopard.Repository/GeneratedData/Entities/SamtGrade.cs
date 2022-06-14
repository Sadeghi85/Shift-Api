// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // SAMT_Grades
    public partial class SamtGrade
    {
        public int Id { get; set; } // ID (Primary key)
        public string Title { get; set; } // Title (length: 1000)
        public int Ordering { get; set; } // Ordering
        public bool IsDeleted { get; set; } // IsDeleted
        public bool ShowInDashboard { get; set; } // ShowInDashboard

        // Reverse navigation

        /// <summary>
        /// Child SamtProductionSettings where [SAMT_ProductionSettings].[GradeID] point to this entity (FK_SAMT_ProductionSettings_SAMT_Grades)
        /// </summary>
        public virtual ICollection<SamtProductionSetting> SamtProductionSettings { get; set; } // SAMT_ProductionSettings.FK_SAMT_ProductionSettings_SAMT_Grades

        /// <summary>
        /// Child SamtRequests where [SAMT_Requests].[ProgramGradeID] point to this entity (FK_TelavatRequests_TelavatProgramGrades)
        /// </summary>
        public virtual ICollection<SamtRequest> SamtRequests { get; set; } // SAMT_Requests.FK_TelavatRequests_TelavatProgramGrades

        /// <summary>
        /// Child TelavatBudgets where [TelavatBudgets].[GradeID] point to this entity (FK_TelavatBudgets_TelavatProgramGrades)
        /// </summary>
        public virtual ICollection<TelavatBudget> TelavatBudgets { get; set; } // TelavatBudgets.FK_TelavatBudgets_TelavatProgramGrades

        /// <summary>
        /// Child TelavatGroupsBudgets where [TelavatGroupsBudgets].[GradeID] point to this entity (FK_TelavatGroupsBudgets_TelavatProgramGrades)
        /// </summary>
        public virtual ICollection<TelavatGroupsBudget> TelavatGroupsBudgets { get; set; } // TelavatGroupsBudgets.FK_TelavatGroupsBudgets_TelavatProgramGrades

        public SamtGrade()
        {
            IsDeleted = false;
            ShowInDashboard = true;
            SamtProductionSettings = new List<SamtProductionSetting>();
            SamtRequests = new List<SamtRequest>();
            TelavatBudgets = new List<TelavatBudget>();
            TelavatGroupsBudgets = new List<TelavatGroupsBudget>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>