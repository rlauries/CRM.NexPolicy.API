using CRM.NexPolicy.src.DataLayer.Models;

namespace CRM.NexPolicy.src.DataLayer.Repository.Agent
{
    public interface IAgentRepository
    {
        Task<AgentModel> CreateAsync(AgentModel agent);
        Task<AgentModel?> GetByIdAsync(int id);
        // IAgentRepository.cs
        Task<List<AgentModel>> GetAllAsync();

    }
}
