using StudentsApp.Domain.Models;

namespace StudentsApp.Students.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByUsernameAsync(string username);
        Task AddUserAsync(User user);
    }
}
