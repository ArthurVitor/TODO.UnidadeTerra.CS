using AutoMapper;
using ToDoProject.Data.Dtos;
using ToDoProject.Models;

namespace ToDoProject.Profiles;

public class ToDoProfile : Profile
{
    public ToDoProfile()
    {
        CreateMap<CreateToDoDto, ToDoModel>();
        CreateMap<ToDoModel, ReadToDoDto>();
        CreateMap<UpdateToDoDto, ToDoModel>();
    }
}