using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using portfolio.backend.Scripts.Data.Next_Tuto;
using portfolio.backend.Scripts.Data.Next_Tuto.Models;
using BC = BCrypt.Net.BCrypt;

namespace portfolio.backend.Controllers.Data.Next_Tuto;

[ApiController]
[Route("api/data/next_tuto/Users")]
public class AppDbNextTutoUsersController(ILogger<AppDbNextTutoUsersController> logger, AppDbNextTutoContext context) : Controller
{
    [HttpGet("auth")]
    public async Task<IActionResult> GetUserForAuth(string email, string password)
    {
        
        var userData = await context.Users
            .Where(u => u.Email == email)
            .SingleAsync();
        
        if (!BC.Verify(password, userData.Password))
            return Unauthorized();
            
        return Ok(new
        {
            userData.Id,
            userData.Email,
            userData.Name
        });
    }
}