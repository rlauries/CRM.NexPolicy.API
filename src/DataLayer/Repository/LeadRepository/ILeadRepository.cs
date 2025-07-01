using CRM.NexPolicy.src.DataLayer.Models.Lead;

namespace CRM.NexPolicy.src.DataLayer.Repository.LeadRepository;

public interface ILeadRepository
{
    Task<int> InsertAsync(LeadModel lead);
    Task<LeadModel?> GetLeadByIdAsync(int leadId);
    Task UpdateAsync(LeadModel lead);
    Task<List<LeadModel>> GetAllLeadsAsync();


}
