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

    public async Task<ResponseModel<EventGetDto>> AddEventAsync(EventCreateDto eventCreateDto)
    {
        try
        {
            var evento = _mapper.Map<Event>(eventCreateDto);
            await _eventService.AddAsync(evento);
            var eventoDto = _mapper.Map<EventGetDto>(evento);
            return new ResponseModel<EventGetDto>
            {
                Dados = eventoDto,
                Mensagem = "Evento criado com sucesso",
            };
        }
        catch (ArgumentException ex)
        {
            return new ResponseModel<EventGetDto>
            {
                Mensagem = ex.Message,
                Status = false
            };
        }
    }

    public async Task<ResponseModel<bool>> DeleteAsync(Guid id)
    {
        try
        {
            await _eventService.DeleteAsync(id);
            return new ResponseModel<bool>
            {
                Mensagem = "Evento excluído com sucesso"
            };
        }catch(ArgumentException ex)
        {
            return new ResponseModel<bool>
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


    public async Task<ResponseModel<EventGetDto>> UpdateAsync(Guid id, EventUpdateDto eventUpdateDto)
    {
        try
        {
            
            var eventoExistente = await _eventService.GetByIdAsync(id);
            if(eventoExistente == null)
            {
                return new ResponseModel<EventGetDto>
                {
                    Status = false,
                    Mensagem = "Evento não encontrado"
                };
            }
                _mapper.Map(eventUpdateDto, eventoExistente);
                await _eventService.UpdateAsync(eventoExistente);

                var eventoDto = _mapper.Map<EventGetDto>(eventoExistente);

                return new ResponseModel<EventGetDto>
                {
                    Mensagem = "Evento atualizado com sucesso",
                    Dados = eventoDto
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
}