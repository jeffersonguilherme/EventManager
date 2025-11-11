using System.Reflection;
using Dapper;
using EventManager.Domain.Repositories.Interfaces;

namespace EventManager.Infrastructure.Repositories.Base;

public class BaseRepository<T> : IBaserepository<T> where T : class
{
    private readonly DapperContext _context;

    public BaseRepository(DapperContext context)
    {
        _context = context;
    }

    private string GetTableName()
    {
        var tableAttribute = typeof(T).GetCustomAttribute<System.ComponentModel.DataAnnotations.Schema.TableAttribute>();
        return tableAttribute?.Name ?? typeof(T).Name;
    }
    public async Task AddAsync(T entity)
    {
        using var connection = _context.CreateConnection();

        var tableName = GetTableName();
        var properties = typeof(T)
                        .GetProperties()
                        .Where(p => p.Name.ToLower() != "id")
                        .ToList();

        var columns = string.Join(", ", properties.Select(p => p.Name));
        var values = string.Join(", ", properties.Select(p => "@" + p.Name));

        var sql = $"INSERT INTO {tableName} ({columns}) VALUES ({values});";
        await connection.ExecuteAsync(sql, entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        using var connection = _context.CreateConnection();
        var tableName = GetTableName();

        var sql = $"DELETE FROM {tableName} WHERE Id = @id";
        await connection.ExecuteAsync(sql, new { Id = id });
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        using var connection = _context.CreateConnection();
        var tableName = GetTableName();

        var sql = $"SELECT * FROM {tableName}";
        return await connection.QueryAsync<T>(sql);
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        using var connection = _context.CreateConnection();
        var tableName = GetTableName();

        var sql = $"SELECT * FROM {tableName} WHERE Id = @Id";
        return await connection.QueryFirstOrDefaultAsync<T>(sql, new { Id = id });
    }

    public async Task UpdateAsync(T entity)
    {
        using var connection = _context.CreateConnection();
        var tableName = GetTableName();

        var properties = typeof(T).GetProperties()
                        .Where(p => p.Name.ToLower() != "id")
                        .ToList();

        var setClouse = string.Join(", ", properties.Select(p => $"{p.Name} = @{p.Name}"));
        var sql = $"UPDATE {tableName} SET {setClouse} WHERE Id = @Id";

        await connection.ExecuteAsync(sql, entity);
    }
}