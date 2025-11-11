using EventManager.Domain.Models;

namespace EventManager.Application.DTOs;

public class EventViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Location { get; set; } = string.Empty;
    public DateTime DateCreat { get; set; }
    public DateTime DateUpdate { get; set; }
    public List<User>? Users { get; set; }
}