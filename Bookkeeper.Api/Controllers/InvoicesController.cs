using Bookkeeper.Api.Models;
using Bookkeeper.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bookkeeper.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class InvoicesController : ControllerBase
{
    private IInvoiceStorageService _storage;

    public InvoicesController(IInvoiceStorageService storage)
    {
        _storage = storage;
    }


    [HttpPost]
    public ActionResult CreateInvoice(Invoice toSave)
    {
        _storage.StoreInvoice(toSave);
        return Ok();
    }

    [HttpGet]
    public List<Invoice> GetInvoices()
    {
        return _storage.GetInvoices();
    }

    [HttpGet("/customer-report")]
    public Dictionary<string, decimal> GetCustomerReport()
    {
        var invoices = _storage.GetInvoices();
        return invoices.GroupBy(i => i.CustomerName)
            .ToDictionary(g => g.Key, g => g.Sum(v => v.AmountDue()));              
    }

}
