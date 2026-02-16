using HassanBank.Domain.Entities;
using HassanBank.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HassanBank.Domain
{
    public class Interaction : BaseEntity
    {
        public Guid ClientId { get; set; }
        public string InteractionType { get; set; } = string.Empty; // Call, Meeting, Email
        public string Notes { get; set; } = string.Empty; // تفاصيل المكالمة
        public string Result { get; set; } = string.Empty; // Interested, Not Interested, Callback
        public string SalesRepId { get; set; } = string.Empty;
        public SalesRepRole SalesRepRole { get; set; } // التخصص


        // مين العميل؟

        public virtual Client? Client { get; set; }
    }
}
