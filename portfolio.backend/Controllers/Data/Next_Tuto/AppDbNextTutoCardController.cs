using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using portfolio.backend.Scripts.Data.Next_Tuto;

namespace portfolio.backend.Controllers.Data.Next_Tuto;

[ApiController]
[Route("api/data/next_tuto/Card")]
public class AppDbNextTutoCardController(ILogger<AppDbNextTutoCustomersController> logger, AppDbNextTutoContext context) : Controller
{

    [HttpGet]
    public async Task<IActionResult> GetCard()
    {
        var card = new
        {
            CountInvoices = await context.Invoices.CountAsync(),
            CountCustomers = await context.Customers.CountAsync(),
            Paid = await context.Invoices
                .Where(i => i.Status == "paid")
                .SumAsync(i => i.Amount),
            Pending = await context.Invoices
                .Where(i => i.Status == "pending")
                .SumAsync(i => i.Amount)
        };
        
        return Ok(card);
    }
}