using StudentsApp.Domain.Models;
using StudentsApp.Students.Interfaces;

namespace StudentsApp.Students.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> AuthenticateUserAsync(string username, string password)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);
            if (user == null || user.Password != password)
            {
                return null;
            }

            return user;
        }

        public async Task RegisterUserAsync(User user)
        {
            await _userRepository.AddUserAsync(user);
        }
    }
}
