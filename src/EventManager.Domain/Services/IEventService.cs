using EventManager.Domain.Models;

namespace EventManager.Domain.Services;

public interface IEventService
{
    Task AddAsync(Event evento);
    Task<IEnumerable<Event>> GetAllAsync();
    Task<Event> GetByIdAsync(Guid id);
    Task UpdateAsync(Event evento);
    Task DeleteAsync(Guid id);
    Task<Event> GetByIdWithUsersAsync(Guid id); 
}