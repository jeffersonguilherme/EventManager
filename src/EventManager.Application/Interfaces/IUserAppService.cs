using EvenetManager.Domain.DTOs.User;
using EventManager.Domain.Models;
using EventManager.Domain.Response;

namespace EventManager.Application.Interfaces;

public interface IUserAppService
{
    Task<ResponseModel<User>> AddUserAsync(UserCreateDto userCreateDto);
}