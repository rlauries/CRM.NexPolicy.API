using CRM.NexPolicy.src.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace CRM.NexPolicy.src.DataLayer.Repository.Agent
{
    public class AgentRepository : IAgentRepository
    {
        private readonly AppDbContext _dbContext;

        public AgentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AgentModel> CreateAsync(AgentModel agent)
        {
            _dbContext.Agents.Add(agent);
            await _dbContext.SaveChangesAsync();
            return agent;
        }

        public async Task<AgentModel?> GetByIdAsync(int id)
        {
            return await _dbContext.Agents
                .Include(a => a.Leads)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
