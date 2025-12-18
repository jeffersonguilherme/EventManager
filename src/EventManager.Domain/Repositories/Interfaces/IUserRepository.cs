using EventManager.Domain.Models;

namespace EventManager.Domain.Repositories.Interfaces;

public interface IUserRepository 
{
    Task<Guid> AddAsync(User user);
    Task<User?> GetByIdAsync(Guid id);
    Task<(IEnumerable<User> users, int totalItems)> GetAllAsync(int pageNumber, int pageSize);

    Task UpdateAsync(User userModel);
    Task DeleteAsync(Guid id);
    Task<User?> GetByEmailAndPassawordAsync(string email, string password);
    Task SaveTokenAsync(Guid userId, string token);
}