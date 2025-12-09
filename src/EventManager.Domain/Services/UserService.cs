using EventManager.Domain.Models;
using EventManager.Domain.Repositories.Interfaces;

namespace EventManager.Domain.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task AddAsync(User user)
    {
        await _repository.AddAsync(user);
    }

    public async Task DeleteAsync(Guid id)
    {
        var user = await _repository.GetByIdAsync(id);
        if(user ==null)
            throw new ArgumentException("Usuario não encontrado");

        await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        var listaUsers = await _repository.GetAllAsync();
        return listaUsers;
    }

    public async Task<User> GetByIdAsync(Guid id)
    {
        var user = await _repository.GetByIdAsync(id);
        if(user == null)
            throw new ArgumentException("Usuário não encontrado");

        return user;
    }

    public Task<IEnumerable<Event>> GetUserEventsAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(User userModel)
    {
        var user = await _repository.GetByIdAsync(userModel.Id);

        if(user == null)
            throw new ArgumentException("Usuario não encontrado");
        
        user.FullName = userModel.FullName;
        user.Email = userModel.Email;

        await _repository.UpdateAsync(user);
    }
}