using StudentsApp.Domain.Models;

namespace StudentsApp.Students.Interfaces
{
    public interface IUserService
    {
        Task<User> AuthenticateUserAsync(string username, string password);
        Task RegisterUserAsync(User user);
    }
}
