using CRM.NexPolicy.src.DataLayer.Models.Customer;
using CRM.NexPolicy.src.ViewLayer.DTOs.Customer;

namespace CRM.NexPolicy.src.DataLayer.Repository.Customer
{
    public interface ICustomerRepository
    {
        Task<CustomerModel> CreateAsync(CustomerModel customer);
        Task<CustomerModel?> GetCustomerWithAgentNameByIdAsync(int id);
        Task UpdateAsync(CustomerModel customer);
        Task<List<CustomerModel>> GetAllCustomersWithAgentsAsync();

    }
}
