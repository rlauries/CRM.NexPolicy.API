using CRM.NexPolicy.src.DataLayer.Models.Auth;
using CRM.NexPolicy.src.DataLayer.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq; // ← necesario para LINQ


namespace CRM.NexPolicy.src.DataLayer.Repository.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserModel?> GetByEmailAsync(string email)
        {
            return await _context.Users
                .Include(u => u.Role)
                .Include(u => u.Agent)
                .Include(u => u.Agency)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<UserModel?> GetByIdAsync(int id)
        {
            return await _context.Users
                .Include(u => u.Role)
                .Include(u => u.Agent)
                .Include(u => u.Agency)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task AddAsync(UserModel user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }


    }
}
