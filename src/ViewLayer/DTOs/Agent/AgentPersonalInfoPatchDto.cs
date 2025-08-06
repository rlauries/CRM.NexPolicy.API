namespace CRM.NexPolicy.src.ViewLayer.DTOs.Agent
{
    public class AgentPersonalInfoPatchDto
    {
        public int Id {  get; set; }
        public int? IndividualStatusId { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
    }
}
