using System.Data;
using Dapper;
using EventManager.Domain.Models;
using EventManager.Domain.Repositories.Interfaces;
using EventManager.Infrastructure.Repositories.Base;

namespace EventManager.Infrastructure.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(IDbConnection connection) : base(connection)
    {

    }

    public override async Task Adicionar(User entity)
    {
        entity.Id = Guid.NewGuid();
        
        var sql = @"insert into [User] (Id, FullName, Email) values (@Id, @FullName, @Email)";
        await _connection.ExecuteAsync(sql, entity);
    }
}