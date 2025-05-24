using CRM.NexPolicy.src.DataLayer.Models;
using CRM.NexPolicy.src.DataLayer.Repository;
using CRM.NexPolicy.src.DataLayer.Repository.Customer;
using CRM.NexPolicy.src.DataLayer.Repository.Lead;
using Microsoft.EntityFrameworkCore;
using static CRM.NexPolicy.src.DataLayer.Enums.EnumExtensions;

namespace CRM.NexPolicy.src.ServiceLayer.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILeadRepository _leadRepository;

        public CustomerService(ICustomerRepository customerRepository, ILeadRepository leadRepository)
        {
            _customerRepository = customerRepository;
            _leadRepository = leadRepository;
        }
         //Create customer without being Lead before
        public async Task<CustomerModel> CreateCustomerAsync(CustomerModel customer)
        {
            await _customerRepository.CreateAsync(customer);

            return customer;
        }

        public async Task<CustomerModel?> GetCustomerByIdAsync(int id)
        {
            return await _customerRepository.GetByIdAsync(id);

        }

        //Convert Lead into Customer
        public async Task<CustomerModel?> ConvertLeadIntoCustomerAsync(int leadId)
        {
            var lead = await _leadRepository.GetLeadByIdAsync(leadId);
            if (lead == null || lead.IsConvertedToCustomer)
                return null;

            var customer = new CustomerModel
            {
                FirstName = lead.Name,
                LastName = lead.LastName,
                Email = lead.Email,
                CellPhone = lead.PhoneNumber,
                AgentId = lead.AssignedAgentID,
                EnrollmentDate = DateTime.UtcNow
            };

            await _customerRepository.CreateAsync(customer);

            lead.IsConvertedToCustomer = true;
            lead.ConvertedToCustomerAt = DateTime.UtcNow;
            lead.Status = LeadStatus.Converted;

            await _leadRepository.UpdateAsync(lead);

            return customer;
        }

        public async Task<bool> UpdateCustomerAsync(CustomerModel customer)
        {
            var existing = await _customerRepository.GetByIdAsync(customer.Id);
            if (existing == null)
                return false;

            // Actualiza solo los campos permitidos
            existing.FirstName = customer.FirstName;
            existing.LastName = customer.LastName;
            existing.Email = customer.Email;
            existing.HomePhone = customer.HomePhone;
            existing.CellPhone = customer.CellPhone;
            existing.PlanType = customer.PlanType;
            existing.EnrollmentDate = customer.EnrollmentDate;
            existing.AgentId = customer.AgentId;

            await _customerRepository.UpdateAsync(existing);
            return true;
        }

    }
}
