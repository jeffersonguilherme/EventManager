using System.Data;
using EventManager.Domain.Models;
using EventManager.Domain.Repositories.Interfaces;
using EventManager.Infrastructure.Repositories.Base;

namespace EventManager.Infrastructure.Repositories;

public class EventRepository : BaseRepository<Event>, IEventRepository
{
    public EventRepository(IDbConnection connection) : base(connection) { }
    
}