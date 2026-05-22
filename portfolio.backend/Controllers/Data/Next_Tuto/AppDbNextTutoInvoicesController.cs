using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using portfolio.backend.Scripts.Data.Next_Tuto;
using portfolio.backend.Scripts.Data.Next_Tuto.Definitions;
using portfolio.backend.Scripts.Data.Next_Tuto.Models;

namespace portfolio.backend.Controllers.Data.Next_Tuto;

[ApiController]
[Route("api/data/next_tuto/Invoices")]
public class AppDbNextTutoInvoicesController(
    ILogger<AppDbNextTutoInvoicesController> logger,
    AppDbNextTutoContext context) : Controller
{

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetInvoiceById(Guid id)
    {
        var invoiceById = await context.Invoices
            .Select(i => new
            {
                i.Id,
                i.CustomerId,
                i.Amount,
                i.Status
            })
            .SingleAsync(i => i.Id == id);
    
        return Ok(invoiceById);
    }

    [HttpGet("Latest")]
    public async Task<IActionResult> GetInvoicesLatest()
    {
        try
        {
            var lastestInvoices = await context.Invoices
                .Include(i => i.Customer)
                .OrderByDescending(i => i.Date )
                .Select(i => new
                {
                    i.Amount,
                    i.Customer.Name,
                    i.Customer.ImageUrl,
                    i.Customer.Email,
                    i.Id,
                })
                .Take(5)
                .ToListAsync();
            
            return Ok(lastestInvoices);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
            
    }

    [HttpGet("Filtered")]
    public async Task<IActionResult> GetInvoiceFiltered(string query = "", int limit = 0, int offset = 0)
    {
        
        var invoices = await context.Invoices
            .Include(i => i.Customer)
            .Where(i => 
                EF.Functions.ILike(i.Customer.Name,$"%{query}%")
                || EF.Functions.ILike(i.Customer.Email, $"%{query}%")
                || EF.Functions.ILike(i.Amount.ToString(), $"%{query}%")
                || EF.Functions.ILike(i.Date.ToString(), $"%{query}%")
                || EF.Functions.ILike(i.Status, $"%{query}%"))
            .Select(i => new
            {
                i.Id,
                i.Amount,
                i.Date,
                i.Status,
                i.Customer.Name,
                i.Customer.Email,
                i.Customer.ImageUrl
            })
            .Skip(offset)
            .Take(limit)
            .OrderBy(i => i.Date)
            .ToListAsync();

        return Ok(invoices);
    }
    
    [HttpGet("Pages")]
    public async Task<IActionResult> GetInvoicePages(string query = "")
    {
        var invoicePages = await context.Invoices
            .Include(i => i.Customer)
            .Where(i =>
                EF.Functions.ILike(i.Customer.Name, $"%{query}%")
                || EF.Functions.ILike(i.Customer.Email, $"%{query}%")
                || EF.Functions.ILike(i.Amount.ToString(), $"%{query}%")
                || EF.Functions.ILike(i.Date.ToString()     , $"%{query}%")
                || EF.Functions.ILike(i.Status, $"%{query}%"))
            .CountAsync();
        
        return Ok(invoicePages);
    }
    
    
    [HttpPost]
    public async Task<IActionResult> CreateInvoice(InvoiceForm invoiceForm)
    {
        var newInvoice = new Invoices
        {
            CustomerId = invoiceForm.CustomerId,
            Date = DateTime.Today,
            Amount = invoiceForm.Amount,
            Status = invoiceForm.Status
        };
        
        try
        {
            await context.Invoices.AddAsync(newInvoice);
            await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error creating invoice : {E}", e.Message);
            return Problem("Error creating invoice");
        }
        
        return CreatedAtAction(nameof(CreateInvoice), new { id = newInvoice.Id });
    }

    [HttpPatch]
    public async Task<ActionResult> PatchInvoice(Guid id, InvoiceForm invoiceForm)
    {
        try
        {
            var invoice = new Invoices
            {
                Id = id,
                Amount = invoiceForm.Amount,
                Status = invoiceForm.Status,
                CustomerId = invoiceForm.CustomerId
            };
            
            context.Attach(invoice);
            context.Entry(invoice).Property(i => i.Amount).IsModified = true;
            context.Entry(invoice).Property(i => i.Status).IsModified = true;
            context.Entry(invoice).Property(i => i.CustomerId).IsModified = true;
            
            await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error patching invoice : {E}", e.Message);
            throw;
        }

        return NoContent();
    }


    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteInvoice(Guid id)
    {
        var invoice = new Invoices
        {
            Id = id
        };

        context.Attach(invoice);
        context.Remove(invoice);
        
        await context.SaveChangesAsync();
        
        return NoContent();
    }
}