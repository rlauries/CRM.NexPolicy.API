namespace CRM.NexPolicy.src.ViewLayer.DTOs.Auth
{
    public class LoginResponseDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? BusinessName { get; set; }
        public string Role { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public int? AgencyId { get; set; }
        public int? AgentId { get; set; }
    }
}
