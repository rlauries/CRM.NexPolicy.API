namespace CRM.NexPolicy.src.DataLayer.Models.UploadImages.ProfileImages
{
    public class UploadImageRequest
    {
        public int Id { get; set; } // AgencyId o AgentId
        public string Type { get; set; } = ""; // "agency" o "agent"
        public IFormFile File { get; set; }
    }
}
