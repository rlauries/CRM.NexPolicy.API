using CRM.NexPolicy.src.DataLayer.Models.Lead;
using CRM.NexPolicy.src.DataLayer.Models.Person;
using CRM.NexPolicy.src.DataLayer.Repository.ReferenceDataRepository;

namespace CRM.NexPolicy.src.ServiceLayer.ReferenceDataService
{
    public class ReferenceDataService : IReferenceDataService
    {
        private readonly IReferenceDataRepository _repository;

        public ReferenceDataService(IReferenceDataRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<LeadSourceModel>> GetLeadSourcesAsync()
            => _repository.GetAllLeadSourcesAsync();

        public Task<IEnumerable<LeadStatusModel>> GetLeadStatusesAsync()
            => _repository.GetAllLeadStatusesAsync();
        public Task<IEnumerable<GenderTypeModel>> GetAllGenderTypesAsync()
        => _repository.GetAllGenderTypesAsync();
    }

}
