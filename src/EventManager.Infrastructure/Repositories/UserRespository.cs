using EventManager.Domain.Models;
using EventManager.Domain.Repositories.Interfaces;

namespace EventManager.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    public Task AddAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(User entity)
    {
        throw new NotImplementedException();
    }
}

