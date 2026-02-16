using HassanBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HassanBank.Domain
{
    public class FinancialProfile : BaseEntity
    {
        public double MonthlyIncome { get; set; }
        public string CompanyName { get; set; } =string.Empty;

        // تفاصيل التحويل (DDS / ACH) اللي اتفقنا عليها
        public string TransferMethod { get; set; } = string.Empty;  // DDS / ASH
        public string CompanyCode { get; set; } = string.Empty; 

        // قواعد الـ Risk
        public bool IsSalaryTransferred { get; set; }
        public bool IsSalaryRegular { get; set; }
        public int IScore { get; set; }

        public Guid ClientId { get; set; }
        public virtual Client? Client { get; set; }
    }
}
