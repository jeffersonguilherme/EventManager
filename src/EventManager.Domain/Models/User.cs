using System.ComponentModel.DataAnnotations.Schema;
using EvenetManager.Domain.Models;

namespace EventManager.Domain.Models;

[Table("Users")]
public class User
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;
    public bool EmailConfirmed { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; }
    public ICollection<Ticket>? Tickets { get; set; } = new List<Ticket>();
}
