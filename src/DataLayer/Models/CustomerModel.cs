namespace CRM.NexPolicy.src.DataLayer.Models
{
    public class CustomerModel : PersonModel
    {
        public string? Address { get; set; }

        public string? MedicareBeneficiaryId { get; set; }

        public DateTime? MedicareEffectiveDatePartA { get; set; }

        public DateTime? MedicareEffectiveDatePartB { get; set; }

        public string? PlanType { get; set; }

        public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;

        // 🔁 Relación con agente asignado
        public int? AgentId { get; set; }
        public AgentModel? Agent { get; set; }
    }
}
