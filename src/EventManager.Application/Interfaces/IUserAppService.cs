using EvenetManager.Application.DTOs.Users;
using EventManager.Application.DTOs.Login;
using EventManager.Domain.Response;

namespace EventManager.Application.Interfaces;

public interface IUserAppService
{
    Task<ResponseModel<UserCreateDto>> AddUserAsync(UserCreateDto userCreateDto);
    Task<ResponseModel<UserResponseDto>> GetByIdAsync(Guid id);
    Task<PagedResponse<UserResponseDto>> GetAllAsync(int pageNumber, int pageSize);
    Task<ResponseModel<UserUpdateDto>> UpdateAync(Guid id, UserUpdateDto userCreateDto);
    Task<ResponseModel<bool>> DeleteAsync(Guid id);
    Task<ResponseModel<LoginResponse>> LoginAsync(LoginRequest request);
}