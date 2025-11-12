using System.Text.Json.Serialization;
using EventManager.Domain.Models;

namespace EventManager.Application.DTOs;

public class EventViewModel
{

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Location { get; set; } = string.Empty;

    [JsonIgnore]
    public DateTime DateCreat { get; set; }
    [JsonIgnore]
    public DateTime DateUpdate { get; set; }

}