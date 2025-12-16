using System.ComponentModel.DataAnnotations.Schema;
using EventManager.Domain.Enums;
using EventManager.Domain.Models;

namespace EvenetManager.Domain.Models;

[Table("Tickets")]
public class Ticket
{
    public Guid EventId { get; set; }
    public Event Event { get; set; } = null!;
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    public DateTime PurchaseDate { get; set; } = DateTime.UtcNow;
    public TicketStatus Status { get; set; }
    public string Code { get; set; } = Guid.NewGuid().ToString();
}