using CRM.NexPolicy.src.DataLayer.Models.Customer;
using CRM.NexPolicy.src.DataLayer.Repository;
using CRM.NexPolicy.src.DataLayer.Repository.CustomerRepository;
using CRM.NexPolicy.src.DataLayer.Repository.LeadRepository;
using CRM.NexPolicy.src.ViewLayer.DTOs.Customer;
using Microsoft.EntityFrameworkCore;


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

        public async Task<CustomerWithAgentDto?> GetCustomerWithAgentNameByIdAsync(int id)
        {
            var customer = await _customerRepository.GetCustomerWithAgentNameByIdAsync(id);
            if(customer == null) return null;

            return new CustomerWithAgentDto
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                HomePhone = customer.HomePhone,
                CellPhone = customer.CellPhone,
                GenderId = customer.GenderId,
                Address = customer.Address,
                PlanType = customer.PlanType,
                EnrollmentDate = customer.EnrollmentDate,
                AgentFullName = customer.Agent != null
                    ? $"{customer.Agent.FirstName} {customer.Agent.LastName} " 
                    : null
            };

        }

        public async Task<IEnumerable<CustomerWithAgentDto>> GetAllCustomersWithAgentNamesAsync()
        {
            var customers = await _customerRepository.GetAllCustomersWithAgentsAsync();

            return customers.Select(customer => new CustomerWithAgentDto
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                HomePhone = customer.HomePhone,
                CellPhone = customer.CellPhone,
                GenderId = customer.GenderId,
                Address = customer.Address,
                PlanType = customer.PlanType,
                EnrollmentDate = customer.EnrollmentDate,
                AgentId = customer.AgentId,
                AgentFullName = customer.Agent != null
                    ? $"{customer.Agent.FirstName} {customer.Agent.LastName}"
                    : null
            });
        }

        //Convert Lead into Customer
        public async Task<CustomerModel?> ConvertLeadIntoCustomerAsync(int leadId, LeadToCustomerDTO dto)
        {
            var lead = await _leadRepository.GetLeadByIdAsync(leadId);
            if (lead == null || lead.IsConvertedToCustomer)
                return null;

            var customer = new CreateCustomerDto
            {
                //From LeadModel
                AgentId = (int)lead.AgentId,
                FirstName = lead.Name,
                LastName = lead.LastName,
                Email = lead.Email,
                CellPhone = lead.PhoneNumber,

                //From Person
                HomePhone = dto.HomePhone,
                MiddleName = dto.MiddleName,
                Nickname = dto.Nickname,
                DateOfBirth = dto.DateOfBirth,
                GenderId = dto.GenderId,
                SSN = dto.SSN,
                DriversLicenseNumber = dto.DriversLicenseNumber,

                //From Customer
                Address = dto.Address,
                MedicareBeneficiaryId = dto.MedicareBeneficiaryId,
                MedicareEffectiveDatePartA = dto.MedicareEffectiveDatePartA,
                MedicareEffectiveDatePartB = dto.MedicareEffectiveDatePartB,
                PlanType = dto.PlanType,
            };

             var customerMapped = CustomerMapper.FromCreateDtoToCustomerModel(customer);
            await CreateCustomerAsync(customerMapped);

            lead.IsConvertedToCustomer = true;
            lead.ConvertedToCustomerAt = DateTime.UtcNow;
            lead.LeadStatusId = 5;
            await _leadRepository.UpdateAsync(lead);

            return customerMapped;
        }

        public async Task<bool> UpdateCustomerAsync(UpdateCustomerDto customer)
        {
            var existing = await _customerRepository.GetCustomerWithAgentNameByIdAsync(customer.Id);
            if (existing == null)
                return false;

            // Actualiza solo los campos permitidos
            existing.Email = customer.Email;
            existing.HomePhone = customer.HomePhone;
            existing.CellPhone = customer.CellPhone;
            existing.PlanType = customer.PlanType;
            existing.AgentId = customer.AgentId;
            existing.Address = customer.Address;

            await _customerRepository.UpdateAsync(existing);
            return true;
        }

        // En CustomerService.cs
        public async Task<CustomerModel?> GetCustomerByIdAsync(int id)
        {
            return await _customerRepository.GetCustomerWithAgentNameByIdAsync(id);
        }


    }
}
