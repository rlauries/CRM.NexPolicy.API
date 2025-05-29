

using CRM.NexPolicy.src.DataLayer.Models;

namespace CRM.NexPolicy.src.ViewLayer.DTOs.Agent
{
    public class CreateAgentDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? HomePhone { get; set; }
        public string? CellPhone { get; set; }
        public string? MiddleName { get; set; }
        public string? Nickname { get; set; }
        public string? Title { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public GenderTypeModel? Gender { get; set; }
        public string? SSN { get; set; }
        public string? DriversLicenseNumber { get; set; }

        public string LicenseNumber { get; set; } = string.Empty;
        public DateTime ContractedDate { get; set; }
        public bool IsActive { get; set; } = true;
        public string? ManagerName { get; set; }
    }

}
