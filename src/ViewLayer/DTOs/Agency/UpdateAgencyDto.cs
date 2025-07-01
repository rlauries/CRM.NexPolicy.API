namespace CRM.NexPolicy.src.ViewLayer.DTOs.Agency
{
    public class UpdateAgencyDto
    {
        public string BusinessName { get; set; } = string.Empty;
        public string? TaxId { get; set; }
        public string? NPN { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? OwnerName { get; set; }
        public string? Website { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
    }
}
