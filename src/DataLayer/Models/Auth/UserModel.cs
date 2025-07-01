using CRM.NexPolicy.src.DataLayer.Models.Agency;
using CRM.NexPolicy.src.DataLayer.Models.Agent;

namespace CRM.NexPolicy.src.DataLayer.Models.Auth
{
    public class UserModel
    {
        public int Id { get; set; }

        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = default!;
        public byte[] PasswordSalt { get; set; } = default!;

        // 🔁 Foreign Key to Role
        public int RoleId { get; set; }
        public UserRoleModel Role { get; set; }

        // 🔁 Foreign Key to Agent
        public int? AgentId { get; set; }
        public AgentModel? Agent { get; set; }

        // 🔁 Foreign Key to Agency
        public int? AgencyId { get; set; }
        public AgencyModel? Agency { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
    }
}
