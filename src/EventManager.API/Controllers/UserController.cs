using EvenetManager.Domain.DTOs.User;
using EventManager.Application.DTOs;
using EventManager.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventManager.Api.Controllers;

[Route("api/[controller]")]
[ApiController]

public class UserController : ControllerBase
{
    private readonly IUserAppService _userAppService;

    public UserController(IUserAppService userAppService)
    {
        _userAppService = userAppService;
    }

    [HttpPost]
    public async Task<IActionResult> AddUserAsync(UserCreateDto userCreateDto)
    {
        var response = await _userAppService.AddUserAsync(userCreateDto);
        if(!response.Status)
            return BadRequest(response);

        return Ok(response);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var user = await _userAppService.GetByIdAsync(id);
        return Ok(user);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUser(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 4
    )
    {
        var usersPaginado = await _userAppService.GetAllAsync(pageNumber, pageSize);
        return Ok(usersPaginado);
    }

}