using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace portfolio.backend.Scripts.Data.Next_Tuto.Models;

[Table("customers")]
public class Customers
{
    [Column("id")]
    public Guid Id { get; init; }
    [Column("name"), Required]
    public string Name { get; set; } = string.Empty;
    [Column("email"), Required]
    public string Email { get; set; } = string.Empty;
    [Column("image_url"), Required]
    public string ImageUrl { get; set; } = string.Empty;

    [Column("invoices"), Required] 
    public List<Invoices> Invoices { get; set; } = null!;
}