using CRM.NexPolicy.src.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace CRM.NexPolicy.src.DataLayer.Repository
{
    public class AppDbContext : DbContext
    {
        public DbSet<LeadModel> Leads { get; set; }
        public DbSet<AgentModel> Agents { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Herencia TPT
            modelBuilder.Entity<PersonModel>().ToTable("Persons");
            modelBuilder.Entity<AgentModel>().ToTable("Agents");
            modelBuilder.Entity<CustomerModel>().ToTable("Customers");
            modelBuilder.Entity<LeadModel>().ToTable("Leads");

            // Relación Agent → Leads
            modelBuilder.Entity<AgentModel>()
                .HasMany(a => a.Leads)
                .WithOne(l => l.Agent)
                .HasForeignKey(l => l.AssignedAgentID)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación Agent → Customers
            modelBuilder.Entity<AgentModel>()
                .HasMany(a => a.Customers)
                .WithOne(c => c.Agent)
                .HasForeignKey(c => c.AgentId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }

}
