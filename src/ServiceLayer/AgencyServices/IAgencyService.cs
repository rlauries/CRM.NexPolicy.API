using CRM.NexPolicy.src.DataLayer.Models.Agency;
using CRM.NexPolicy.src.ViewLayer.DTOs.Agency;
using CRM.NexPolicy.src.ViewLayer.DTOs.Agent;

namespace CRM.NexPolicy.src.ServiceLayer.AgencyServices
{
    public interface IAgencyService
    {

        Task<AgencyModel?> GetAgencyByIdAsync(int id);
        Task<List<AgencyModel>> GetAllAgenciesAsync();
        Task<AgencyModel> CreateAgencyWithIdAsync(int id, string businessName);

        Task<bool> UpdateProfileAgencyAsync(int id, CreateAgencyDto agency);
    }
}
