using Dapper;
using EventManager.Domain.Models;
using EventManager.Domain.Repositories.Interfaces;

namespace EventManager.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DapperContext _context;

    public UserRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<Guid> AddAsync(User user)
    {
        var sql = @"INSERT INTO [Users](Id, FullName, Email)
        VALUES (@Id, @FullName, @Email)";

        user.Id = Guid.NewGuid();

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, user);

        return user.Id;
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

    public Task UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }
}

