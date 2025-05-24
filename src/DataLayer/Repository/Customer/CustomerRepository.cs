using CRM.NexPolicy.src.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace CRM.NexPolicy.src.DataLayer.Repository.Customer
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

        public async Task<CustomerModel?> GetByIdAsync(int id)
        {
            return await _dbContext.Customers
                .Include(c => c.Agent)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task UpdateAsync(CustomerModel customer)
        {
            _dbContext.Customers.Update(customer);
            await _dbContext.SaveChangesAsync();
        }

    }
}
