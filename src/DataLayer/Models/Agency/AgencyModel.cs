using CRM.NexPolicy.src.DataLayer.Models.Agent;
using CRM.NexPolicy.src.DataLayer.Models.Customer;
using CRM.NexPolicy.src.DataLayer.Models.Lead;
using System.ComponentModel.DataAnnotations;

namespace CRM.NexPolicy.src.DataLayer.Models.Agency
{
    public class AgencyModel
    {
        [Key]
        public int Id { get; set; }

        public string BusinessName { get; set; } = string.Empty;
        public string? TaxId { get; set; }
        public string? NPN { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? OwnerName { get; set; }
        public string? Website { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Relationships
        public List<AgentModel>? Agents { get; set; }
        public List<LeadModel>? Leads { get; set; }
        public List<CustomerModel>? Customers { get; set; }
    }
}
