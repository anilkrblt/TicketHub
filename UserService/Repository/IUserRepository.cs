using UserService.Models;

namespace UserService.Repository
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByIdAsync(int id);
        Task AddUserAsync(User user);
    }
}