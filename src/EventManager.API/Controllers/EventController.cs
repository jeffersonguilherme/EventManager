using EventManager.Application.DTOs;
using EventManager.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventManager.Api.Controllers;

[Route("api/[controller]")]
[ApiController]

public class EventController : ControllerBase
{
    private readonly IEventAppService _eventAppService;

    public EventController(IEventAppService eventAppService)
    {
        _eventAppService = eventAppService;
    }

    [HttpPost]
    public async Task<IActionResult> AddEventAsync(EventCreateDto eventCreateDto)
    {
        var response = await _eventAppService.AddEventAsync(eventCreateDto);
        if(!response.Status)
            return BadRequest(response);

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 3
    )
    {
        var eventosPaginados = await _eventAppService.GetAllAsync(pageNumber, pageSize);
        return Ok(eventosPaginados);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var evento = await _eventAppService.GetByIdAsync(id);
        return Ok(evento);
    }

    [HttpGet("{id:guid}/users")]
    public async Task<IActionResult> GetByIdWithUsers(Guid id)
    {
        var evento = await _eventAppService.GetByIdWithUsersAsync(id);
        return Ok(evento);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, EventUpdateDto eventUpdateDto)
    {
        await _eventAppService.UpdateAsync(id, eventUpdateDto);
        return Ok("Evento atualizado com sucesso!");
    }
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        await _eventAppService.DeleteAsync(id);
        return Ok("Evento deletado com sucesso");
    }
}