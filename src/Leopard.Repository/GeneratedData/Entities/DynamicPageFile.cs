// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // DynamicPageFiles
    public partial class DynamicPageFile
    {
        public int Id { get; set; } // ID (Primary key)
        public int PageId { get; set; } // PageID
        public int Type { get; set; } // Type
        public string Title { get; set; } // Title
        public string FileName { get; set; } // FileName

        // Foreign keys

        /// <summary>
        /// Parent DynamicPage pointed by [DynamicPageFiles].([PageId]) (FK_DynamicPageFiles_DynamicPages)
        /// </summary>
        public virtual DynamicPage DynamicPage { get; set; } // FK_DynamicPageFiles_DynamicPages

        public DynamicPageFile()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
