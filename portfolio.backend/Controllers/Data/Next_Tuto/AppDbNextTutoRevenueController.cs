using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using portfolio.backend.Scripts.Data.Next_Tuto;
using portfolio.backend.Scripts.Data.Next_Tuto.Models;

namespace portfolio.backend.Controllers.Data.Next_Tuto;

[ApiController]
[Route("api/data/next_tuto/Revenue")]
public class AppDbNextTutoRevenueController(
    ILogger<AppDbNextTutoRevenueController> logger,
    AppDbNextTutoContext context) : Controller
{
    
    
    [HttpGet]
    public async Task<List<Revenue>?> GetRevenues()
    {
        return await context.Revenue.ToListAsync();
    }
    
}