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

    public async Task DeleteAsync(Guid id)
    {
        var sql = @"DELETE FROM Users WHERE Id = @Id";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, new{Id = id});
    }

    public async Task<(IEnumerable<User> users, int totalItems)> GetAllAsync(int pageNumber, int pageSize)
    {
        var countSql = @"SELECT COUNT(Id) FROM Users";
        var sql = @"SELECT * FROM Users ORDER BY FullName OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY";

        var parametersPaged = new
        {
            Skip = (pageNumber - 1) * pageSize,
            Take = pageSize
        };

        using var connection = _context.CreateConnection();

        using var multiConsultas = await connection.QueryMultipleAsync($"{countSql};{sql}", parametersPaged);

        var totalItems = await multiConsultas.ReadFirstAsync<int>();
        var users = await multiConsultas.ReadAsync<User>();
        return (users, totalItems);
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        var sql = @"SELECT * FROM [Users] WHERE Id = @Id";

        using var connection = _context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<User>(sql, new {Id = id});
    }

    public async Task UpdateAsync(User user)
    {
        var sql = @"UPDATE Users SET
                    FullName = @FullName,
                    Email = @Email
                WHERE Id = @Id;";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, user);
    }
}

