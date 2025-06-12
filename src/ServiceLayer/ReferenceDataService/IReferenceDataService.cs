using CRM.NexPolicy.src.DataLayer.Models.Lead;
using CRM.NexPolicy.src.DataLayer.Models.Person;

namespace CRM.NexPolicy.src.ServiceLayer.ReferenceDataService
{
    public interface IReferenceDataService
    {
        Task<IEnumerable<LeadSourceModel>> GetLeadSourcesAsync();
        Task<IEnumerable<LeadStatusModel>> GetLeadStatusesAsync();
        Task<IEnumerable<GenderTypeModel>> GetAllGenderTypesAsync();

    }

}
