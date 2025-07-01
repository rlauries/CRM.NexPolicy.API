using CRM.NexPolicy.src.DataLayer.Models.Auth;

namespace CRM.NexPolicy.src.DataLayer.Repository.UserRepository
{
    public interface IUserRepository
    {
        Task<UserModel?> GetByEmailAsync(string email);
        Task<UserModel?> GetByIdAsync(int id);
        Task AddAsync(UserModel user);
        Task<bool> SaveChangesAsync();
    }
}
