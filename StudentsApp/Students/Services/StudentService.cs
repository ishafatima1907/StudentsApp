using AutoMapper;
using StudentsApp.Domain.Models;
using StudentsApp.Infrastructure.Interfaces;
using StudentsApp.Students.DTOs;

namespace StudentsApp.Infrastructure.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentDTO>> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<StudentDTO>>(students);
        }

        public async Task<StudentDTO> GetStudentByIdAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            return _mapper.Map<StudentDTO>(student);
        }

        public async Task AddStudentAsync(StudentDTO studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            await _studentRepository.AddAsync(student);
        }

        public async Task UpdateStudentAsync(StudentDTO studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            await _studentRepository.UpdateAsync(student);
        }

        public async Task DeleteStudentAsync(int id)
        {
            await _studentRepository.DeleteAsync(id);
        }
    }
}

