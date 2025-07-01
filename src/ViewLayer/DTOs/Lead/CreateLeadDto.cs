namespace CRM.NexPolicy.src.ViewLayer.DTOs.Lead
{
    public class CreateLeadDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int StatusId { get; set; }
        public int LeadSourceId { get; set; }
    }
}
