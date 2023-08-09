using AutoMapper;
using U_DO.Data.DTO;
using U_DO.Models;

namespace U_DO.Profiles;

public class CourseProfile : Profile
{
    public CourseProfile()
    {
        CreateMap<CreateCourseDto, Course>();
        CreateMap<UpdateCourseDto, Course>();
        CreateMap<Course, UpdateCourseDto>();
        CreateMap<Course, ReadCourseDto>();
    }
}
