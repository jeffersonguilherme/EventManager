using EventManager.Domain.Models;

namespace EventManager.Domain.Services;

public interface IUserService
{
    Task AddAsync(User user);
    Task<IEnumerable<User>> GetAllAsync();
    Task<User> GetByIdAsync(Guid id);
    Task UpdateAsync(User user);
    Task DeleteAsync(Guid id);
}