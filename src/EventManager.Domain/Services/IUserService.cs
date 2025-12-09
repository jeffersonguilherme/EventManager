using EventManager.Domain.Models;
using EventManager.Domain.Response;

namespace EventManager.Domain.Services;

public interface IUserService
{
    Task AddAsync(User user);
    Task<IEnumerable<Event>> GetUserEventsAsync(Guid id);
    Task<PagedResponse<User>> GetAllPagedAsync(int pageNumber, int pageSize);
    Task<User> GetByIdAsync(Guid id);
    Task UpdateAsync(User user);
    Task DeleteAsync(Guid id);
}