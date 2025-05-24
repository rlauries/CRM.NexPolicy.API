using CRM.NexPolicy.src.DataLayer.Models;

namespace CRM.NexPolicy.src.DataLayer.Repository.Lead
{
    public interface ILeadRepository
    {
        Task<int> InsertAsync(LeadModel lead);
        Task<LeadModel?> GetLeadByIdAsync(int leadId);
        Task UpdateAsync(LeadModel lead);

    }
}
