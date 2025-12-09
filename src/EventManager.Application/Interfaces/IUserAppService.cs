using EvenetManager.Domain.DTOs.User;
using EventManager.Domain.Models;
using EventManager.Domain.Response;

namespace EventManager.Application.Interfaces;

public interface IUserAppService
{
    Task<ResponseModel<UserCreateDto>> AddUserAsync(UserCreateDto userCreateDto);
    Task<ResponseModel<UserGetDto>> GetByIdAsync(Guid id);
    Task<PagedResponse<UserGetDto>> GetAllAsync(int pageNumber, int pageSize);
    Task<ResponseModel<UserUpdateDto>> UpdateAync(Guid id, UserUpdateDto userCreateDto);
    Task<ResponseModel<UserGetDto>> DeleteAsync(Guid id);
}