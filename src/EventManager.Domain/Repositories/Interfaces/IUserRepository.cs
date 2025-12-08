using EventManager.Domain.Models;

namespace EventManager.Domain.Repositories.Interfaces;

public interface IUserRepository 
{
    Task<Guid> AddAsync(User user);
    Task<User?> GetByIdAsync(Guid id);
    Task<IEnumerable<User>> GetAllAsync();
    Task UpdateAsync(User user);
    Task DeleteAsync(Guid id);
}