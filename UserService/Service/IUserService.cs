using UserService.Models;

namespace UserService.Service
{
    public interface IUserService
    {
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> GetUserByEmailAsync(string email);
        Task<User> RegisterAsync(string name, string email, string phone, string password);
        Task<User> AuthenticateAsync(string email, string password);
        string GenerateJwtToken(User user);
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}