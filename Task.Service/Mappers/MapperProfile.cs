using AutoMapper;
using Task.Domain.Entities;
using Task.Service.DTOs.ClassDTOs;
using Task.Service.DTOs.StudentDTOs;

namespace Task.Service.Mappers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        // students
        CreateMap<Student, StudentForCreationDto>().ReverseMap();
        CreateMap<Student, StudentForResultDto>().ReverseMap();
        CreateMap<Student, StudentForUpdateDto>().ReverseMap();

        // classes
        CreateMap<Class, ClassForCreationDto>().ReverseMap();   
        CreateMap<Class, ClassForResultDto>().ReverseMap();
        CreateMap<Class, ClassForUpdateDto>().ReverseMap();
    }
}
