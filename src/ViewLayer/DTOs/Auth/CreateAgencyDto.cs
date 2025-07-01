namespace CRM.NexPolicy.src.ViewLayer.DTOs.Auth
{
    public class CreateAgencyDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string BusinessName { get; set; } = string.Empty;
        public string ProfileImageUrl {  get; set; } = string.Empty;
        public string RecaptchaToken { get; set; }
    }
}
