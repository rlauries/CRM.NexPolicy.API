using CRM.NexPolicy.src.DataLayer.Models.Agency;
using CRM.NexPolicy.src.DataLayer.Models.Agent;
using CRM.NexPolicy.src.DataLayer.Models.Customer;
using CRM.NexPolicy.src.DataLayer.Models.Lead;
using CRM.NexPolicy.src.DataLayer.Models.Person;
using Microsoft.EntityFrameworkCore;

namespace CRM.NexPolicy.src.DataLayer.Repository
{
    public class AppDbContext : DbContext
    {
        public DbSet<AgencyModel> Agencies { get; set; }

        
        public DbSet<AgentModel> Agents { get; set; }
        public DbSet<LeadModel> Leads { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }
        
        //Table References for Normalization
        public DbSet<GenderTypeModel> GenderTypes { get; set; }
        public DbSet<LeadSourceModel> LeadSources { get; set; }
        public DbSet<LeadStatusModel> LeadStatuses { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Herencia TPT
            modelBuilder.Entity<AgencyModel>().ToTable("Agencies");
            modelBuilder.Entity<PersonModel>().ToTable("Persons");
            modelBuilder.Entity<AgentModel>().ToTable("Agents");
            modelBuilder.Entity<CustomerModel>().ToTable("Customers");
            modelBuilder.Entity<LeadModel>().ToTable("Leads");
            modelBuilder.Entity<LeadSourceModel>().ToTable("LeadSources");

            // ============================ AGENCY ============================
            modelBuilder.Entity<AgencyModel>(entity =>
            {
                entity.HasMany(a => a.Agents)
                      .WithOne(ag => ag.Agency)
                      .HasForeignKey(ag => ag.AgencyId);

                entity.HasMany(a => a.Leads)
                      .WithOne(l => l.Agency)
                      .HasForeignKey(l => l.AgencyId);

                entity.HasMany(a => a.Customers)
                      .WithOne(c => c.Agency)
                      .HasForeignKey(c => c.AgencyId);
            });
            // ============================ AGENT ============================
            modelBuilder.Entity<AgentModel>(entity =>
            {
                entity.HasMany(a => a.Leads)
                      .WithOne(l => l.Agent)
                      .HasForeignKey(l => l.AssignedAgentID)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(a => a.Customers)
                      .WithOne(c => c.Agent)
                      .HasForeignKey(c => c.AgentId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // ============================ LEAD ============================
            modelBuilder.Entity<LeadModel>(entity =>
            {
                entity.HasOne(l => l.Agent)
                      .WithMany(a => a.Leads)
                      .HasForeignKey(l => l.AssignedAgentID)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(l => l.LeadSource)
                      .WithMany()
                      .HasForeignKey(l => l.LeadSourceId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(l => l.Status)
                      .WithMany()
                      .HasForeignKey(l => l.StatusId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // ============================ PERSON ============================
            modelBuilder.Entity<PersonModel>(entity =>
            {
                entity.HasOne(p => p.Gender)
                      .WithMany()
                      .HasForeignKey(p => p.GenderId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

           






        }

    }

}
