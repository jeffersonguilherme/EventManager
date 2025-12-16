namespace EventManager.Application.DTOs;

public class EventUpdateDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Location { get; set; } = string.Empty;
    public int MaxParticipants { get; set; }
    public bool IsActive { get; set; }
}