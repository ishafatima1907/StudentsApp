namespace StudentApp.Student.Mapping
{
    using AutoMapper;
    using StudentsApp.Domain.Models;
    using StudentsApp.Students.DTOs;

    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDTO>().ReverseMap();
        }
    }
}
