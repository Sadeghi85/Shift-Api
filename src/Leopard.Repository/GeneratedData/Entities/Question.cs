// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leopard.Repository
{
    // Questions
    public partial class Question
    {
        public int Id { get; set; } // ID (Primary key)
        public string Name { get; set; } // Name (length: 200)
        public string Family { get; set; } // Family (length: 400)
        public string Email { get; set; } // Email (length: 200)
        public string Ask { get; set; } // Ask (length: 4000)
        public string Answer { get; set; } // Answer (length: 1073741823)
        public bool Active { get; set; } // Active
        public string QuestionDate { get; set; } // QuestionDate (length: 10)
        public string QuestionCode { get; set; } // QuestionCode (length: 9)
        public string Ip { get; set; } // IP (length: 200)
        public DateTime? Publishdate { get; set; } // Publishdate

        public Question()
        {
            Active = false;
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
