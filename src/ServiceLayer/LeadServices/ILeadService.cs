using CRM.NexPolicy.src.DataLayer.Models.Lead;
using CRM.NexPolicy.src.ViewLayer.DTOs.Lead;

namespace CRM.NexPolicy.src.ServiceLayer.LeadServices
{
    public interface ILeadService
    {
        Task<int> RegisterLeadAsync(LeadModel lead); 
        Task<bool> UpdateLeadAsync(LeadModel lead);
        Task<LeadWithAgentDto?> GetLeadWithAgentNameByIdAsync(int id);
        Task<IEnumerable<LeadWithAgentDto>> GetAllLeadsWithAgentAsync();
    }
}
