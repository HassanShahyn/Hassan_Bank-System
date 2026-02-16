using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HassanBank.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [MaxLength(14)]
        public string NationalId { get; set; } = string.Empty;

        // --- Financial Data Points (بيانات للتحليل المالي) ---

        // صافي الدخل الشهري (أساسي لحساب الـ DBR)
        public decimal MonthlyNetSalary { get; set; }

        // إجمالي الأقساط الشهرية الحالية (التزامات خارجية)
        public decimal TotalExistingMonthlyInstallments { get; set; }

        // عدد سنوات الخبرة في الوظيفة الحالية (لقياس الاستقرار)
        public int YearsInCurrentJob { get; set; }

        // قطاع العمل (حكومي - خاص - أعمال حرة) - بيفرق في الـ Scoring
        public string WorkSector { get; set; } = "Private";

        public DateTime BirthDate { get; set; }

        // المنطقة السكنية (ممكن تستخدم مستقبلاً في الـ Geolocation Scoring)
        public string ResidenceArea { get; set; } = string.Empty;

        // هل تم تحسين البروفايل بناء على نصائحنا؟
        public bool IsProfileOptimized { get; set; }
    }
}
