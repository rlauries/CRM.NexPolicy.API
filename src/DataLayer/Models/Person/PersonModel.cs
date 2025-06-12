namespace CRM.NexPolicy.src.DataLayer.Models.Person
{
    public abstract class PersonModel
    {
        public int Id { get; set; }

        // From Lead
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

        // 🔁 Foreign Key a GenderTypes
        public int GenderId { get; set; }
        public GenderTypeModel? Gender { get; set; }

        public string? SSN { get; set; }
        public string? DriversLicenseNumber { get; set; }

    }
}
