using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using portfolio.backend.Scripts.Data.Next_Tuto;
using portfolio.backend.Scripts.Data.Next_Tuto.Definitions;
using portfolio.backend.Scripts.Data.Next_Tuto.Models;

namespace portfolio.backend.Controllers.Data.Next_Tuto;

[ApiController]
[Route("api/data/next_tuto/Customers")]
public class AppDbNextTutoCustomersController(ILogger<AppDbNextTutoCustomersController> logger, AppDbNextTutoContext context) : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetCustomers()
    {
        var customers = await context.Customers
            .Select(c => new
            {
                c.Id, 
                c.Name
            })
            .OrderBy(c => c.Name)
            .ToListAsync();
        
        
        return Ok(customers);
    }


    [HttpGet("Filtered")]
    public async Task<IActionResult> GetCustomerFiltered(string query = "")
    {
        var customersFiltered = await context.Customers
            .Include(c => c.Invoices)
            .Where(c =>
                EF.Functions.ILike(c.Name, $"%{query}%")
                || EF.Functions.ILike(c.Email, $"%{query}%"))
            .Select(c => new
            {
                c.Id,
                c.Name,
                c.Email,
                c.ImageUrl,
                TotalInvoices = c.Invoices.Count,
                TotalPending = c.Invoices
                    .Where(i => i.Status == "pending")
                    .Sum(i => i.Amount),
                TotalPaid = c.Invoices
                    .Where(i => i.Status == "paid")
                    .Sum(i => i.Amount),

            })
            .OrderBy(c => c.Name)
            .AsSplitQuery()
            .ToListAsync();

        return Ok(customersFiltered);

    }
}