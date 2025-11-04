using EventManager.Domain.Models;

namespace EventManager.Domain.Services;

public interface IEventService
{
    Task Adicionar(Event evento);
    Task<IEnumerable<Event>> ObterTodos();
    Task<Event> ObterPorId(Guid id);
    Task Atualizar(Event evento);
    Task Excluir(Guid id);
}