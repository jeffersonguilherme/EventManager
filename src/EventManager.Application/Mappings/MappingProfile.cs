using AutoMapper;
using EvenetManager.Application.DTOs.Users;
using EventManager.Application.DTOs.Events;
using EventManager.Domain.Models;

namespace EventManager.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<EventCreateDto, Event>();
        CreateMap<EventUpdateDto, Event>();
        CreateMap<Event, EventResponseDto>();

        //User 
        CreateMap<UserCreateDto, User>();
        CreateMap<UserUpdateDto, User>();
        CreateMap<User, UserResponseDto>();

    }
}