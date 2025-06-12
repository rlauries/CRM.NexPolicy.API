using CRM.NexPolicy.src.DataLayer.Models.Agent;
using CRM.NexPolicy.src.ViewLayer.DTOs.Agent;

namespace CRM.NexPolicy.src.ServiceLayer.Agent
{
    public interface IAgentService
    {
        Task<AgentModel> CreateAgentAsync(AgentModel agent);
        Task<AgentResponseDto?> GetAgentDtoByIdAsync(int id);
        Task<List<AgentResponseDto>> GetAllAgentDtosAsync();

    }
}
