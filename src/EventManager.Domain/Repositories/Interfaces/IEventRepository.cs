using EventManager.Domain.Models;

namespace EventManager.Domain.Repositories.Interfaces;

public interface IEventRepository
{
    Task<Event?> GetByIdAsync(Guid id);
    Task<Event?> GetByIdWithUsersAsync(Guid id);
    Task<IEnumerable<Event>> GetAllAsync();
    Task<Guid> InsertAsync(Event evt);
    Task UpdateAsync(Event evt);
    Task DeleteAsync(Guid id);
    Task AddUserToEventAsync(Guid eventId, Guid userId);

}