// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // View_SendFile1
    public partial class ViewSendFile1
    {
        public int PortalId { get; set; } // PortalID
        public int CategoryId { get; set; } // CategoryID
        public string CategoryName { get; set; } // CategoryName
        public string PortalName { get; set; } // PortalName (length: 200)
        public int? ParentId { get; set; } // ParentID
        public int ReminderTimeId { get; set; } // ReminderTimeID

        public ViewSendFile1()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>