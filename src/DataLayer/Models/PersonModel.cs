using static CRM.NexPolicy.src.DataLayer.Enums.EnumExtensions;

namespace CRM.NexPolicy.src.DataLayer.Models
{
    public abstract class PersonModel
    {
        public int Id { get; set; }

        // Información básica
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? HomePhone { get; set; }
        public string? CellPhone { get; set; }

        // Información progresiva
        public string? MiddleName { get; set; }
        public string? Nickname { get; set; }
        public string? Title { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public GenderType Gender { get; set; } = GenderType.Unknown;
        public string? SSN { get; set; }
        public string? DriversLicenseNumber { get; set; }
        
    }
}
