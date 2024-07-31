using Microsoft.EntityFrameworkCore;
using StudentsApp.Domain.Models;
using StudentsApp.Infrastructure.Data;
using StudentsApp.Infrastructure.Interfaces;

namespace StudentsApp.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _context;

        public StudentRepository(StudentDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllAsync() => await _context.Students.ToListAsync();

        public async Task<Student> GetByIdAsync(int id) => await _context.Students.FindAsync(id);

        public async Task AddAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var student = await GetByIdAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }
    }
}
