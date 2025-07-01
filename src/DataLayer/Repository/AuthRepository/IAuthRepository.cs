using CRM.NexPolicy.src.DataLayer.Models.Auth;

namespace CRM.NexPolicy.src.DataLayer.Repository.AuthRepository
{
    public interface IAuthRepository
    {
        Task<UserModel?> GetUserByEmailAsync(string email);
        Task<bool> UserExistsAsync(string email);
        Task AddUserAsync(UserModel user);
        Task SaveChangesAsync();
    }
}
