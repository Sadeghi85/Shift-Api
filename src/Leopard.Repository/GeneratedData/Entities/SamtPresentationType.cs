// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // SAMT_PresentationType
    public partial class SamtPresentationType
    {
        public int PresentationTypeId { get; set; } // PresentationTypeID (Primary key)
        public string PresentationTypeTitle { get; set; } // PresentationTypeTitle (length: 1000)

        public SamtPresentationType()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
