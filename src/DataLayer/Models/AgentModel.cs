using static CRM.NexPolicy.src.DataLayer.Enums.EnumExtensions;

namespace CRM.NexPolicy.src.DataLayer.Models
{
    public class AgentModel : PersonModel
    {
        public string LicenseNumber { get; set; } = string.Empty;
        public DateTime ContractedDate { get; set; }
        public bool IsActive { get; set; } = true; 
        public string? ManagerName { get; set; }

        public List<LeadModel>? Leads { get; set; }
        public List<CustomerModel>? Customers { get; set; }
        
        //public List<ActivityModel> Activities { get; set; } = new();
    }
}
