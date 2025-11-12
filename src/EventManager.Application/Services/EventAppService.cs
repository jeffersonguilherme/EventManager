using EventManager.Application.DTOs;
using EventManager.Application.Interfaces;
using EventManager.Domain.Models;
using EventManager.Domain.Services;

namespace EventManager.Application.Services;

public class EventAppService : IEventAppService
{
    private readonly IEventService _eventService;

    public EventAppService(IEventService eventService)
    {
        _eventService = eventService;
    }

    public async Task AddEventoAsync(EventViewModel eventViewModel)
    {
        var evento = new Event
        {
            Name = eventViewModel.Name,
            Description = eventViewModel.Description,
            Location = eventViewModel.Location,
            StartDate = eventViewModel.StartDate,
            EndDate = eventViewModel.EndDate,
            DateCreate = DateTime.Now,
            DateUpdate = DateTime.Now

        };
        
        //validar campos
       await _eventService.AddAsync(evento);
    }
}