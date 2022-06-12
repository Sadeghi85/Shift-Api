// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // RayanModules
    public partial class RayanModule
    {
        public int Id { get; set; } // ID (Primary key)
        public int ModuleDefinitionId { get; set; } // ModuleDefinitionID
        public string Title { get; set; } // Title (length: 200)
        public string ModuleKey { get; set; } // ModuleKey (length: 50)
        public string ModuleFile { get; set; } // ModuleFile (length: 400)
        public bool IsXmlBase { get; set; } // IsXMLBase
        public bool LoginRequired { get; set; } // LoginRequired
        public bool ShowAsModule { get; set; } // ShowAsModule
        public string EnTitle { get; set; } // EnTitle (length: 200)
        public string ArTitle { get; set; } // ArTitle (length: 200)
        public string Description { get; set; } // Description (length: 400)

        // Foreign keys

        /// <summary>
        /// Parent RayanModuleDefinition pointed by [RayanModules].([ModuleDefinitionId]) (FK_RayanModules_RayanModuleDefinitions)
        /// </summary>
        public virtual RayanModuleDefinition RayanModuleDefinition { get; set; } // FK_RayanModules_RayanModuleDefinitions

        public RayanModule()
        {
            IsXmlBase = false;
            LoginRequired = false;
            ShowAsModule = false;
            EnTitle = "";
            ArTitle = "";
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
