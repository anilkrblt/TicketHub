using UserService.Models;

namespace UserService.Service
{
    public interface IUserService
    {
        Task<User> RegisterAsync(string name, string email, string phone, string password);
        Task<User> AuthenticateAsync(string email, string password);
        string GenerateJwtToken(User user);
        Task<User?> GetUserByIdAsync(int id);
        Task<List<User>> GetAllUsersAsync();
    }
}