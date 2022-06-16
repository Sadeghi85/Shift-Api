// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // SAMT_Agents
    public partial class SamtAgent
    {
        public int Id { get; set; } // ID (Primary key)
        public string FirstName { get; set; } // FirstName (length: 1000)
        public string LastName { get; set; } // LastName (length: 1000)
        public string NationalCode { get; set; } // NationalCode (length: 20)
        public string PersonnelId { get; set; } // PersonnelID (length: 1000)
        public string Phone { get; set; } // Phone (length: 1000)
        public string Address { get; set; } // Address (length: 4000)
        public string Mobile { get; set; } // Mobile (length: 1000)
        public string StatusEmployment { get; set; } // StatusEmployment (length: 1000)
        public int? WorkTypeId { get; set; } // WorkTypeID
        public bool IsDeleted { get; set; } // IsDeleted
        public string FatherName { get; set; } // FatherName (length: 1000)
        public string RegCardNum { get; set; } // RegCardNum (length: 20)
        public int? BirthPlace { get; set; } // BirthPlace
        public string BirthPlaceTitle { get; set; } // BirthPlaceTitle (length: 1000)
        public string BirthDate { get; set; } // BirthDate (length: 10)
        public bool? Sex { get; set; } // Sex
        public string FaxNum { get; set; } // FaxNum (length: 1000)
        public int? Nationality { get; set; } // Nationality
        public string SpouseDescription { get; set; } // SpouseDescription
        public string Email { get; set; } // Email (length: 1000)
        public int? EducationDegree { get; set; } // EducationDegree
        public string EducationDegreeTitle { get; set; } // EducationDegreeTitle (length: 1000)
        public string EducationField { get; set; } // EducationField (length: 1000)
        public string EmployeeNum { get; set; } // EmployeeNum (length: 20)
        public bool? SimaFilm { get; set; } // SimaFilm
        public bool? IsCompany { get; set; } // IsCompany
        public string PersonImage { get; set; } // PersonImage (length: 500)
        public int? NamMasterOfficeId { get; set; } // NamMasterOfficeID
        public int? NamJobId { get; set; } // NamJobID
        public int? NamCooperationTypeId { get; set; } // NamCooperationTypeID

        // Reverse navigation

        /// <summary>
        /// Child ShiftShiftTabletCrews where [Shift_ShiftTabletCrew].[AgentId] point to this entity (FK_Shift_ShiftTabletCrew_SAMT_Agents)
        /// </summary>
        public virtual ICollection<ShiftShiftTabletCrew> ShiftShiftTabletCrews { get; set; } // Shift_ShiftTabletCrew.FK_Shift_ShiftTabletCrew_SAMT_Agents

        public SamtAgent()
        {
            ShiftShiftTabletCrews = new List<ShiftShiftTabletCrew>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
