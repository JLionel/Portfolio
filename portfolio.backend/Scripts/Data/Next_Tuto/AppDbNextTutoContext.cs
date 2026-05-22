using Microsoft.EntityFrameworkCore;
using portfolio.backend.Scripts.Data.Next_Tuto.Models;
using BC = BCrypt.Net.BCrypt;

namespace portfolio.backend.Scripts.Data.Next_Tuto;


public class AppDbNextTutoContext(DbContextOptions<AppDbNextTutoContext> options) : DbContext(options)
{
    public DbSet<Users> Users { get; set; }
    public DbSet<Revenue> Revenue { get; set; }
    public DbSet<Invoices> Invoices { get; set; }
    public DbSet<Customers> Customers { get; set; }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Revenue>()
            .HasIndex(r => r.Month)
            .IsUnique();
        
        
        
        // Seed Users
        modelBuilder.Entity<Users>().HasData(
            new Users
            {
                Id = Guid.Parse("b3436992-ad18-4873-aa2c-29ed8892a5aa"),
                Name = "User",
                Email = "user@nextmail.com",
                Password = "$2a$11$psaSIr9t4MHIGMSgdGswZONTn72xOQVt/TGnJMZPvrnx/BeEEX5t2"
            }
        );
        
        
        var evilRabbitId = Guid.Parse("d6e15727-9fe1-4961-8c5b-ea44a9bd81aa");
        var delbaOliveiraId = Guid.Parse("3958dc9e-712f-4377-85e9-fec4b6a6442a");
        var leeRobinsonId = Guid.Parse("3958dc9e-742f-4377-85e9-fec4b6a6442a");
        var michaelNovotnyId = Guid.Parse("76d65c26-f784-44a2-ac19-586678f7c2f2");
        var amyBurnsId = Guid.Parse("CC27C14A-0ACF-4F4A-A6C9-D45682C144B9");
        var balazsOrbanId = Guid.Parse("13D07535-C59E-4157-A011-F8D2EF4E0CBB");

        // Seed Customers
        modelBuilder.Entity<Customers>().HasData(
            new Customers { Id = evilRabbitId, Name = "Evil Rabbit", Email = "evil@rabbit.com", ImageUrl = "/customers/evil-rabbit.png" },
            new Customers { Id = delbaOliveiraId, Name = "Delba de Oliveira", Email = "delba@oliveira.com", ImageUrl = "/customers/delba-de-oliveira.png" },
            new Customers { Id = leeRobinsonId, Name = "Lee Robinson", Email = "lee@robinson.com", ImageUrl = "/customers/lee-robinson.png" },
            new Customers { Id = michaelNovotnyId, Name = "Michael Novotny", Email = "michael@novotny.com", ImageUrl = "/customers/michael-novotny.png" },
            new Customers { Id = amyBurnsId, Name = "Amy Burns", Email = "amy@burns.com", ImageUrl = "/customers/amy-burns.png" },
            new Customers { Id = balazsOrbanId, Name = "Balazs Orban", Email = "balazs@orban.com", ImageUrl = "/customers/balazs-orban.png" }
        );

        // Seed Invoices (Generated IDs as they were missing in JSON)
        modelBuilder.Entity<Invoices>().HasData(
            new Invoices { Id = Guid.Parse("2c2a4e4e-8b3b-4320-b5b5-3954545aad7d"), CustomerId = evilRabbitId, Amount = 15795, Status = "pending", Date = DateTime.Parse("2022-12-06") },
            new Invoices { Id = Guid.Parse("2d4b3bfa-4e60-4163-acbc-79edd4d9e69e"), CustomerId = delbaOliveiraId, Amount = 20348, Status = "pending", Date = DateTime.Parse("2022-11-14") },
            new Invoices { Id = Guid.Parse("39f5ae23-f425-4042-9bb9-860cc3f7231f"), CustomerId = amyBurnsId, Amount = 3040, Status = "paid", Date = DateTime.Parse("2022-10-29") },
            new Invoices { Id = Guid.Parse("3b5f714b-0221-4222-92bc-b3245eabfe22"), CustomerId = michaelNovotnyId, Amount = 44800, Status = "paid", Date = DateTime.Parse("2023-09-10") },
            new Invoices { Id = Guid.Parse("3dd0584b-4405-4f23-a715-470381f2e073"), CustomerId = balazsOrbanId, Amount = 34577, Status = "pending", Date = DateTime.Parse("2023-08-05") },
            new Invoices { Id = Guid.Parse("659eb7d0-6656-4221-8863-b706bc8cd9e1"), CustomerId = leeRobinsonId, Amount = 54246, Status = "pending", Date = DateTime.Parse("2023-07-16") },
            new Invoices { Id = Guid.Parse("6ce7d909-58fa-40db-8a66-313de4e1c995"), CustomerId = evilRabbitId, Amount = 666, Status = "pending", Date = DateTime.Parse("2023-06-27") },
            new Invoices { Id = Guid.Parse("7d311dbc-3547-4b13-884c-9c47620e6878"), CustomerId = michaelNovotnyId, Amount = 32545, Status = "paid", Date = DateTime.Parse("2023-06-09") },
            new Invoices { Id = Guid.Parse("887c63ea-a013-437e-993d-0321e7839db1"), CustomerId = amyBurnsId, Amount = 1250, Status = "paid", Date = DateTime.Parse("2023-06-17") },
            new Invoices { Id = Guid.Parse("94ac86bb-033a-400c-a570-9d9383ae92df"), CustomerId = balazsOrbanId, Amount = 8546, Status = "paid", Date = DateTime.Parse("2023-06-07") },
            new Invoices { Id = Guid.Parse("a89bae68-7ac8-4b4e-af7b-ed4d3e65b78d"), CustomerId = delbaOliveiraId, Amount = 500, Status = "paid", Date = DateTime.Parse("2023-08-19") },
            new Invoices { Id = Guid.Parse("b3c388a0-141f-49fa-bcab-a3d05d97a167"), CustomerId = balazsOrbanId, Amount = 8945, Status = "paid", Date = DateTime.Parse("2023-06-03") },
            new Invoices { Id = Guid.Parse("f51ff7fd-f1af-4fbc-84ff-fd197ddf322d"), CustomerId = leeRobinsonId, Amount = 1000, Status = "paid", Date = DateTime.Parse("2022-06-05") }
        );

        // Seed Revenue (Generated IDs as they were missing in JSON)
        modelBuilder.Entity<Revenue>().HasData(
            new Revenue { Id = Guid.Parse("07e5316f-ffa6-4909-aa4a-ca1f08abbda0"), Month = "Jan", Amount = 2000 },
            new Revenue { Id = Guid.Parse("20a93528-428f-4d34-8475-3648861ead65"), Month = "Feb", Amount = 1800 },
            new Revenue { Id = Guid.Parse("243a9c6b-4384-47c3-a7d3-ad2c2a89b19a"), Month = "Mar", Amount = 2200 },
            new Revenue { Id = Guid.Parse("3278655e-2fd2-4b47-8e42-7fab47030641"), Month = "Apr", Amount = 2500 },
            new Revenue { Id = Guid.Parse("4a7f7eb3-ca78-4cdf-ac9f-15cd89db2837"), Month = "May", Amount = 2300 },
            new Revenue { Id = Guid.Parse("57344439-19ac-4268-8a69-0f9299dddb5c"), Month = "Jun", Amount = 3200 },
            new Revenue { Id = Guid.Parse("63aa12b2-9ed9-4b84-82c1-a77e570bbbeb"), Month = "Jul", Amount = 3500 },
            new Revenue { Id = Guid.Parse("6467ea0e-e110-4c9c-8f7b-ce30f7e9c058"), Month = "Aug", Amount = 3700 },
            new Revenue { Id = Guid.Parse("7721265f-1be2-4a21-9bd3-ae592a06849a"), Month = "Sep", Amount = 2500 },
            new Revenue { Id = Guid.Parse("a79ee355-d4bf-4644-9006-ebacb059606a"), Month = "Oct", Amount = 2800 },
            new Revenue { Id = Guid.Parse("b51fb53c-cd45-42e9-b7f7-17641b3c78c2"), Month = "Nov", Amount = 3000 },
            new Revenue { Id = Guid.Parse("e756d367-0747-4701-99d1-b7c54fd4cca7"), Month = "Dec", Amount = 4800 }
        );
    }
}