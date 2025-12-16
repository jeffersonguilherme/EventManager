using System.ComponentModel.DataAnnotations.Schema;
using EvenetManager.Domain.Models;

namespace EventManager.Domain.Models;
[Table("Events")]
public class Event
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Location { get; set; } = string.Empty;
    public DateTime DateCreate { get; set; }
    public DateTime DateUpdate { get; set; }
    public int MaxParticipants { get; set; }
    public bool IsActive { get; set; } = true;

    public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

}