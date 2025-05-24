using CRM.NexPolicy.src.DataLayer.Models;

namespace CRM.NexPolicy.src.DataLayer.Repository.Customer
{
    public interface ICustomerRepository
    {
        Task<CustomerModel> CreateAsync(CustomerModel customer);
        Task<CustomerModel?> GetByIdAsync(int id);
        Task UpdateAsync(CustomerModel customer);

    }
}
