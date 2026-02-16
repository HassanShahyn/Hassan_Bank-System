using HassanBank.Domain.Entities;
using HassanBank.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HassanBank.Domain
{
    public class Opportunity : BaseEntity
    {
        public string OfferType { get; set; } = string.Empty; // مثلاً: شراء مديونية CIB
        public double PotentialAmount { get; set; } // قيمة الصفقة
        public OpportunityStatus Status { get; set; } = OpportunityStatus.Pending; // New, Qualification, Proposal, Closed-Won, Closed-Lost
        public string AssignedSalesId { get; set; } = string.Empty;
        // SLA Management
        public DateTime SlaDeadline { get; set; }
        public string Priority { get; set; } = "Medium";
        public bool IsSlaBreached => DateTime.UtcNow > SlaDeadline && Status == OpportunityStatus.Pending;

        // مربوطة بعميل ومربوطة بمنتج معين اقترحناه
        public Guid ClientId { get; set; } // Foreign Key
        public virtual Client? Client { get; set; }
    }
}
