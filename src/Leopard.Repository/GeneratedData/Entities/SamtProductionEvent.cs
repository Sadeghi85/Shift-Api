// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // SAMT_ProductionEvents
    public partial class SamtProductionEvent
    {
        public int Id { get; set; } // ID (Primary key)
        public string Title { get; set; } // Title (length: 1000)
        public bool IsDeleted { get; set; } // IsDeleted

        // Reverse navigation

        /// <summary>
        /// Child SamtRequestProductionEvents where [SAMT_RequestProductionEvents].[ProductionEventID] point to this entity (FK_SAMT_RequestProductionEvents_SAMT_ProductionEvents)
        /// </summary>
        public virtual ICollection<SamtRequestProductionEvent> SamtRequestProductionEvents { get; set; } // SAMT_RequestProductionEvents.FK_SAMT_RequestProductionEvents_SAMT_ProductionEvents

        public SamtProductionEvent()
        {
            SamtRequestProductionEvents = new List<SamtRequestProductionEvent>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
