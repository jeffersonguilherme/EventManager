using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Domain.Models;

[Table("Users")]
public class User
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public List<Event>? Events { get; set; }
}
