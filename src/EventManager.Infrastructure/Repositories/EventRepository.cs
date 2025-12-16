using Dapper;
using EventManager.Domain.Models;
using EventManager.Domain.Repositories.Interfaces;

namespace EventManager.Infrastructure.Repositories;

public class EventRepository : IEventRepository
{
    private readonly DapperContext _context;

    public EventRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task AddUserToEventAsync(Guid eventId, Guid userId)
    {
        var sql = @"
            INSERT INTO EventsUsers (EventId, UserId, RegistrationDate)
            VALUES (@EventId, @UserId, GETDATE());
        ";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, new { EventId = eventId, UserId = userId });
    }

    public async Task DeleteAsync(Guid id)
    {
         var sql = @"DELETE FROM Events WHERE Id = @Id";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, new { Id = id });
    }

    public async Task<(IEnumerable<Event> events, int totalItems)> GetAllAsync(int pageNumber, int pageSize)
    {
        var countSql = @"SELECT COUNT(Id) FROM Events"; // faz a contagem de quanto total dos dos eventos

        var sql = @"SELECT * FROM Events ORDER BY StartDate OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY";

        var parametersPaged = new
        {
            Skip = (pageNumber - 1) * pageSize, //Calcula quantos registros deve pular
            Take = pageSize
        };
        
        using var connection = _context.CreateConnection();

        using var multiConsultas = await connection.QueryMultipleAsync($"{countSql};{sql}", parametersPaged);
        
        var totalItems = await multiConsultas.ReadFirstAsync<int>();
        var events = await multiConsultas.ReadAsync<Event>();
        
        return (events, totalItems);
    }

    public async Task<Event?> GetByIdAsync(Guid id)
    {
        var sql = @"SELECT * FROM Events WHERE Id = @Id";

        using var connection = _context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Event>(sql, new {Id = id});
    }


    public async Task<Guid> InsertAsync(Event evento)
    {
        var sql = @"
            INSERT INTO Events (Id, Name, Description, StartDate, EndDate, Location, DateCreate, DateUpdate)
            VALUES (@Id, @Name, @Description, @StartDate, @EndDate, @Location, @DateCreate, @DateUpdate);
        ";

        evento.Id = Guid.NewGuid();
        evento.DateCreate = DateTime.Now;
        evento.DateUpdate = DateTime.Now;

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, evento);

        return evento.Id;
    }

    public async Task UpdateAsync(Event evento)
    {
        evento.DateUpdate = DateTime.Now;

        var sql = @"
            UPDATE Events SET
                Name = @Name,
                Description = @Description,
                StartDate = @StartDate,
                EndDate = @EndDate,
                Location = @Location,
                DateUpdate = @DateUpdate
            WHERE Id = @Id;";

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(sql, evento);
    }
}