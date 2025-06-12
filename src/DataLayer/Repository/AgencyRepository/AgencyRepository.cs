using CRM.NexPolicy.src.DataLayer.Models.Agency;
using Microsoft.EntityFrameworkCore;

namespace CRM.NexPolicy.src.DataLayer.Repository.AgencyRepository
{
    public class AgencyRepository : IAgencyRepository
    {
        private readonly AppDbContext _dbContext;

        public AgencyRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<AgencyModel>> GetAllAsync()
        {
            return await _dbContext.Agencies.Include(a => a.Agents).ToListAsync();
        }

        public async Task<AgencyModel?> GetByIdAsync(int id)
        {
            return await _dbContext.Agencies.Include(a => a.Agents).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<AgencyModel> AddAsync(AgencyModel agency)
        {
            _dbContext.Agencies.Add(agency);
            await _dbContext.SaveChangesAsync();
            return agency;
        }
        public async Task<bool> UpdateAsync(AgencyModel agency)
        {
            _dbContext.Agencies.Update(agency);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
