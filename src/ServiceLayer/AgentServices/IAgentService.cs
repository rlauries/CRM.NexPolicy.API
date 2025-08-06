using CRM.NexPolicy.src.DataLayer.Models.Agent;
using CRM.NexPolicy.src.ViewLayer.DTOs.Agent;

namespace CRM.NexPolicy.src.ServiceLayer.Agent
{
    public interface IAgentService
    {
        Task<AgentModel> CreateAgentAsync(CreateAgentDto agent);
        Task<AgentModel?> GetAgentByIdAsync(int id);
        Task<List<AgentResponseDto>> GetAllAgentByAgencyIdAsync(int agencyId);
        Task<AgentModel> PatchAgentProfileByIdAsync(AgentPersonalInfoPatchDto dto);

    }
}
