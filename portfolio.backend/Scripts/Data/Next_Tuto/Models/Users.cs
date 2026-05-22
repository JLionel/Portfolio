using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace portfolio.backend.Scripts.Data.Next_Tuto.Models;

[Table("users")]
public class Users
{
    [Column("id")]
    public Guid Id { get; init; }
    [Column("name"), Required]
    public string Name { get; set; } = string.Empty;
    [Column("email"), Required]
    public string Email { get; set; } = string.Empty;
    [Column("password"), Required]
    public string Password { get; set; } = string.Empty;
}