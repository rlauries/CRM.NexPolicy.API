using CRM.NexPolicy.src.DataLayer.Models;
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
