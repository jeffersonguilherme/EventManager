namespace EvenetManager.Domain.Models;

public class EventUser
{
    public Guid EventId { get; set; }
    public Guid UserId { get; set; }
    public DateTime RegistrationDate { get; set; } = DateTime.Now;
}