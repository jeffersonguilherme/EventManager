using AutoMapper;
using EventManager.Application.DTOs;
using EventManager.Domain.Models;

namespace EventManager.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<EventUpdateDto, Event>().ReverseMap();
        CreateMap<Event, EventCreateDto>().ReverseMap();
        CreateMap<Event, EventGetDto>().ReverseMap();
    }
}