namespace HassanBank.Domain.Products
{
    public class CreditCard : ClientProduct
    {
        public decimal CreditLimit { get; set; }     // الحد الائتماني
        public string CardType { get; set; } = string.Empty;      // Gold, Platinum, etc.
        public DateTime ExpiryDate { get; set; }
    }
}
