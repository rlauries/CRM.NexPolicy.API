using CRM.NexPolicy.src.DataLayer.Models.Person;

namespace CRM.NexPolicy.src.ViewLayer.DTOs.Customer
{
    public class CreateCustomerDto
    {
        public int AgentId { get; set; } // <- requerido
        
        //From LeadModel
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? CellPhone { get; set; }

        //From PersonModel
        public string? HomePhone { get; set; }
        public string? MiddleName { get; set; }
        public string? Nickname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int GenderId { get; set; }
        public GenderTypeModel? Gender { get; set; }
        public string? SSN { get; set; }
        public string? DriversLicenseNumber { get; set; }

        //From Customer
        public string? Address { get; set; }
        public string? MedicareBeneficiaryId { get; set; }
        public DateTime? MedicareEffectiveDatePartA { get; set; }
        public DateTime? MedicareEffectiveDatePartB { get; set; }
        public string? PlanType { get; set; }
        
    }
}
