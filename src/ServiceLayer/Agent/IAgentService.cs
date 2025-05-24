using CRM.NexPolicy.src.DataLayer.Models;

namespace CRM.NexPolicy.src.ServiceLayer.Agent
{
    public interface IAgentService
    {
        Task<AgentModel> CreateAgentAsync(AgentModel agent);
        Task<AgentModel?> GetAgentByIdAsync(int id);
    }
}
