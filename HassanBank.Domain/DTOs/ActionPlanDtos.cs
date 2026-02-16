using HassanBank.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HassanBank.Domain.DTOs
{
    public class ClientProfileDto
    {
        public decimal MonthlyIncome { get; set; }
        public decimal TotalExistingIstallments { get; set; }   
        public int MonthlyInCurrentBusiness     { get; set; }
        public string TypeWorkSector { get; set; } = " private";
    }
    public class ProductEligibilityCriteria
    {
        public ProductType TargetProduct { get; set; }
        public decimal MinRequiredIncome { get; set; } // الحد الأدنى للدخل
        public int MinMonthsOfExperience { get; set; } // الحد الأدنى للخبرة
        public decimal MaxAllowedDBR { get; set; } = 0.50m; // أقصى نسبة ديون (50%)
    }
    // 3. العلبة اللي هنرجع فيها الرد (الخطة والنصيحة)
    public class ActionPlanResult
    {
        public bool IsEligibleNow { get; set; } // هل ينفع ياخد قرض دلوقتي؟
        public List<string> ImprovementSteps { get; set; } = new List<string>(); // خطوات التحسين
        public string EligibilityStatus { get; set; } = string.Empty; // رسالة الحالة
    }
}
