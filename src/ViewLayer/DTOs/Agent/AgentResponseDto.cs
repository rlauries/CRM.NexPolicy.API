using CRM.NexPolicy.src.ViewLayer.DTOs.Lead;

namespace CRM.NexPolicy.src.ViewLayer.DTOs.Agent
{
    public class AgentResponseDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string LicenseNumber { get; set; } = string.Empty;
        public List<LeadSummaryDto> Leads { get; set; } = new();
    }
}
