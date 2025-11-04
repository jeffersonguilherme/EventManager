using System.Data;
using Dapper;
using EventManager.Domain.Repositories.Interfaces;
using EventManager.Infrastructure.Data;

namespace EventManager.Infrastructure.Repositories.Base;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly IDbConnection _connection;
    protected readonly string _tableName;

    public BaseRepository(IDbConnection connection)
    {
        _connection = connection;
        _tableName = typeof(T).Name;
    }
    public Task Adicionar(T entity)
    {
        throw new NotImplementedException("Implementar na classe derivada.");
    }

    public Task Atualizar(T entity)
    {
        throw new NotImplementedException("Implementar na classe derivada.");
    }

    public async Task Excluir(Guid id)
    {
        var sql = $"delete from [{_tableName}] where Id = @Id";
        await _connection.ExecuteAsync(sql, new { Id = id });
    }

    public async Task<T> ObterPorId(Guid id)
    {
        var sql = $"select * from [{_tableName}] where Id = @Id";
        return await _connection.QueryFirstOrDefaultAsync<T>(sql, new { Id = id });
    }

    public async Task<IEnumerable<T>> ObterTodos()
    {
        var sql = $"select * from [{_tableName}]";
        return await _connection.QueryAsync<T>(sql);
    }
}