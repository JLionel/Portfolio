using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace portfolio.backend.Scripts.Data.Next_Tuto.Models;

[Table("revenue")]
public class Revenue
{
    [Column("id"), Key]
    public Guid Id { get; init; }
    [Column("month"), Required]
    public string Month { get; set; } = string.Empty;
    [Column("amount"), Required]
    public int Amount { get; set; }
}