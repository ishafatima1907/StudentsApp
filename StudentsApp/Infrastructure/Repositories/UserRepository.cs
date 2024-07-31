using Microsoft.EntityFrameworkCore;
using StudentsApp.Domain.Models;
using StudentsApp.Infrastructure.Data;
using StudentsApp.Students.Interfaces;

namespace StudentsApp.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly StudentDbContext _context;

        public UserRepository(StudentDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Username == username);
        }

        public async Task AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}
