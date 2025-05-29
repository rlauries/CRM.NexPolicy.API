using CRM.NexPolicy.src.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace CRM.NexPolicy.src.DataLayer.Repository
{
    public class AppDbContext : DbContext
    {
        public DbSet<LeadModel> Leads { get; set; }
        public DbSet<AgentModel> Agents { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<GenderTypeModel> GenderTypes { get; set; }

        public DbSet<LeadSourceModel> LeadSources { get; set; }
        public DbSet<LeadStatusModel> LeadStatuses { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Herencia TPT
            modelBuilder.Entity<PersonModel>().ToTable("Persons");
            modelBuilder.Entity<AgentModel>().ToTable("Agents");
            modelBuilder.Entity<CustomerModel>().ToTable("Customers");
            modelBuilder.Entity<LeadModel>().ToTable("Leads");
            modelBuilder.Entity<LeadSourceModel>().ToTable("LeadSources");

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


            //Relacion LeadModel -> Agent
            modelBuilder.Entity<LeadModel>()
                .HasOne(l => l.Agent)
                .WithMany(a => a.Leads)
                .HasForeignKey(l => l.AssignedAgentID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LeadModel>()
                .HasOne(l => l.LeadSource)
                .WithMany()
                .HasForeignKey(l => l.LeadSourceId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LeadModel>()
                .HasOne(l => l.Status)
                .WithMany()
                .HasForeignKey(l => l.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PersonModel>()
                .HasOne(p => p.Gender)
                .WithMany()
                .HasForeignKey(p => p.GenderId)
                .OnDelete(DeleteBehavior.Restrict);




        }

    }

}
