using EventManager.Domain.Models;
using EventManager.Domain.Repositories.Interfaces;
using EventManager.Infrastructure.Repositories.Base;

namespace EventManager.Infrastructure.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly DapperContext _context;
    public UserRepository(DapperContext context) : base(context)
    {
        _context = context;
    }
}