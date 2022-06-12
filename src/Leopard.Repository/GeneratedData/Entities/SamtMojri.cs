// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // SAMT_Mojri
    public partial class SamtMojri
    {
        public int Id { get; set; } // ID (Primary key)
        public int AgentId { get; set; } // AgentID
        public int? CoreMasterOfficeId { get; set; } // CoreMasterOfficeID
        public bool? IsGuest { get; set; } // IsGuest
        public bool? IsTemp { get; set; } // IsTemp
        public int? EducationDegreeId { get; set; } // EducationDegreeID
        public int? EducationDegreeKindId { get; set; } // EducationDegreeKindID
        public string EducationField { get; set; } // EducationField
        public string EducationPlace { get; set; } // EducationPlace
        public int? MaritalStatusId { get; set; } // MaritalStatusID
        public string ReferrerPerson { get; set; } // ReferrerPerson
        public string ReferrerContact { get; set; } // ReferrerContact
        public string PersonnelPicture { get; set; } // PersonnelPicture
        public int? AddressKindId { get; set; } // AddressKindID
        public int? ProvinceId { get; set; } // ProvinceID
        public string AddressPhone { get; set; } // AddressPhone (length: 50)
        public string AddressPostalCode { get; set; } // AddressPostalCode (length: 50)
        public string Address { get; set; } // Address
        public bool? MojriOfficeIsDeleted { get; set; } // MojriOfficeIsDeleted

        public SamtMojri()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
