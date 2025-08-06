using CRM.NexPolicy.src.DataLayer.Models.Lead;
using CRM.NexPolicy.src.DataLayer.Repository.LeadRepository;
using CRM.NexPolicy.src.ServiceLayer.LeadServices;
using CRM.NexPolicy.src.ViewLayer.DTOs.Lead;
using Microsoft.Identity.Client;

namespace CRM.NexPolicy.src.ServiceLayer.LeadServices
{
    public class LeadService : ILeadService
    {
        private readonly ILeadRepository _leadRepository;

        public LeadService(ILeadRepository leadRepository)
        {
            _leadRepository = leadRepository;
        }

        public async Task<int> RegisterLeadAsync(CreateLeadDto lead)
        {
            var creatingLeads = new LeadModel();
            creatingLeads.Name = lead.Name;
            creatingLeads.LastName = lead.LastName;
            creatingLeads.Email = lead.Email;
            creatingLeads.PhoneNumber = lead.PhoneNumber;
            creatingLeads.LeadStatusId = lead.LeadStatusId;
            creatingLeads.LeadSourceId = lead.LeadSourceId;
            creatingLeads.AgencyId = lead.AgencyId;

            // Aquí puedes agregar lógica adicional (validaciones, normalización, etc.)
            return await _leadRepository.InsertAsync(creatingLeads);
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
            existing.LeadSourceId = lead.LeadSourceId;

            await _leadRepository.UpdateAsync(existing);
            return true;
        }

        public async Task<LeadWithAgentDto?> GetLeadWithAgentNameByIdAsync(int id)
        {
            var lead = await _leadRepository.GetLeadByIdAsync(id);
            if (lead == null) return null;

            return new LeadWithAgentDto
            {
                ID = lead.ID,
                Name = lead.Name,
                LastName = lead.LastName,
                Email = lead.Email,
                PhoneNumber = lead.PhoneNumber,
                Address = lead.Address,
                CreatedAt = lead.CreatedAt,
                IsConvertedToCustomer = lead.IsConvertedToCustomer,
                ConvertedToCustomerAt = lead.ConvertedToCustomerAt,
                AssignedAgentFullName = lead.Agent != null
                    ? $"{lead.Agent.FirstName} {lead.Agent.LastName}"
                    : null,
                StatusName = lead.Status?.Name,
                LeadSourceName = lead.LeadSource?.Name
            };
        }

        //-----Get Lead by Agency Id -------------------
        public async Task<IEnumerable<LeadWithAgentDto>> GetAllLeadsByAgencyIdAsync(int agencyId)
        {
            var leads = await _leadRepository.GetAllLeadsByAgencyIdAsync(agencyId);

            return leads.Select(lead => new LeadWithAgentDto
            {
                ID = lead.ID,
                Name = lead.Name,
                LastName = lead.LastName,
                Email = lead.Email,
                PhoneNumber = lead.PhoneNumber,
                Address = lead.Address,
                CreatedAt = lead.CreatedAt,
                IsConvertedToCustomer = lead.IsConvertedToCustomer,
                ConvertedToCustomerAt = lead.ConvertedToCustomerAt,
                AssignedAgentFullName = lead.Agent != null
                        ? $"{lead.Agent.FirstName} {lead.Agent.LastName}"
                        : null,
                StatusName = lead.Status?.Name,
                LeadSourceName = lead.LeadSource?.Name
            }).ToList();
        }


    }

}
