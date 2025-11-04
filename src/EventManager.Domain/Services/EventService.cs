using EventManager.Domain.Models;

namespace EventManager.Domain.Services;

public class EvventService : IEventService
{
    public Task Adicionar(Event evento)
    {
        throw new NotImplementedException();
    }

    public Task Atualizar(Event evento)
    {
        throw new NotImplementedException();
    }

    public Task Excluir(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Event> ObterPorId(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Event>> ObterTodos()
    {
        throw new NotImplementedException();
    }
}