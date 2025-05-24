using CRM.NexPolicy.src.DataLayer.Models;

namespace CRM.NexPolicy.src.ServiceLayer.Customer
{
    public interface ICustomerService
    {
        Task<CustomerModel> CreateCustomerAsync(CustomerModel customer);
        Task<CustomerModel?> GetCustomerByIdAsync(int id);
        Task<CustomerModel?> ConvertLeadIntoCustomerAsync(int leadId);
        Task<bool> UpdateCustomerAsync(CustomerModel customer);

    }
}
