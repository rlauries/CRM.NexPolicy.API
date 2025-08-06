using CRM.NexPolicy.src.DataLayer.Models.Agency;
using CRM.NexPolicy.src.DataLayer.Models.Customer;
using CRM.NexPolicy.src.DataLayer.Models.Lead;
using CRM.NexPolicy.src.DataLayer.Models.Person;

namespace CRM.NexPolicy.src.DataLayer.Models.Agent
{
    public class AgentModel : PersonModel
    {
        
        public string LicenseNumber { get; set; } = string.Empty;
        public DateTime ContractedDate { get; set; }
        public bool IsActive { get; set; } = true;
        public string? ManagerName { get; set; }
        public int AgencyId { get; set; }
        public AgencyModel? Agency { get; set; } = null!;

        //public List<LeadModel>? Leads { get; set; }
        //public List<CustomerModel>? Customers { get; set; }

        //public List<ActivityModel> Activities { get; set; } = new();
    }
}
