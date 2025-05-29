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
                .Include(a => a.Customers)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<AgentModel>> GetAllAsync()
        {
            var allAgent = await _dbContext.Agents
                .Include(a => a.Leads)
                .Include(a => a.Customers)
                .AsNoTracking()
                .ToListAsync();

            foreach (var agent in allAgent)
            {
                Console.WriteLine($"Agent {agent.Id} has {agent.Leads?.Count ?? 0} leads and {agent.Customers?.Count ?? 0} customers.");
            }

            return allAgent;
        }


    }
}
