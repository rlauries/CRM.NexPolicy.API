using System.Text.Json.Serialization;

namespace CRM.NexPolicy.src.DataLayer.Models.Lead
{
    public class LeadSourceModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

    }
}
