using AutoMapper;
using U_DO.Data.DTO;
using U_DO.Models;

namespace U_DO.Profiles;

public class TaskProfile : Profile
{
    public TaskProfile()
    {
        CreateMap<CreateTaskDto, ToDoTask>();
        CreateMap<UpdateTaskDto, ToDoTask>();
    }
}
