using AutoMapper;
using EvenetManager.Domain.DTOs.User;
using EventManager.Application.Interfaces;
using EventManager.Domain.Models;
using EventManager.Domain.Response;
using EventManager.Domain.Services;

namespace EventManager.Application.Services;

public class UserAppService : IUserAppService
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserAppService(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    public async Task<ResponseModel<UserCreateDto>> AddUserAsync(UserCreateDto userCreateDto)
    {
        try
        {
            var user = _mapper.Map<User>(userCreateDto);
            await _userService.AddAsync(user);
            return new ResponseModel<UserCreateDto>
            {
                Mensagem = "Usuário Criado com Sucesso"
            };
        }catch(Exception ex)
        {
            return new ResponseModel<UserCreateDto>
            {
                Mensagem = ex.Message,
                Status = false
            };
        }
    }

    public Task<ResponseModel<UserGetDto>> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResponse<UserGetDto>> GetAllAsync(int pageNumber, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseModel<UserGetDto>> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseModel<UserUpdateDto>> UpdateAync(Guid id, UserUpdateDto userUpdateDto)
    {
        throw new NotImplementedException();
    }
}