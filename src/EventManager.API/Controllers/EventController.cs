using EventManager.Application.DTOs;
using EventManager.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventManager.Api.Controller;

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
    public async Task<IActionResult> AddEventAsync(EventViewModel eventViewModel)
    {
        await _eventAppService.AddEventoAsync(eventViewModel);
        return Ok();
    }
}