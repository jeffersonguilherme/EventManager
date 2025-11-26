using System.Text.Json.Serialization;

namespace EventManager.Application.DTOs;

public class EventCreateDto
{

    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Location { get; set; } = string.Empty;

    [JsonIgnore]
    public DateTime DateCreat { get; set; } = DateTime.Now;
    [JsonIgnore]
    public DateTime DateUpdate { get; set; } = DateTime.Now;

}