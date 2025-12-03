using EventManager.Application.DTOs;
using EventManager.Domain.Models;
using EventManager.Domain.Response;

namespace EventManager.Application.Interfaces;

public interface IEventAppService
{
    Task<ResponseModel<Event>> AddEventoAsync(EventCreateDto eventCreateDto);
   Task<PagedResponse<EventGetDto>> GetAllAsync(int pageNumber, int pageSize);
    Task<ResponseModel<EventGetDto>> GetByIdAsync(Guid id);
    Task<ResponseModel<Event>> UpdateAsync(Guid id, EventUpdateDto eventUpdateDto);
    Task <ResponseModel<Event>> DeleteAsync(Guid id);
    Task<ResponseModel<EventGetDto>> GetByIdWithUsersAsync(Guid id);
}