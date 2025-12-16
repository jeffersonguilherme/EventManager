using EventManager.Application.DTOs;
using EventManager.Domain.Response;

namespace EventManager.Application.Interfaces;

public interface IEventAppService
{
    Task<ResponseModel<EventGetDto>> AddEventAsync(EventCreateDto eventCreateDto);
   Task<PagedResponse<EventGetDto>> GetAllAsync(int pageNumber, int pageSize);
    Task<ResponseModel<EventGetDto>> GetByIdAsync(Guid id);
    Task<ResponseModel<EventGetDto>> UpdateAsync(Guid id, EventUpdateDto eventUpdateDto);
    Task <ResponseModel<bool>> DeleteAsync(Guid id);
    Task<ResponseModel<EventGetDto>> GetByIdWithUsersAsync(Guid id);
}