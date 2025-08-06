using CRM.NexPolicy.src.DataLayer.Models.Agent;
using CRM.NexPolicy.src.ViewLayer.DTOs.Agent;

namespace CRM.NexPolicy.src.DataLayer.Repository.AgentRepository
{
    public interface IAgentRepository
    {
        Task<AgentModel> CreateAsync(AgentModel agent);
        Task<AgentModel?> GetByIdAsync(int id);
        // IAgentRepository.cs
        Task<List<AgentModel>> GetAllAgentyByAgencyIdAsync(int agencyId);
        Task<AgentModel> PatchAgentProfileByIdAsync(AgentPersonalInfoPatchDto dto);
    }
}
