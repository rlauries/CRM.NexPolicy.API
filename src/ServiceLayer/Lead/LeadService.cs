using CRM.NexPolicy.src.DataLayer.Models;
using CRM.NexPolicy.src.DataLayer.Repository.Lead;
using static CRM.NexPolicy.src.DataLayer.Enums.EnumExtensions;

namespace CRM.NexPolicy.src.ServiceLayer.Lead
{
    public class LeadService : ILeadService
    {
        private readonly ILeadRepository _leadRepository;

        public LeadService(ILeadRepository leadRepository)
        {
            _leadRepository = leadRepository;
        }

        public async Task<int> RegisterLeadAsync(LeadModel lead)
        {
            if (!Enum.IsDefined(typeof(LeadSource), lead.Source))
                throw new ArgumentException("Invalid lead source");

            // Aquí puedes agregar lógica adicional (validaciones, normalización, etc.)
            return await _leadRepository.InsertAsync(lead);
        }
        public async Task<bool> UpdateLeadAsync(LeadModel lead)
        {
            var existing = await _leadRepository.GetLeadByIdAsync(lead.ID);
            if (existing == null)
                return false;

            // Actualiza los campos permitidos
            existing.Name = lead.Name;
            existing.LastName = lead.LastName;
            existing.Email = lead.Email;
            existing.PhoneNumber = lead.PhoneNumber;
            existing.Address = lead.Address;
            existing.Status = lead.Status;
            existing.Source = lead.Source;

            await _leadRepository.UpdateAsync(existing);
            return true;
        }

    }

}
