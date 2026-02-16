using HassanBank.Domain.Entities;
using HassanBank.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HassanBank.Domain
{
    public abstract class ClientProduct : BaseEntity
    {
        public string ReferenceNumber { get; set; } = string.Empty;
        public double OutstandingAmount { get; set; }
        public decimal InterestRate { get; set; }
        public bool IsActive { get; set; }

        // --- بيانات الـ Buyout (موجودة أهي) ---
        public DateTime StartDate { get; set; } // عشان نحسب الـ 6 شهور
        public Guid ClientId { get; set; }
        public virtual Client? Client { get; set; }
    }
}
