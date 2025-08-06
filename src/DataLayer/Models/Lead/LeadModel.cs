using CRM.NexPolicy.src.DataLayer.Models.Agency;
using CRM.NexPolicy.src.DataLayer.Models.Agent;
using Microsoft.VisualBasic;
using System.Text.Json.Serialization;



namespace CRM.NexPolicy.src.DataLayer.Models.Lead
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
        public int LeadStatusId { get; set; }
        public LeadStatusModel? Status { get; set; }

        public bool IsConvertedToCustomer { get; set; } = false;
        public DateTime? ConvertedToCustomerAt { get; set; }


        //✅Agency fk
        public int AgencyId { get; set; }
        public AgencyModel Agency { get; set; } = null!;

        // ✅ Foreign key a tabla Agents
        public int? AgentId { get; set; }
        public AgentModel? Agent { get; set; }
    }
}



