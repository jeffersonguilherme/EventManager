using AutoMapper;
using EvenetManager.Domain.DTOs.User;
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

        //User 
        CreateMap<User, UserCreateDto>().ReverseMap();
        CreateMap<UserCreateDto, User>().ReverseMap();
        CreateMap<UserGetDto, User>().ReverseMap();
        CreateMap<User, UserGetDto>().ReverseMap();
        CreateMap<User, UserUpdateDto>().ReverseMap();
        CreateMap<UserUpdateDto, User>().ReverseMap();

    }
}