using AutoMapper;
using EventManager.Application.DTOs;
using EventManager.Application.Interfaces;
using EventManager.Domain.Models;
using EventManager.Domain.Services;

namespace EventManager.Application.Services;

public class EventAppService : IEventAppService
{
    private readonly IEventService _eventService;
    private readonly IMapper _mapper;

    public EventAppService(IEventService eventService, IMapper mapper)
    {
        _eventService = eventService;
        _mapper = mapper;
    }

    public async Task AddEventoAsync(EventCreateDto eventCreateDto)
    {
        var evento = _mapper.Map<Event>(eventCreateDto);
        await _eventService.AddAsync(evento);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _eventService.DeleteAsync(id);
    }

    public async Task<IEnumerable<EventGetDto>> GetAllAsync()
    {
        var eventos = await _eventService.GetAllAsync();
        return _mapper.Map<IEnumerable<EventGetDto>>(eventos);
    }

    public async Task<EventGetDto> GetByIdAsync(Guid id)
    {
         var evento = await _eventService.GetByIdAsync(id);
         return _mapper.Map<EventGetDto>(evento);
    }

    public async Task<EventGetDto> GetByIdWithUsersAsync(Guid id)
    {
         var evento = await _eventService.GetByIdWithUsersAsync(id);
        return _mapper.Map<EventGetDto>(evento);
    }

    public async Task UpdateAsync(Guid id, EventUpdateDto eventUpdateDto)
    {
        var evento = _mapper.Map<Event>(eventUpdateDto);
        evento.Id = id;

        await _eventService.UpdateAsync(evento);
    }
}