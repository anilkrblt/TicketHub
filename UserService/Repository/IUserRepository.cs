using UserService.Models;

namespace UserService.Repository
{
    public interface IUserRepository
    {
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> GetUserByEmailAsync(string email);
        Task<List<User>> GetAllUsersAsync();
        Task AddUserAsync(User user);
        Task SaveChangesAsync();
    }
}