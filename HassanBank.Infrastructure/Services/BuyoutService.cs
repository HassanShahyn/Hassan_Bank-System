using HassanBank.Domain.Enums;
using HassanBank.Domain.Interfaces;
using HassanBank.Domain; // عشان يشوف ClientProduct
using System;

namespace HassanBank.Infrastructure.Services // أو HassanBank.Web.Services حسب مكانك
{
    public class BuyoutService : IBuyoutService
    {
        // التحقق من الأهلية (قاعدة الـ 6 شهور)
        public bool IsEligibleForBuyout(ClientProduct product)
        {
            if (product == null) return false;

            // حساب الفرق بين تاريخ النهاردة وتاريخ بداية القرض
            var monthsPassed = ((DateTime.Now.Year - product.StartDate.Year) * 12) + DateTime.Now.Month - product.StartDate.Month;

            return monthsPassed >= 6;
        }

        // حساب القسط الجديد بقواعد الـ Buyout (15%)
        public decimal CalculateNewInstallment(decimal amount, int months, decimal interestRate, ClientSegment segment)
        {
            // 1. تحديد الثوابت
            decimal monthlyServiceFee = 0;
            decimal buyoutAdminFeePercentage = 0.15m; // ✅ هنا التعديل: 15% أساسي للـ Buyout

            // 2. تطبيق قواعد الشرائح (Segments)
            switch (segment)
            {
                case ClientSegment.Prime:
                    monthlyServiceFee = 75;
                    // يدفع الـ 15% كاملة
                    break;

                case ClientSegment.Plus:
                    monthlyServiceFee = 120;
                    // يدفع الـ 15% كاملة
                    break;

                case ClientSegment.Wealth:
                    monthlyServiceFee = 200;
                    // يدفع الـ 15% كاملة
                    break;

                case ClientSegment.PrivateWealth:
                    monthlyServiceFee = 200;
                    // يدفع الـ 15% كاملة
                    break;
            }

            // 3. إضافة المصاريف الإدارية (الـ 15%) على أصل المبلغ
            // العميل خد 100 ألف، بس هيتسجل عليه 115 ألف (شاملة المصاريف)
            decimal totalPrincipal = amount + (amount * buyoutAdminFeePercentage);

            // 4. حساب الفائدة السنوية
            // (المعادلة: المبلغ * الفايدة * عدد السنين)
            decimal totalInterest = totalPrincipal * (interestRate / 100) * (months / 12.0m);

            // 5. المبلغ النهائي (أصل + مصاريف + فايدة)
            decimal grandTotal = totalPrincipal + totalInterest;

            // 6. القسط الشهري الأساسي
            decimal baseInstallment = grandTotal / months;

            // 7. القسط النهائي (شامل مصاريف الخدمة الشهرية)
            return baseInstallment + monthlyServiceFee;
        }
    }
}