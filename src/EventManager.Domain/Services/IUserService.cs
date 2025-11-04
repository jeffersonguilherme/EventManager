using EventManager.Domain.Models;

namespace EventManager.Domain.Services;

public interface IUserService
{
    Task Adicionar(User user);
    Task<IEnumerable<User>> ObterTodos();
    Task<User> ObterPorId(Guid id);
    Task Atualizar(User user);
    Task Excluir(Guid id);
}