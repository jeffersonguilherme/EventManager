using EventManager.Application.DTOs;
using EventManager.Application.DTOs.Events;
using EventManager.Domain.Response;

namespace EventManager.Application.Interfaces;

public interface IEventAppService
{
    Task<ResponseModel<EventCreateDto>> AddEventAsync(EventCreateDto eventCreateDto);
   Task<PagedResponse<EventResponseDto>> GetAllAsync(int pageNumber, int pageSize);
    Task<ResponseModel<EventResponseDto>> GetByIdAsync(Guid id);
    Task<ResponseModel<EventResponseDto>> UpdateAsync(Guid id, EventUpdateDto eventUpdateDto);
    Task <ResponseModel<bool>> DeleteAsync(Guid id);

}