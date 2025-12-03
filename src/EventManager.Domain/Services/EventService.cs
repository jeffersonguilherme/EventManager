using EventManager.Domain.Models;
using EventManager.Domain.Repositories.Interfaces;

namespace EventManager.Domain.Services;

public class EventService : IEventService
{
    private readonly IEventRepository _repository;

    public EventService(IEventRepository repository)
    {
        _repository = repository;
    }

    public async Task AddAsync(Event evento)
    {
        await _repository.InsertAsync(evento);
    }

    public async Task DeleteAsync(Guid id)
    {
        var evento = await _repository.GetByIdAsync(id);
        if (evento == null)
            throw new ArgumentException("Evento não encontrado");

        await _repository.DeleteAsync(id);
    }

    public async Task<(IEnumerable<Event> events, int totalItems)> GetAllAsync(int pageNumber, int pageSize)
    {
        var (listaEventos, totalItems) = await _repository.GetAllAsync(pageNumber, pageSize);
        return (listaEventos, totalItems);
    }

    public async Task<Event> GetByIdAsync(Guid id)
    {
        var evento = await _repository.GetByIdAsync(id);
        if (evento == null)
            throw new ArgumentException("Evento não encontrado");

        return evento;
    }

    public async Task<Event> GetByIdWithUsersAsync(Guid id)
    {
        var evento = await _repository.GetByIdWithUsersAsync(id);
        if (evento == null)
        throw new ArgumentException("Evento não encontrado");

        return evento;
    }

    public async Task UpdateAsync(Event paramEvento)
    {
        var evento = await _repository.GetByIdAsync(paramEvento.Id);

        if (evento == null)
        {
            throw new ArgumentException("Evento não encontrado");
        }

        evento.Name = paramEvento.Name;
        evento.Description = paramEvento.Description;
        evento.StartDate = paramEvento.StartDate;
        evento.EndDate = paramEvento.EndDate;
        evento.DateUpdate = DateTime.Now;

        await _repository.UpdateAsync(evento);
    }
}