using CRM.NexPolicy.src.DataLayer.Models.Person;

namespace CRM.NexPolicy.src.ViewLayer.DTOs.Agent
{
    public class CreateAgentDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int AgencyId { get; set; }
        
        public string? HomePhone { get; set; }
        public string? CellPhone { get; set; }
        
        public DateTime? DateOfBirth { get; set; }
        public int? GenderId { get; set; } = 0;
        public string? SSN { get; set; }
        public string? DriversLicenseNumber { get; set; }
        public string LicenseNumber { get; set; } = string.Empty;

        // Dirección 🏠
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }

        
        

    }

}
