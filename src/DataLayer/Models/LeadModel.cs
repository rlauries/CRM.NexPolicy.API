using Microsoft.VisualBasic;
using System.Text.Json.Serialization;



namespace CRM.NexPolicy.src.DataLayer.Models
{
    public class LeadModel
    {
        public int ID { get; set; }

        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Address { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // ✅ Foreign key a tabla LeadSources
        public int LeadSourceId { get; set; }
        public LeadSourceModel? LeadSource { get; set; }

        // ✅ Foreign key a tabla LeadStatuses
        public int StatusId { get; set; }
        public LeadStatusModel? Status { get; set; }

        public bool IsConvertedToCustomer { get; set; } = false;
        public DateTime? ConvertedToCustomerAt { get; set; }

        // ✅ Foreign key a tabla Agents
        public int? AssignedAgentID { get; set; }
        public AgentModel? Agent { get; set; }
    }
}



