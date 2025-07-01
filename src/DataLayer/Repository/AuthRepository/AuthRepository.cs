using CRM.NexPolicy.src.DataLayer.Models.Auth;
using CRM.NexPolicy.src.DataLayer.Repository;
using Microsoft.EntityFrameworkCore;

namespace CRM.NexPolicy.src.DataLayer.Repository.AuthRepository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _context;

        public AuthRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserModel?> GetUserByEmailAsync(string email) =>
             await _context.Users
                 .Include(u => u.Role)
                 .Include(u => u.Agency) // ✅ Aquí agregas la relación con Agency
                 .FirstOrDefaultAsync(u => u.Email == email);

        public async Task<bool> UserExistsAsync(string email) =>
            await _context.Users.AnyAsync(u => u.Email == email);

        public async Task AddUserAsync(UserModel user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();
    }
}
