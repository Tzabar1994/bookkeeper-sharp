using Bookkeeper.Api.Models;

namespace Bookkeeper.Api.Services
{
    public interface IInvoiceStorageService
    {
        public void StoreInvoice(Invoice i);
        public List<Invoice> GetInvoices();
    }
    public class InvoiceStorageService : IInvoiceStorageService
    {
        private static List<Invoice> _storage;
        
        public InvoiceStorageService()
        {
            _storage = new();
            AddTestData();
        }

        public void StoreInvoice(Invoice i)
        {
            _storage.Add(i);
        }

        public List<Invoice> GetInvoices()
        {
            return _storage;
        }

        private void AddTestData()
        {
            _storage.AddRange(new List<Invoice>
            {
                new Invoice
                {
                    InvoiceNumber = 100,
                    CustomerName = "Intial Invoice Customer",
                    Amount = 5m,
                    Payments = new() { new Payment { Amount = 3m, PaymentNumber = 99 } }
                },
                new Invoice
                {
                    InvoiceNumber = 101,
                    CustomerName = "Intial Invoice Customer",
                    Amount = 10m,
                    Payments = new() { new Payment { Amount = 3m, PaymentNumber = 99 } }
                },
                new Invoice
                {
                    InvoiceNumber = 102,
                    CustomerName = "Intial Invoice Customer 2",
                    Amount = 5.5m,
                    Payments = new() { new Payment { Amount = 5m, PaymentNumber = 99 } }
                },
                new Invoice
                {
                    InvoiceNumber = 103,
                    CustomerName = "Intial Invoice Customer 2",
                    Amount = 5m,
                    Payments = new() { new Payment { Amount = 3m, PaymentNumber = 99 } }
                }
            });
        }
    }
}
