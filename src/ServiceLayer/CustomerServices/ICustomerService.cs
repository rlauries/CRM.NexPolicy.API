using CRM.NexPolicy.src.DataLayer.Models;
using CRM.NexPolicy.src.ViewLayer.DTOs.Customer;

namespace CRM.NexPolicy.src.ServiceLayer.Customer
{
    public interface ICustomerService
    {
        Task<CustomerModel> CreateCustomerAsync(CustomerModel customer);
        Task<IEnumerable<CustomerWithAgentDto>> GetAllCustomersWithAgentNamesAsync();

        Task<CustomerWithAgentDto?> GetCustomerWithAgentNameByIdAsync(int id);
        // En ICustomerService.cs
        Task<CustomerModel?> GetCustomerByIdAsync(int id);

        Task<CustomerModel?> ConvertLeadIntoCustomerAsync(int leadId, LeadToCustomerDTO dto);
        Task<bool> UpdateCustomerAsync(UpdateCustomerDto customer);

    }
}
