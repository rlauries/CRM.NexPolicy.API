using CRM.NexPolicy.src.DataLayer.Models.Lead;
using CRM.NexPolicy.src.DataLayer.Models.Person;
using CRM.NexPolicy.src.DataLayer.Repository;
using Microsoft.EntityFrameworkCore;

namespace CRM.NexPolicy.src.DataLayer.Repository.ReferenceDataRepository
{
    public class ReferenceDataRepository : IReferenceDataRepository
    {
        private readonly AppDbContext _context;

        public ReferenceDataRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LeadSourceModel>> GetAllLeadSourcesAsync()
        {
            return await _context.LeadSources.ToListAsync();
        }

        public async Task<IEnumerable<LeadStatusModel>> GetAllLeadStatusesAsync()
        {
            return await _context.LeadStatuses.ToListAsync();
        }
        public async Task<IEnumerable<GenderTypeModel>> GetAllGenderTypesAsync()
        {
            return await _context.GenderTypes.ToListAsync();
        }
    }

}
