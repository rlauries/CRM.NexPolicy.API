namespace CRM.NexPolicy.src.ViewLayer.DTOs.Customer
{
    public class CustomerWithAgentDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? FullName => $"{FirstName} {LastName}";
        public string Email { get; set; } = string.Empty;
        public string? HomePhone { get; set; }
        public string? CellPhone { get; set; }
        public string? Address { get; set; }
        
        //Gender
        public int? GenderId { get; set; }
        public string? GenderName { get; set; }
        
        public string? PlanType { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public int? AgentId { get; set; }
        public string? AgentFullName { get; set; }
    }
}
