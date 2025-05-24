using Microsoft.VisualBasic;
using System.Text.Json.Serialization;
using static CRM.NexPolicy.src.DataLayer.Enums.EnumExtensions;

namespace CRM.NexPolicy.src.DataLayer.Models
{
    public class LeadModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Address { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public LeadSource Source { get; set; } = LeadSource.Unknown;
        public DateTime CreatedAt { get; set; }
        public bool IsConvertedToCustomer { get; set; } = false;
        public DateTime? ConvertedToCustomerAt { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public LeadStatus? Status { get; set; } = LeadStatus.New;

        public int? AssignedAgentID { get; set; }
        public AgentModel? Agent { get; set; }

        //public List<string>? Interactions { get; set; } = new();
    }

}
