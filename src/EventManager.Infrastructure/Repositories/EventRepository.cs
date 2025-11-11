using EventManager.Domain.Models;
using EventManager.Domain.Repositories.Interfaces;
using EventManager.Infrastructure.Repositories.Base;

namespace EventManager.Infrastructure.Repositories;

public class EventRepository : BaseRepository<Event>, IEventRepository
{
    private readonly DapperContext _context;
    public EventRepository(DapperContext context) : base(context)
    {
        _context = context;
    }
    
}