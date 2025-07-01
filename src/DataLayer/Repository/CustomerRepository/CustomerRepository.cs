using CRM.NexPolicy.src.DataLayer.Models.Customer;
using CRM.NexPolicy.src.DataLayer.Repository;
using CRM.NexPolicy.src.ViewLayer.DTOs.Customer;
using Microsoft.EntityFrameworkCore;

namespace CRM.NexPolicy.src.DataLayer.Repository.CustomerRepository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _dbContext;

        public CustomerRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CustomerModel> CreateAsync(CustomerModel customer)
        {
            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync();
            return customer;
        }

        public async Task<CustomerModel?> GetCustomerWithAgentNameByIdAsync(int id)
        {
            return await _dbContext.Customers
                .Include(c => c.Agent)
                .Include(c => c.Gender)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(CustomerModel customer)
        {
            _dbContext.Customers.Update(customer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<CustomerModel>> GetAllCustomersWithAgentsAsync()
        {
            return await _dbContext.Customers
                .Include(c => c.Agent)
                .Include(c => c.Gender)
                .ToListAsync();
        }


    }
}
