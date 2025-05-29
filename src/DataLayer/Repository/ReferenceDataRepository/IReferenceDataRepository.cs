using CRM.NexPolicy.src.DataLayer.Models;

namespace CRM.NexPolicy.src.DataLayer.Repository.ReferenceDataRepository
{
    public interface IReferenceDataRepository
    {
        Task<IEnumerable<LeadSourceModel>> GetAllLeadSourcesAsync();
        Task<IEnumerable<LeadStatusModel>> GetAllLeadStatusesAsync();
        Task<IEnumerable<GenderTypeModel>> GetAllGenderTypesAsync();
    }
}
