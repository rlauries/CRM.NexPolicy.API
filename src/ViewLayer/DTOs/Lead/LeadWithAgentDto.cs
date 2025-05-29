namespace CRM.NexPolicy.src.ViewLayer.DTOs.Lead
{
    public class LeadWithAgentDto
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsConvertedToCustomer { get; set; }
        public DateTime? ConvertedToCustomerAt { get; set; }
        
        public string? AssignedAgentFullName { get; set; }

        public string? StatusName { get; set; }
        public string? LeadSourceName { get; set; }
    }
}
