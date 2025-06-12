using CRM.NexPolicy.src.DataLayer.Models.Agency;
using CRM.NexPolicy.src.DataLayer.Models.Agent;
using CRM.NexPolicy.src.DataLayer.Models.Person;

namespace CRM.NexPolicy.src.DataLayer.Models.Customer
{
    public class CustomerModel : PersonModel
    {
        public string? Address { get; set; }

        public string? MedicareBeneficiaryId { get; set; }

        public DateTime? MedicareEffectiveDatePartA { get; set; }

        public DateTime? MedicareEffectiveDatePartB { get; set; }

        public string? PlanType { get; set; }

        public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;

        //🔁Agency fk
        public int AgencyId { get; set; }
        public AgencyModel Agency { get; set; } = null!;
        
        // 🔁 Relación con agente asignado
        public int? AgentId { get; set; }
        public AgentModel? Agent { get; set; }
    }
}
