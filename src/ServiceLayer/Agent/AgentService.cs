using CRM.NexPolicy.src.DataLayer.Models;
using CRM.NexPolicy.src.DataLayer.Repository.Agent;

namespace CRM.NexPolicy.src.ServiceLayer.Agent
{
    public class AgentService : IAgentService
    {
        private readonly IAgentRepository _agentRepository;

        public AgentService(IAgentRepository agentRepository)
        {
            _agentRepository = agentRepository;
        }

        public async Task<AgentModel> CreateAgentAsync(AgentModel agent)
        {
            return await _agentRepository.CreateAsync(agent);
        }

        public async Task<AgentModel?> GetAgentByIdAsync(int id)
        {
            return await _agentRepository.GetByIdAsync(id);
        }
    }
}
