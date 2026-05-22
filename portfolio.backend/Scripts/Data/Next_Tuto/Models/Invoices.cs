using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace portfolio.backend.Scripts.Data.Next_Tuto.Models;

[Table("invoices")]
public class Invoices
{
    [Column("id")]
    public Guid Id { get; init; }

    [Column("status"), Required]
    public string Status { get; set; } = string.Empty;

    [Column("date", TypeName = "date"), Required]
    public DateTime Date { get; init; }

    [Column("amount"), Required] 
    public int Amount { get; set; }

    
    [Column("customer_id")]
    public Guid CustomerId { get; set; }

    [Column("customer"), ForeignKey(nameof(CustomerId))]
    public Customers Customer { get; init; } = null!;
} 