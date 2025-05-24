namespace CRM.NexPolicy.src.ViewLayer.DTOs.Customer
{
    
    public class UpdateCustomerDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? HomePhone { get; set; }
        public string? CellPhone { get; set; }
        public string? Address { get; set; }

        public string? PlanType { get; set; }
        public DateTime? EnrollmentDate { get; set; }

        public int? AgentId { get; set; }
    }
    
}
