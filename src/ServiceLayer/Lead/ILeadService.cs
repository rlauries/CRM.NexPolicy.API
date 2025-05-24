using CRM.NexPolicy.src.DataLayer.Models;

namespace CRM.NexPolicy.src.ServiceLayer.Lead
{
    public interface ILeadService
    {
        Task<int> RegisterLeadAsync(LeadModel lead); 
        Task<bool> UpdateLeadAsync(LeadModel lead);

    }
}
