using StudentsApp.Domain.Models;
using StudentsApp.Students.DTOs;

namespace Services.Managers.Interfaces
{
    public interface ITokenService
    {
        Task<string> GetTokenAsync(int id);
    }
}
