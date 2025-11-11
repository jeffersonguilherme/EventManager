using AutoMapper;
using EventManager.Application.DTOs;
using EventManager.Domain.Models;

namespace EventManager.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Event, EventViewModel>().ReverseMap();
    }
}