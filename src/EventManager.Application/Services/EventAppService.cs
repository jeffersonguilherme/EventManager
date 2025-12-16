using AutoMapper;
using EventManager.Application.DTOs;
using EventManager.Application.DTOs.Events;
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

    public async Task<ResponseModel<EventCreateDto>> AddEventAsync(EventCreateDto eventCreateDto)
    {
        try
        {
            var evento = _mapper.Map<Event>(eventCreateDto);
            await _eventService.AddAsync(evento);
            var eventoDto = _mapper.Map<EventCreateDto>(evento);
            return new ResponseModel<EventCreateDto>
            {
                Dados = eventoDto,
                Mensagem = "Evento criado com sucesso",
            };
        }
        catch (ArgumentException ex)
        {
            return new ResponseModel<EventCreateDto>
            {
                Mensagem = ex.Message,
                Status = false
            };
        }
    }


   public async Task<PagedResponse<EventResponseDto>> GetAllAsync(int pageNumber, int pageSize)
    {
        var (eventos, totalItems) = await _eventService.GetAllAsync(pageNumber, pageSize);
        var eventosDto = _mapper.Map<IEnumerable<EventResponseDto>>(eventos);
        var pagedResponse = new PagedResponse<EventResponseDto>(
            eventosDto,
            pageNumber,
            pageSize,
            totalItems
        );
        return pagedResponse;
    }

    public async Task<ResponseModel<EventResponseDto>> GetByIdAsync(Guid id)
    {
        try
        {
         var evento = await _eventService.GetByIdAsync(id);
         var eventoDto = _mapper.Map<EventResponseDto>(evento);
         return new ResponseModel<EventResponseDto>
         {
             Dados = eventoDto,
             Mensagem = "Evento Obtido com sucesso"
         };
        }catch(ArgumentException ex)
        {
            return new ResponseModel<EventResponseDto>
            {
                Mensagem = ex.Message,
                Status = false
            };
        }
    }

    public async Task<ResponseModel<EventResponseDto>> UpdateAsync(Guid id, EventUpdateDto eventUpdateDto)
    {
        try
        {
            
            var eventoExistente = await _eventService.GetByIdAsync(id);
            if(eventoExistente == null)
            {
                return new ResponseModel<EventResponseDto>
                {
                    Status = false,
                    Mensagem = "Evento não encontrado"
                };
            }
                _mapper.Map(eventUpdateDto, eventoExistente);
                await _eventService.UpdateAsync(eventoExistente);

                var eventoDto = _mapper.Map<EventResponseDto>(eventoExistente);

                return new ResponseModel<EventResponseDto>
                {
                    Mensagem = "Evento atualizado com sucesso",
                    Dados = eventoDto
                };
        }catch(ArgumentException ex)
        {
            return new ResponseModel<EventResponseDto>
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
}