namespace Bookkeeper.Api.Models
{
    public class Invoice
    {
        public int InvoiceNumber { get; init; }
        public string CustomerName { get; init; }
        public decimal Amount { get; init; }
        public List<Payment>? Payments { get; init; }

        public decimal AmountDue()
        {
            return Amount - Payments?.Sum(x=> x.Amount) ?? Amount;
        }

    }

    public class Payment
    {
        public int PaymentNumber { get; init; }
        public decimal Amount { get; init; }
    }
}
