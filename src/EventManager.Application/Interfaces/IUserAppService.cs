using EvenetManager.Application.DTOs.Users;
using EvenetManager.Domain.DTOs.User;
using EventManager.Domain.Models;
using EventManager.Domain.Response;

namespace EventManager.Application.Interfaces;

public interface IUserAppService
{
    Task<ResponseModel<UserCreateDto>> AddUserAsync(UserCreateDto userCreateDto);
    Task<ResponseModel<UserResponseDto>> GetByIdAsync(Guid id);
    Task<PagedResponse<UserResponseDto>> GetAllAsync(int pageNumber, int pageSize);
    Task<ResponseModel<UserUpdateDto>> UpdateAync(Guid id, UserUpdateDto userCreateDto);
    Task<ResponseModel<UserResponseDto>> DeleteAsync(Guid id);
}