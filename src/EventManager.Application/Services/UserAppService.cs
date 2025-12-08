using AutoMapper;
using EvenetManager.Domain.DTOs.User;
using EventManager.Application.DTOs;
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

    public async Task<ResponseModel<User>> AddUserAsync(UserCreateDto userCreateDto)
    {
        try
        {
            var user = _mapper.Map<User>(userCreateDto);
            await _userService.AddAsync(user);
            return new ResponseModel<User>
            {
                Mensagem = "Usuário Criado com Sucesso"
            };
        }catch(Exception ex)
        {
            return new ResponseModel<User>
            {
                Mensagem = ex.Message,
                Status = false
            };
        }
    }
}