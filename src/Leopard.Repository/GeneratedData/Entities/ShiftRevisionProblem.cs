// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // Shift_RevisionProblem
    public partial class ShiftRevisionProblem
    {
        public int Id { get; set; } // Id (Primary key)
        public int ShiftTabletId { get; set; } // ShiftTabletId
        public string FileNumber { get; set; } // FileNumber (length: 50)
        public string ProgramName { get; set; } // ProgramName (length: 500)
        public int ClacketNo { get; set; } // ClacketNo
        public string ProblemDescription { get; set; } // ProblemDescription (length: 500)
        public string RevisorCode { get; set; } // RevisorCode (length: 50)
        public string Description { get; set; } // Description (length: 500)
        public int? CreatedBy { get; set; } // CreatedBy
        public int? ModifiedBy { get; set; } // ModifiedBy
        public DateTime? CreateDateTime { get; set; } // CreateDateTime
        public DateTime? LastModifiedDateTime { get; set; } // LastModifiedDateTime
        public bool IsDeleted { get; set; } // IsDeleted

        // Foreign keys

        /// <summary>
        /// Parent ShiftShiftTablet pointed by [Shift_RevisionProblem].([ShiftTabletId]) (FK_Shift_RevisionProblem_Shift_ShiftTablet)
        /// </summary>
        public virtual ShiftShiftTablet ShiftShiftTablet { get; set; } // FK_Shift_RevisionProblem_Shift_ShiftTablet

        public ShiftRevisionProblem()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
