namespace EventManager.Application.DTOs.Tickets;

public class TicketResponseDto
{
    public Guid EventId { get; set; }
    public string EventName { get; set; } = string.Empty;
    public DateTime PurchaseDate { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
}