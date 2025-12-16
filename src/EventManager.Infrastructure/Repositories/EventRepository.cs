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

    public Task<Guid> InsertAsync(Event evt)
    {
        throw new NotImplementedException();
    }
    public Task<(IEnumerable<Event> events, int totalItems)> GetAllAsync(int pageNumber, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<Event?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }


    public Task UpdateAsync(Event evt)
    {
        throw new NotImplementedException();
    }
    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}