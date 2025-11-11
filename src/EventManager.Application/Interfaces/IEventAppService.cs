using EventManager.Application.DTOs;

namespace EventManager.Application.Interfaces;

public interface IEventAppService
{
    Task AddEventoAsync(EventViewModel eventViewModel);
}