using AutoMapper;
using EventManager.Application.DTOs;
using EventManager.Application.Interfaces;
using EventManager.Domain.Models;
using EventManager.Domain.Response;
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

    public async Task<ResponseModel<Event>> AddEventoAsync(EventCreateDto eventCreateDto)
    {
        try
        {
            var evento = _mapper.Map<Event>(eventCreateDto);
            await _eventService.AddAsync(evento);
            return new ResponseModel<Event>
            {
                Mensagem = "Evento criado com sucesso",
            };
        }
        catch (ArgumentException ex)
        {
            return new ResponseModel<Event>
            {
                Mensagem = ex.Message,
                Status = false
            };
        }
    }

    public async Task<ResponseModel<Event>> DeleteAsync(Guid id)
    {
        try
        {
            await _eventService.DeleteAsync(id);
            return new ResponseModel<Event>
            {
                Mensagem = "Evento excluindo com sucesso"
            };
        }catch(ArgumentException ex)
        {
            return new ResponseModel<Event>
            {
                Mensagem = ex.Message,
                Status = false
            };
        }
    }

   public async Task<PagedResponse<EventGetDto>> GetAllAsync(int pageNumber, int pageSize)
    {
        var (eventos, totalItems) = await _eventService.GetAllAsync(pageNumber, pageSize);
        var eventosDto = _mapper.Map<IEnumerable<EventGetDto>>(eventos);
        var pagedResponse = new PagedResponse<EventGetDto>(
            eventosDto,
            pageNumber,
            pageSize,
            totalItems
        );
        return pagedResponse;
    }

    public async Task<ResponseModel<EventGetDto>> GetByIdAsync(Guid id)
    {
        try
        {
         var evento = await _eventService.GetByIdAsync(id);
         var eventoDto = _mapper.Map<EventGetDto>(evento);
         return new ResponseModel<EventGetDto>
         {
             Dados = eventoDto,
             Mensagem = "Evento Obtido com sucesso"
         };
        }catch(ArgumentException ex)
        {
            return new ResponseModel<EventGetDto>
            {
                Mensagem = ex.Message,
                Status = false
            };
        }
    }

    public async Task<ResponseModel<EventGetDto>> GetByIdWithUsersAsync(Guid id)
    {
        try
        {
            
         var evento = await _eventService.GetByIdWithUsersAsync(id);
         var eventoId = _mapper.Map<EventGetDto>(evento);
         return new ResponseModel<EventGetDto>
         {
             Dados = eventoId,
             Mensagem = "Usuarios no evento recuperados com sucesso"
         };
        }catch(ArgumentException ex)
        {
            return new ResponseModel<EventGetDto>
            {
                Mensagem = ex.Message,
                Status = false
            };
        }
    }


    public async Task<ResponseModel<Event>> UpdateAsync(Guid id, EventUpdateDto eventUpdateDto)
    {
        try
        {
            
        var evento = _mapper.Map<Event>(eventUpdateDto);
        evento.Id = id;
        await _eventService.UpdateAsync(evento);
        return new ResponseModel<Event>
            {
                Mensagem = "Evento atualizado com sucesso",
            };
        }catch(ArgumentException ex)
        {
            return new ResponseModel<Event>
            {
                Mensagem = ex.Message,
                Status = false
            };
        }
    }
}