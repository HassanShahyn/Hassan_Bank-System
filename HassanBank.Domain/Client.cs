using HassanBank.Domain.Entities;
using HassanBank.Domain.Enums;
using HassanBank.Domain.ValueObjects;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HassanBank.Domain
{
    public class Client : BaseEntity
    {
        public string NationalId { get; set; } = string.Empty;
        public string FullName { get; set; }= string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public ClientSegment Segment { get; set; } = ClientSegment.Prime;
        public Address HomeAddress { get; set; } = new();
        public Address BusinessAddress { get; set; } = new();
        public MailingAddressPreference mailingAddressPreference { get; set; } = MailingAddressPreference.Home;


        // العلاقات (القديمة والجديدة)
        public virtual FinancialProfile? FinancialProfile { get; set; } // الملف المالي
        public virtual ICollection<ClientProduct> Products { get; set; } = new List<ClientProduct>(); // منتجاته (T24)

        // --- الإضافات الجديدة من CRM ---
        public virtual ICollection<Interaction> Interactions { get; set; } = new List<Interaction>(); // هيستوري المكالمات
        public virtual ICollection<Opportunity> Opportunities { get; set; } = new List<Opportunity>(); // فرص البيع
    }
}
