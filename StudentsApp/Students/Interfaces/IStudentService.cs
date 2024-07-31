using StudentsApp.Domain.Models;
using StudentsApp.Students.DTOs;

namespace StudentsApp.Infrastructure.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDTO>> GetAllStudentsAsync();
        Task<StudentDTO> GetStudentByIdAsync(int id);
        Task AddStudentAsync(StudentDTO studentDto);
        Task UpdateStudentAsync(StudentDTO studentDto);
        Task DeleteStudentAsync(int id);
    }
}
