using CRM.NexPolicy.src.DataLayer.Models.Agency;

namespace CRM.NexPolicy.src.DataLayer.Repository.AgencyRepository
{
    public interface IAgencyRepository
    {
        Task<List<AgencyModel>> GetAllAsync();
        Task<AgencyModel?> GetByIdAsync(int id);
        Task<AgencyModel> AddAsync(AgencyModel agency);
        Task<bool> UpdateAsync(AgencyModel agency);
    }
}
