namespace CRM.NexPolicy.src.ViewLayer.DTOs.Customer
{
    
    public class UpdateCustomerDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? HomePhone { get; set; }
        public string? CellPhone { get; set; }
        public string? Address { get; set; }

        public string? PlanType { get; set; }
        
        public int? AgentId { get; set; }
    }
    
}
