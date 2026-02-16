namespace HassanBank.Domain.Products
{
    public class Loan : ClientProduct
    {
        public decimal PrincipalAmount { get; set; } // أصل القرض
        public int TenorInMonths { get; set; }       // مدة القرض
        public decimal MonthlyInstallment { get; set; } // القسط الشهري
        public string LoanType { get; set; } = "Buyout";
    }
}
