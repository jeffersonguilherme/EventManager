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

    public async Task<PagedResponse<UserGetDto>> GetAllAsync(int pageNumber, int pageSize)
    {
        try
        {
            
        var pagedResult = await _userService.GetAllPagedAsync(pageNumber, pageSize);
        var userDto = _mapper.Map<IEnumerable<UserGetDto>>(pagedResult.Dados);

        return new PagedResponse<UserGetDto>(
            userDto,
            pagedResult.PageNumber,
            pagedResult.PageSize,
            pagedResult.TotalItems
        );
        }catch(Exception ex)
        {
            return new PagedResponse<UserGetDto>
            {
                Dados = Enumerable.Empty<UserGetDto>(),
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalItems = 0,
                TotalPages = 0
            };
        }
    }

    public async Task<ResponseModel<UserGetDto>> GetByIdAsync(Guid id)
    {
        try
        {
            var user = await _userService.GetByIdAsync(id);
            var userDto = _mapper.Map<UserGetDto>(user);
            return new ResponseModel<UserGetDto>
            {
              Dados = userDto,
              Mensagem = "Usuário localizado!"  
            };
        }catch(ArgumentException ex)
        {
            return new ResponseModel<UserGetDto>
            {
                Mensagem = ex.Message,
                Status = false
            };
        }
    }

    public async Task<ResponseModel<UserUpdateDto>> UpdateAync(Guid id, UserUpdateDto userUpdateDto)
    {
        try
        {
            var user = _mapper.Map<User>(userUpdateDto);
            user.Id = id;
            await _userService.UpdateAsync(user);
            return new ResponseModel<UserUpdateDto>
            {
                Mensagem = $"{user.Id} Atualizado com sucesso!"
            };
        }catch(ArgumentException ex)
        {
            return new ResponseModel<UserUpdateDto>
            {
                Mensagem = ex.Message,
                Status = false
            };
        }
    }
}