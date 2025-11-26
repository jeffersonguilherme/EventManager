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
        await _eventAppService.AddEventoAsync(eventCreateDto);
        return Ok("Evento criado com sucesso.");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var eventos = await _eventAppService.GetAllAsync();
        return Ok(eventos);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
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
    public async Task<IActionResult> Update(Guid id, EventUpdateDto eventUpdateDto)
    {
        await _eventAppService.UpdateAsync(id, eventUpdateDto);
        return Ok("Evento atualizado com sucesso!");
    }
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _eventAppService.DeleteAsync(id);
        return Ok("Evento deletado com sucesso");
    }
}