using EventManager.Application.DTOs;

namespace EventManager.Application.Interfaces;

public interface IEventAppService
{
   Task AddEventoAsync(EventCreateDto eventCreateDto);
    Task<IEnumerable<EventGetDto>> GetAllAsync();
    Task<EventGetDto> GetByIdAsync(Guid id);
    Task UpdateAsync(Guid id, EventUpdateDto eventUpdateDto);
    Task DeleteAsync(Guid id);
    Task<EventGetDto> GetByIdWithUsersAsync(Guid id);
}